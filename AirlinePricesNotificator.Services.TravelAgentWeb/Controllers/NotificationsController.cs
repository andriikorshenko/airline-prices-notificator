using AirlinePricesNotificator.Services.TravelAgentWeb.Models;
using AirlinePricesNotificator.Services.TravelAgentWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePricesNotificator.Services.TravelAgentWeb.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController : Controller
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        [HttpPost("")]
        public async Task<ActionResult> FlightChanged(FlightDetailUpdateDto dto)
        {
            var result = await _notificationsService.FlightUpdatedAsync(dto);
            return Ok(result.Value);  
        }
    }
}
