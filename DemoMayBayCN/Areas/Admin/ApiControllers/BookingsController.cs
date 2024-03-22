using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        public AdminService adminServices;
        public BookingsController(AdminService adminServices)
        {
            this.adminServices = adminServices;
        }
        [HttpGet]
        [Route("GetAllBooking")]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetAllBooking([FromQuery] string? keySearch, [FromQuery] PagingParameters pagingParameters)
        {
            PageList<Bookings> booking = await adminServices.GetAllBookings(pagingParameters);
            if (!string.IsNullOrEmpty(keySearch))
            {
                booking = await adminServices.SearchBookings(keySearch, pagingParameters);
                if (booking.Count() == 0)
                {
                    booking = await adminServices.GetAllBookings(pagingParameters);
                }
            }
            var metadata = new
            {
                booking.TotalCount,
                booking.Pagesize,
                booking.CurrentPage,
                booking.TotalPages,
                booking.HasNext,
                booking.HasPrevious,
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { status = true, message = "", data = booking, pagination = metadata });
        }
        [HttpGet]
        [Route("GetBooking")]
        public async Task<IActionResult> GetBooking(int id)
        {
            List<Bookings> booking = await adminServices.GetBookings(id);
            if (booking != null)
            {
                return Ok(new { status = true, messgage = "", data = booking });
            }
            return BadRequest(new { status = false, message = "id không hợp lệ" }); ;
        }
        [HttpPut]
        [Route("updateBooking/{id}")]
        public async Task<IActionResult> updateBooking(int id, bookingRequest request)
        {
            Bookings booking = new Bookings()
            {
                SeatID = request.SeatId,
            };
            await adminServices.UpdateBookings(id, booking);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
        [HttpDelete]
        [Route("deleteBooking/{id}")]
        public async Task<IActionResult> deleteBooking(int id)
        {
            await adminServices.DeleteBookings(id);
            return Ok(new { status = true, message = "Xóa thành công" });
        }
    }
}
