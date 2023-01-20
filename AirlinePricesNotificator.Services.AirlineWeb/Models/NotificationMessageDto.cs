namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record NotificationMessageDto
    {
        public NotificationMessageDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; init; }

        public string WebhookType { get; init; } = string.Empty;

        public string FlightCode { get; init; } = string.Empty;

        public decimal OldPrice { get; init; }

        public decimal NewPrice { get; init; }
    }
}
