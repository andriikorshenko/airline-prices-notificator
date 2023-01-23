namespace AirlinePricesNotificator.Services.SendAgent.Models
{
    public record FlightDetailChangePayloadDto
    {
        public string WebhookUri { get; set; } = string.Empty;

        public string Publisher { get; init; } = string.Empty;

        public string Secret { get; init; } = string.Empty;

        public string FlightCode { get; init; } = string.Empty;

        public decimal OldPrice { get; init; }

        public decimal NewPrice { get; init; }

        public string WebhookType { get; set; } = string.Empty;
    }
}
