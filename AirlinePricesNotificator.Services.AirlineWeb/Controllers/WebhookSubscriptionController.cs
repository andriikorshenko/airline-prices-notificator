using AirlinePricesNotificator.Services.AirlineWeb.Models;
using AirlinePricesNotificator.Services.AirlineWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePricesNotificator.Services.AirlineWeb.Controllers
{
    [ApiController]
    [Route("api/webhook-subscriptions")]
    public class WebhookSubscriptionController : Controller
    {
        private readonly IWebhookSubscriptionService _webhookSubscriptionService;

        public WebhookSubscriptionController(IWebhookSubscriptionService webhookSubscriptionService)
        {
            _webhookSubscriptionService = webhookSubscriptionService;
        }

        [HttpGet("")]
        public async Task<IReadOnlyList<WebhookSubscriptionDto>> GetAllSubscriptions()
        {
            return await _webhookSubscriptionService.AllAsync();
        }

        [HttpGet("{secret}", Name = "GetSubscriptionsBySecret")]
        public async Task<WebhookSubscriptionDto> GetSubscriptionsBySecret(string secret)
        {
            var result = await _webhookSubscriptionService.FindBySecretAsync(secret);
            return result.Value;
        }

        [HttpPost("create")]
        public async Task<ActionResult<WebhookSubscriptionDto>> CreateSubscription(WebhookSubsriptionCreateDto dto)
        {
            var result = await _webhookSubscriptionService.CreateAsync(dto);
            return CreatedAtRoute(nameof(GetSubscriptionsBySecret), new { secret = result.Value.Secret}, result.Value);
        }

        [HttpGet("delete/{secret}")]
        public async Task<object> DeleteSubscriptionBySecret(string secret)
        {
            var result = await _webhookSubscriptionService.DeleteAsync(secret);
            return result.IsSuccess ?
                StatusCodes.Status200OK :
                StatusCodes.Status404NotFound;
        }
    }
}
