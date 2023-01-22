using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AirlinePriceNotificator.Services.SendAgent.App.Imp
{
    public class AppHost : IAppHost
    {
        public void Run()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "user",
                Password = "password"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(
                        queue: queueName,
                        exchange: "trigger",
                        routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    Console.WriteLine("Listenning on the Message Bus...");

                    consumer.Received += async (ModuleHandle, ea) =>
                    {
                        Console.WriteLine("Event is triggered!");
                    };

                    channel.BasicConsume(
                        queue: queueName, 
                        autoAck: true, 
                        consumer: consumer);

                    Console.ReadLine();
                }
            }
        }
    }
}
