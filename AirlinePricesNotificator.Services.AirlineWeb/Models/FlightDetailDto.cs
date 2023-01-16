namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public class FlightDetailDto
    {
        public int Id { get; init; }

        public int FlightCode { get; init; }

        public decimal Price { get; init; }
    }
}
