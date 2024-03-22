using Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Controllers
{
    public class CheckOutController : Controller
    {
        public VnPayService VnPayService;
        public CheckOutController(VnPayService VnPayService)
        {
            this.VnPayService = VnPayService;
        }
        public IActionResult PaymentCallback()
        {
            var response = VnPayService.PaymentExecute(Request.Query);

            if (response.Success)
            {
                // Payment success, return the success view
                return View("PaymentSuccess", response);
            }
            else
            {
                // Payment failed, return the failure view
                return View("PaymentConfirm", response);
            }
        }

        public IActionResult Seats()
        {
            return View();
        }
        public IActionResult Passengers()
        {
            return View();
        }
        public IActionResult TicketInformation()
        {
            return View();
        }
        public IActionResult PaymentSuccess()
        {
            return View(); 
        }
        public IActionResult SearchTicket()
        {
            return View();
        }
    }
}
