using AirlinePricesNotificator.Services.AirlineWeb.Models;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services
{
    public interface IMessageBusService
    {
        void SendMessage(NotificationMessageDto dto);
    }
}
