namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record FlightDetailUpdateDto
    {
        public string FlightCode { get; init; } = string.Empty;

        public decimal Price { get; init; }
    }
}
