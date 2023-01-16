using AirlinePricesNotificator.Services.AirlineWeb.Models;
using AirlinePricesNotificator.Services.AirlineWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePricesNotificator.Services.AirlineWeb.Controllers
{
    [ApiController]
    [Route("api/webhook-subscriptions")]
    public class WebhookSubscriptionController : Controller
    {
        private readonly IRepository _repository;

        public WebhookSubscriptionController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IReadOnlyList<WebhookSubscriptionDto>> GetSubscriptions()
        {
            return await _repository.AllAsync();
        }

        [HttpGet("{secret}", Name = "GetSubscriptionsBySecret")]
        public async Task<WebhookSubscriptionDto> GetSubscriptionsBySecret(string secret)
        {
            var result = await _repository.FindBySecretAsync(secret);
            return result.Value;
        }

        [HttpPost("create")]
        public async Task<ActionResult<WebhookSubscriptionDto>> GetSubscriptionsBySecret(WebhookSubsriptionCreateDto dto)
        {
            var result = await _repository.CreateAsync(dto);
            return CreatedAtRoute(nameof(GetSubscriptionsBySecret), new { secret = result.Value.Secret}, result.Value);
        }

        [HttpGet("delete/{secret}")]
        public async Task<object> DeleteSubscriptionBySecret(string secret)
        {
            var result = await _repository.DeleteAsync(secret);
            return result.IsSuccess ?
                StatusCodes.Status200OK :
                StatusCodes.Status404NotFound;
        }
    }
}
