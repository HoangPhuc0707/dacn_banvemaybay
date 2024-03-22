using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
