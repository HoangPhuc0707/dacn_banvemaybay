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
    public class PassengerController : ControllerBase
    {
        public AdminService adminServices;
        public PassengerController(AdminService adminServices)
        {
            this.adminServices = adminServices;
        }
        [HttpGet]
        [Route("GetAllPassenger")]
        public async Task<ActionResult<IEnumerable<Passengers>>> GetAllPassenger([FromQuery] string? keySearch, [FromQuery] PagingParameters pagingParameters)
        {
            PageList<Passengers> passenger = await adminServices.GetAllPassengers(pagingParameters);
            if (!string.IsNullOrEmpty(keySearch))
            {
                passenger = await adminServices.SearchPassengers(keySearch, pagingParameters);
                if (passenger.Count() == 0)
                {
                    passenger = await adminServices.GetAllPassengers(pagingParameters);
                }
            }
            var metadata = new
            {
                passenger.TotalCount,
                passenger.Pagesize,
                passenger.CurrentPage,
                passenger.TotalPages,
                passenger.HasNext,
                passenger.HasPrevious,
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { status = true, message = "", data = passenger, pagination = metadata });
        }
        [HttpGet]
        [Route("GetPassenger")]
        public async Task<IActionResult> GetPassenger(int id)
        {
            Passengers passengers = await adminServices.GetPassengers(id);
            if (passengers != null)
            {
                return Ok(new { status = true, messgage = "", data = passengers });
            }
            return BadRequest(new { status = false, message = "id không hợp lệ" }); ;
        }
        [HttpPost]
        [Route("addPassengers")]
        public async Task<IActionResult> addPassenger(passengerRequest request)
        {
            Passengers passengers = new Passengers()
            {
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                Gender = request.Gender,
                NgaySinh = DateTime.ParseExact(request.NgaySinh, "dd/MM/yyyy", null),
                Address = request.Address,
            };
            await adminServices.addPassengers(passengers);
            return Ok(new { status = true, message = "Thêm thành công" });
        }
        [HttpPut]
        [Route("updatePassenger/{id}")]
        public async Task<IActionResult> updateAirport(int id, passengerRequest request)
        {
            Passengers passengers = new Passengers()
            {
                FullName = request.FullName,
                Phone = request.Phone,
                Email = request.Email,
                Gender = request.Gender,
                NgaySinh = DateTime.ParseExact(request.NgaySinh, "dd/MM/yyyy", null),
                Address = request.Address,
            };
            await adminServices.UpdatePassengers(id, passengers);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
        [HttpDelete]
        [Route("deletePassenger/{id}")]
        public async Task<IActionResult> deletePassenger(int id)
        {
            await adminServices.DeletePassengers(id);
            return Ok(new { status = true, message = "Xóa thành công" });
        }
    }
}
