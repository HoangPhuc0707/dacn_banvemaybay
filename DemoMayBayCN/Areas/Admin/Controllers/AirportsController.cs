using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
