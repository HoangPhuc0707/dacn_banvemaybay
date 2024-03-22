using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PassengersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
