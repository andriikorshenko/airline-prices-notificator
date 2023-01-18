using AirlinePricesNotificator.Services.TravelAgentWeb.Data.Entities;
using AirlinePricesNotificator.Services.TravelAgentWeb.Models;
using Ardalis.Result;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Services
{
    public interface INotificationsService
    {
        IQueryable<WebhookSecret> WebhookSecrets { get; }

        Task<Result> FlightUpdatedAsync(FlightDetailUpdateDto dto);
    }
}
