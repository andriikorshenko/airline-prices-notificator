namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record FlightDetailCreateDto
    {
        public string FlightCode { get; init; } = string.Empty;

        public decimal Price { get; init; }
    }
}
