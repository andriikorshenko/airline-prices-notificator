namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record WebhookSubscriptionDto
    {
        public string WebhookUri { get; init; } = string.Empty;

        public string Secret { get; init; } = string.Empty;

        public string WebhookType { get; init; } = string.Empty;

        public string WebhookPublisher { get; init; } = string.Empty;
    }
}
