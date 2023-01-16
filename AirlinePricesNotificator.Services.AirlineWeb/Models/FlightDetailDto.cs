namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public class FlightDetailDto
    {
        public int Id { get; init; }

        public string FlightCode { get; init; } = string.Empty;

        public decimal Price { get; init; }
    }
}
