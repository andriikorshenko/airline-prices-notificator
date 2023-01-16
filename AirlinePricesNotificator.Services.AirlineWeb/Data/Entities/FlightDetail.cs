using AirlinePricesNotificator.Services.AirlineWeb.Data.Abstractions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace AirlinePricesNotificator.Services.AirlineWeb.Data.Entities
{
    public class FlightDetail : Entity
    {
        public string FlightCode { get; set; }

        public decimal Price { get; set; }
    }
}
