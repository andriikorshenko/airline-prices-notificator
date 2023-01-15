using System.ComponentModel.DataAnnotations;

namespace AirlinePricesNotificator.Services.AirlineWeb.Models
{
    public record WebhookSubsriptionCreateDto
    {
        public string WebhookUri { get; init; } = string.Empty;

        public string WebhookType { get; init; } = string.Empty;
    }
}
