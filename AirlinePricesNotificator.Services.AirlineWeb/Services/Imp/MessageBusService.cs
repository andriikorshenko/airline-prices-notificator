using AirlinePricesNotificator.Services.AirlineWeb.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services.Imp
{
    public class MessageBusService : IMessageBusService
    {
        public void SendMessage(NotificationMessageDto dto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                var message = JsonSerializer.Serialize(dto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

                Console.WriteLine("--> Message Published on MessageBus");
            }
        }
    }
}
