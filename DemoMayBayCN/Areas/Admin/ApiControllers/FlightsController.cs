using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoMayBayCN.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "DepartmentPolicy")]

    public class FlightsController : ControllerBase
    {
        public AdminService adminServices;
        public FlightsController(AdminService adminServices)
        {
            this.adminServices = adminServices;
        }
        [HttpGet]
        [Route("GetAllFlight")]
        public async Task<ActionResult<IEnumerable<Flights>>> GetAllFlight([FromQuery] string? keySearch, [FromQuery] PagingParameters pagingParameters)
        {
            PageList<Flights> flight = await adminServices.GetAllFlights(pagingParameters);
            if (!string.IsNullOrEmpty(keySearch))
            {
                flight = await adminServices.SearchFlights(keySearch, pagingParameters);
                if (flight.Count() == 0)
                {
                    flight = await adminServices.GetAllFlights(pagingParameters);
                }
            }
            var metadata = new
            {
                flight.TotalCount,
                flight.Pagesize,
                flight.CurrentPage,
                flight.TotalPages,
                flight.HasNext,
                flight.HasPrevious,
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new { status = true, message = "", data = flight, pagination = metadata });
        }
        [HttpGet]
        [Route("GetFlight")]
        public async Task<IActionResult> GetFlight(int id)
        {
            List<Flights> flights = await adminServices.GetFlights(id);
            if (flights != null)
            {
                return Ok(new { status = true, messgage = "", data = flights });
            }
            return BadRequest(new { status = false, message = "id không hợp lệ" }); 
        }
        [HttpPost]
        [Route("addFlights")]
        public async Task<IActionResult> addFlights([FromForm] flightRequest request)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
                int currentCount = 0;
                var lastflight = await adminServices.GetFlightNumber();
                if (lastflight != null)
                {
                    string lastFlightNumber = lastflight.FlightNumber;
                    if (int.TryParse(lastFlightNumber.Substring(2), out currentCount))
                    {
                        string flightNumber = string.Format("VN{0:D2}", currentCount + 1);
                        Flights flights = new Flights()
                        {
                            FlightNumber = flightNumber,
                            DepartureDay = DateTime.ParseExact(request.DepartureDay, "dd/MM/yyyy", null),
                            ArrivalTime = request.ArrivalTime,
                            DepartureTime = request.DepartureTime,
                            ArrivlaCity = request.ArrivalCity,
                            DepartureCity = request.DepartureCity,
                            TotalSeats = (int)request.TotalSeats,
                            AvailableSeats = (int)request.TotalSeats,
                            created_by = userId,
                        };
                        if (request.HinhAnh.Length > 0)
                        {
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "flights", request.HinhAnh.FileName);
                            using (var stream = System.IO.File.Create(path))
                            {
                                await request.HinhAnh.CopyToAsync(stream);
                            }
                            flights.HinhAnh = "" + request.HinhAnh.FileName;
                        }
                        else
                        {
                            flights.HinhAnh = "";
                        }
                        await adminServices.addFlights(flights);
                        var fares = new List<Fares>
                    {
                        new Fares
                        {
                            FlightID = flights.FlightID,
                            FareType = "Thương Gia",
                            FareAmount = (decimal)request.ThuongGia,
                        },
                        new Fares
                        {
                            FlightID = flights.FlightID,
                            FareType = "Phổ Thông",
                            FareAmount = (decimal)request.PhoThong,
                        }
                    };
                        await adminServices.addFares(fares);
                        int soHieuGheHang = 1;
                        int soHieuGheCot = 1;
                        for (int i = 1; i <= request.TotalSeats; i++)
                        {
                            string soHieuGhe = string.Format("{0}{1}", soHieuGheHang, (char)('A' + (soHieuGheCot - 1)));

                            // Xác định lớp ghế dựa trên số ghế
                            string seatClass = (soHieuGheHang >= 1 && soHieuGheHang <= 3) ? "Thương Gia" : "Phổ thông";
                            var seats = new Seats
                            {
                                FlightID = flights.FlightID,
                                SeatNumber = soHieuGhe,
                                SeatClass = seatClass,
                                SeatAvailable = 0,
                            };

                            await adminServices.addSeats(seats);
                            soHieuGheCot++;
                            if (soHieuGheCot > 6)
                            {
                                soHieuGheCot = 1;
                                soHieuGheHang++;
                            }
                        }
                    }
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            
            return Ok(new { status = true, message = "Thêm thành công" });
        }
        [HttpPut]
        [Route("updateFlight/{id}")]
        public async Task<IActionResult> updateFlight(int id,[FromForm] flightRequest request)
        {
            var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
            Flights flights = new Flights()
            {
                DepartureDay = DateTime.ParseExact(request.DepartureDay, "dd/MM/yyyy", null),
                ArrivalTime = request.ArrivalTime,
                DepartureTime = request.DepartureTime,
                ArrivlaCity = request.ArrivalCity,
                DepartureCity = request.DepartureCity,
                created_by = userId,
            };
            if (request.HinhAnh.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "flights", request.HinhAnh.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.HinhAnh.CopyToAsync(stream);
                }
                flights.HinhAnh = "" + request.HinhAnh.FileName;
            }
            await adminServices.UpdateFlights(id, flights);
            var fares = new List<Fares>
            {
                new Fares
                {
                    FlightID = id,
                    FareType = "Thương Gia",
                    FareAmount = (decimal)request.ThuongGia,
                },
                new Fares
                {
                    FlightID = id,
                    FareType = "Phổ Thông",
                    FareAmount = (decimal)request.PhoThong,
                }
            };
            await adminServices.updateFares(fares);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
        [HttpDelete]
        [Route("deleteFlight/{id}")]
        public async Task<IActionResult> deleteFlight(int id)
        {
            await adminServices.deleteSeats(id);
            await adminServices.deleteFares(id);
            await adminServices.deleteFlight(id);
            return Ok(new { status = true, message = "Xóa thành công" });
        }
    }
}
