using AirlinePriceNotificator.Services.SendAgent.Client;
using AirlinePriceNotificator.Services.SendAgent.Data.Models;
using AirlinePricesNotificator.Services.SendAgent.Data;
using AirlinePricesNotificator.Services.SendAgent.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace AirlinePriceNotificator.Services.SendAgent.App.Imp
{
    public class AppHost : IAppHost
    {
        private readonly SendAgentDbContext _dbContext;
        private readonly IWebhookClient _webhookClient;

        public AppHost(SendAgentDbContext dbContext, IWebhookClient webhookClient)
        {
            _dbContext = dbContext;
            _webhookClient = webhookClient;
        }

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

                        var body = ea.Body;
                        var notificationMessage = Encoding.UTF8.GetString(body.ToArray());
                        var message = JsonSerializer.Deserialize<NotificationMessageDto>(notificationMessage);

                        var webhookToSend = new FlightDetailChangePayloadDto()
                        {
                            WebhookType = message.WebhookType,
                            WebhookUri = string.Empty,
                            Secret = string.Empty,
                            Publisher = string.Empty,
                            OldPrice = message.OldPrice,
                            NewPrice = message.NewPrice,
                            FlightCode = message.FlightCode
                        };

                        foreach (var item in _dbContext.Set<WebhookSubscription>()
                            .Where(x => x.WebhookType == message.WebhookType))
                        {
                            webhookToSend.WebhookUri = item.WebhookUri;
                            webhookToSend.Secret = item.Secret;
                            webhookToSend.Publisher = item.WebhookPublisher;

                            await _webhookClient.SendWebhookNotification(webhookToSend);
                        }
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
