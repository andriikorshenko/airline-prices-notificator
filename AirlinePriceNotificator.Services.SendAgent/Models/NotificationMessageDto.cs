namespace AirlinePricesNotificator.Services.SendAgent.Models
{
    public record NotificationMessageDto
    {
        public string Id { get; } = string.Empty;

        public string WebhookType { get; init; } = string.Empty;

        public string FlightCode { get; init; } = string.Empty;

        public decimal OldPrice { get; init; }

        public decimal NewPrice { get; init; }
    }
}
