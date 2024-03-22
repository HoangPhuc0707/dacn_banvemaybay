using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Admin.Controllers
{
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "DepartmentPolicy")]
    [Area("Admin")]
    //[Authorize]
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
