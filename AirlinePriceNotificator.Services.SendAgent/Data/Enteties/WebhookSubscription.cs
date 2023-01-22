using AirlinePriceNotificator.Services.SendAgent.Data.Abstractions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace AirlinePriceNotificator.Services.SendAgent.Data.Models
{
    public class WebhookSubscription : Entity
    {
        public string WebhookUri { get; set; }

        public string Secret { get; set; }

        public string WebhookType { get; set; }

        public string WebhookPublisher { get; set; }
    }
}
