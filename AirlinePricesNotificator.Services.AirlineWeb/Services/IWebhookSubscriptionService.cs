using AirlinePricesNotificator.Services.AirlineWeb.Data.Entities;
using AirlinePricesNotificator.Services.AirlineWeb.Models;
using Ardalis.Result;

namespace AirlinePricesNotificator.Services.AirlineWeb.Services
{
    public interface IWebhookSubscriptionService
    {
        IQueryable<WebhookSubscription> WebhookSubscriptions { get; }

        Task<IReadOnlyList<WebhookSubscriptionDto>> AllAsync();

        Task<Result<WebhookSubscriptionDto>> FindBySecretAsync(string secret);

        Task<Result<WebhookSubscriptionDto>> CreateAsync(WebhookSubsriptionCreateDto dto);

        Task<Result> DeleteAsync(string secret);
    }
}
