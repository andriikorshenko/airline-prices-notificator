using AirlinePricesNotificator.Services.AirlineWeb.Models;
using AirlinePricesNotificator.Services.AirlineWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePricesNotificator.Services.AirlineWeb.Controllers
{
    [ApiController]
    [Route("api/flight-details")]
    public class FlightDetailController : Controller
    {
        private readonly IFlightDetailService _flightDetailService;

        public FlightDetailController(IFlightDetailService flightDetailService)
        {
            _flightDetailService = flightDetailService;
        }

        [HttpGet("{code}", Name = "GetFlightDetailsByCode")]
        public async Task<FlightDetailDto> GetFlightDetailsByCode(string code)
        {
            var result = await _flightDetailService.FindByCodeAsync(code);
            return result.Value;
        }

        [HttpPost("create")]
        public async Task<ActionResult<FlightDetailDto>> CreateFlightDetails(FlightDetailCreateDto dto)
        {
            var result = await _flightDetailService.CreateAsync(dto);
            return CreatedAtRoute(nameof(GetFlightDetailsByCode), new { code = result.Value.FlightCode }, result.Value);
        }

        [HttpGet("delete/{code}")]
        public async Task<object> DeleteFlightDetailsByCode(string code)
        {
            var result = await _flightDetailService.DeleteAsync(code);
            return result.IsSuccess ?
                StatusCodes.Status200OK :
                StatusCodes.Status404NotFound;
        }
    }
}
