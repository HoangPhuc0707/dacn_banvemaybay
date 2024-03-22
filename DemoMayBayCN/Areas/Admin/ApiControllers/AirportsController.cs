using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Services;
using MailKit.Net.Imap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using System.Text.Json.Serialization;

namespace DemoMayBayCN.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        public  AdminService adminServices;
        public AirportsController(AdminService adminServices)
        {
            this.adminServices = adminServices;
        }
        [HttpGet]
        [Route("GetAllAirport")]
        public async Task<ActionResult<IEnumerable<Airports>>> GetAllAirport([FromQuery] string? keySearch,[FromQuery]PagingParameters pagingParameters)
        {
            PageList<Airports> airport = await adminServices.GetAll(pagingParameters);
            if (!string.IsNullOrEmpty(keySearch))
            {
                airport = await adminServices.SearchAirport(keySearch,pagingParameters);
                if (airport.Count() == 0)
                {
                    airport = await adminServices.GetAll(pagingParameters);
                }
            }
            var metadata = new
            {
                airport.TotalCount,
                airport.Pagesize,
                airport.CurrentPage,
                airport.TotalPages,
                airport.HasNext,
                airport.HasPrevious,
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { status = true, message = "", data = airport, pagination = metadata });
        }
        [HttpGet]
        [Route("GetAirport")]
        public async Task<IActionResult> GetAirport(int id)
        {
            Airports airports = await adminServices.GetAirport(id);
            if (airports != null)
            {
                return Ok(new { status = true, messgage = "", data = airports });
            }
            return BadRequest(new { status = false, message = "id không hợp lệ" }); ;
        }
        [HttpGet]
        [Route("GetAllAirport1")]
        public async Task<IActionResult> getAllAirport()
        {
            List<Airports> airports = await adminServices.getAllAirport();
            return Ok(new { status = true, message = "", data = airports });
        }
        [HttpPost]
        [Route("addAirports")]
        public async Task<IActionResult> addAirport(airportRequest request)
        {
            Airports airports = new Airports()
            {
                AirportCode = request.AirportCode,
                AirportName = request.AirportName,
                City = request.City,
            };
            await adminServices.addAirport(airports);
            return Ok(new { status = true, message = "Thêm thành công" });
        }
        [HttpPut]
        [Route("updateAirport/{id}")]
        public async Task<IActionResult> updateAirport(int id,airportRequest request)
        {
            Airports airports = new Airports()
            {
                AirportCode = request.AirportCode,
                AirportName = request.AirportName,
                City = request.City,
            };
            await adminServices.UpdateAirport(id,airports);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
        [HttpDelete]
        [Route("deleteAirport/{id}")]
        public async Task<IActionResult> deleteAirport(int id)
        {
            await adminServices.DeleteAirport(id);
            return Ok(new { status = true, message = "Xóa thành công" });
        }
    }
}
