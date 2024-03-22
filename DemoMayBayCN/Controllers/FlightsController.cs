using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Controllers
{
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FlightSearchOnWay()
        {
            return View();
        }
        public IActionResult FlightSearchRoundTrip()
        {
            return View();
        }
        public IActionResult FlightSearchReturn()
        {
            return View();
        }
    }
}
