using AirlinePricesNotificator.Services.SendAgent.Models;

namespace AirlinePriceNotificator.Services.SendAgent.Client
{
    public interface IWebhookClient
    {
        Task SendWebhookNotification(FlightDetailChangePayloadDto dto);
    }
}
