using Microsoft.AspNetCore.Mvc;

namespace AirlinePricesNotificator.Services.AirlineWeb.Controllers
{
    public class FlightDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
