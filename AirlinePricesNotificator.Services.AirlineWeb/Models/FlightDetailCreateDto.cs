namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record FlightDetailCreateDto
    {
        public int FlightCode { get; init; }

        public decimal Price { get; init; }
    }
}
