namespace AirlinePricesNotificator.Services.TravelAgentWeb.Models
{
    public record FlightDetailUpdateDto
    {
        public string Publisher { get; init; } = string.Empty;

        public string Secret { get; init; } = string.Empty;

        public string FlightCode { get; init; } = string.Empty;

        public decimal OldPrice { get; init; }

        public decimal NewPrice { get; init; }

        public string WebhookType { get; set; } = string.Empty;
    }
}
