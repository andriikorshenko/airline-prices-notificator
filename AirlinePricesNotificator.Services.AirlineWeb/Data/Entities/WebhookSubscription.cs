#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using AirlinePricesNotificator.Services.AirlineWeb.Data.Abstractions;

namespace AirlinePricesNotificator.Services.AirlineWeb.Data.Entities
{
    public class WebhookSubscription : Entity
    { 
        public string WebhookUri { get; set; }

        public string Secret { get; set; }

        public string WebhookType { get; set; }

        public string WebhookPublisher { get; set; }
    }
}
