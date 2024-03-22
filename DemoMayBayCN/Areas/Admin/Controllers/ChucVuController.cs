using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChucVuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
