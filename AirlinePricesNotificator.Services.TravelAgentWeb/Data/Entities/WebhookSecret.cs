using AirlinePricesNotificator.Services.TravelAgentWeb.Data.Abstractions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Data.Entities
{
    public class WebhookSecret : Entity
    {
        public string Secret { get; set; }

        public string Publisher { get; set; }
    }
}
