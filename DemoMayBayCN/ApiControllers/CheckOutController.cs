using DemoMayBayCN.Common;
using DemoMayBayCN.ModelsView;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;
using MimeKit.Text;

namespace DemoMayBayCN.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private IWebHostEnvironment hostEnvironment;
        public FlightsService flightsService;
        public CheckOutService checkOutService;
        public VnPayService VnPayService;
        private readonly IMemoryCache _memoryCache;
        public CheckOutController(FlightsService flightsService,CheckOutService checkOutService, IMemoryCache memoryCache, IWebHostEnvironment hostEnvironment, VnPayService vnPayService)
        {
            this.flightsService = flightsService;
            this.checkOutService = checkOutService;
            _memoryCache = memoryCache;
            this.hostEnvironment = hostEnvironment;
            VnPayService = vnPayService;
        }
        [HttpGet]
        [Route("SeatsDiagram")]
        public async Task<IActionResult> GetAllSeats(int flightId)
        {
            List<Seats> seatsList = await flightsService.GetAllSeats(flightId);
            return Ok(new { status = true, message ="", data=seatsList});
        }
        [HttpGet]
        [Route("FlightSelection")]
        public async Task<IActionResult> FlightSelection(int flightId)
        {
            _memoryCache.Remove("flightSelection");
            // Kiểm tra xem dữ liệu có sẵn trong cache không
            if (!_memoryCache.TryGetValue("flightSelection", out List<Flights> flightSelection))
            {
                // Nếu không có trong cache, thực hiện lấy dữ liệu từ service
                flightSelection = await checkOutService.FlightSelection(flightId);

                // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                };

                _memoryCache.Set("flightSelection", flightSelection, cacheEntryOptions);
                
            }

            return Ok(new { status = true, message = "", data = flightSelection });
        }
        [HttpGet]
        [Route("FlightReturnSelection")]
        public async Task<IActionResult> FlightReturnSelection(int flightId)
        {
            _memoryCache.Remove("FlightReturnSelection");
            // Kiểm tra xem dữ liệu có sẵn trong cache không
            if (!_memoryCache.TryGetValue("FlightReturnSelection", out List<Flights> flightReturnSelection))
            {
                // Nếu không có trong cache, thực hiện lấy dữ liệu từ service
                flightReturnSelection = await checkOutService.FlightSelection(flightId);

                // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                };

                _memoryCache.Set("FlightReturnSelection", flightReturnSelection, cacheEntryOptions);

            }

            return Ok(new { status = true, message = "", data = flightReturnSelection });
        }
        [HttpPost]
        [Route("SeatSelection")]
        //public async Task<IActionResult> SeatSelection(SeatSelectionRequestModel model)
        //{
        //    _memoryCache.Remove("seatSelection");
        //    if (!_memoryCache.TryGetValue("seatSelection", out List<Seats> seatSelection))
        //    {
        //        // Nếu không có trong cache, thực hiện lấy dữ liệu từ service
        //        seatSelection = await checkOutService.SeatSelect(model.FlightId, model.SeatNumbers);

        //        // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
        //        var cacheEntryOptions = new MemoryCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
        //        };

        //        _memoryCache.Set("seatSelection", seatSelection, cacheEntryOptions);

        //    }
        //    return Ok(new { status = true, message = "", seatSelection = seatSelection, });
        //}
        public async Task<IActionResult> SeatSelection(SeatSelectionRequestModel model)
        {
            if (SeatReservationService.ReserveSeat(model.FlightId, model.SeatNumbers))
            {
                try
                {
                    _memoryCache.Remove("seatSelection");
                    if (!_memoryCache.TryGetValue("seatSelection", out List<Seats> seatSelection))
                    {
                        // Nếu không có trong cache, thực hiện lấy dữ liệu từ service
                        seatSelection = await checkOutService.SeatSelect(model.FlightId, model.SeatNumbers);

                        // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
                        var cacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                        };

                        _memoryCache.Set("seatSelection", seatSelection, cacheEntryOptions);

                    }
                    return Ok(new { status = true, message = "", seatSelection = seatSelection });
                }
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ nếu có trong quá trình chọn chỗ ngồi

                    // Giải phóng chỗ ngồi đã đặt nếu có lỗi xảy ra
                    SeatReservationService.ReleaseSeat(model.FlightId, model.SeatNumbers);

                    return StatusCode(500, new { status = false, message = "Lỗi khi chọn chỗ ngồi" });
                }
            }
            else
            {
                // Chỗ ngồi đã được đặt bởi người khác
                return StatusCode(409, new { status = false, message = "Chỗ ngồi chiều đi hiện tại đang có người đặt vui lòng bạn chọn chỗ khác" });
            }
        }
        [HttpPost]
        [Route("SeatReturnSelection")]
        public async Task<IActionResult> SeatReturnSelection(SeatReturnSelectionRequest model)
        {
            if (SeatReservationService.ReserveSeat(model.FlightId, model.SeatNumbers))
            {
                try
                {
                    _memoryCache.Remove("seatReturnSelection");
                    if (!_memoryCache.TryGetValue("seatReturnSelection", out List<Seats> seatReturnSelection))
                    {
                        // Nếu không có trong cache, thực hiện lấy dữ liệu từ service
                        seatReturnSelection = await checkOutService.SeatSelect(model.FlightId, model.SeatNumbers);

                        // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
                        var cacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                        };

                        _memoryCache.Set("seatReturnSelection", seatReturnSelection, cacheEntryOptions);

                    }
                    return Ok(new { status = true, message = "", seatReturnSelection = seatReturnSelection });
                }
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ nếu có trong quá trình chọn chỗ ngồi

                    // Giải phóng chỗ ngồi đã đặt nếu có lỗi xảy ra
                    SeatReservationService.ReleaseSeat(model.FlightId, model.SeatNumbers);

                    return StatusCode(500, new { status = false, message = "Lỗi khi chọn chỗ ngồi" });
                }
            }
            else
            {
                // Chỗ ngồi đã được đặt bởi người khác
                return StatusCode(409, new { status = false, message = "Chỗ ngồi chiều về hiện tại đang có người đặt vui lòng bạn chọn chỗ khác" });
            }     
        }
        [HttpPost]
        [Route("ProcessBooking")]
        public IActionResult ProcessBooking(List<PassengersRequest> passengers)
        {
            _memoryCache.Remove("passengerSelection");
            if (!_memoryCache.TryGetValue("passengerSelection", out List<PassengersRequest> passengersSelection))
            {
                // Đặt dữ liệu vào cache và thiết lập thời gian hiệu lực là 30 phút
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                };
                passengersSelection = passengers;
                _memoryCache.Set("passengerSelection", passengersSelection, cacheEntryOptions);
                
            }

            return Ok(new { status = true, message = "", data = passengersSelection });
        }
        [HttpGet]
        [Route("TicketInformation")]
        public IActionResult TicketInformation()
        {
            if ( _memoryCache.TryGetValue("flightSelection", out List<Flights> flightSelection) && _memoryCache.TryGetValue("passengerSelection", out List<PassengersRequest> passengersSelection) 
                && _memoryCache.TryGetValue("seatSelection", out List<Seats> seatSelection))
            {
                // Trả về thông tin đã chọn và đã điền
                return Ok(new { status = true, message = "", flightSelection = flightSelection, seatSelection= seatSelection , passengersSelection= passengersSelection });
            }
            else
            {
                return BadRequest("Booking information not found.");
            }
        }
        [HttpGet]
        [Route("TicketReturnInformation")]
        public IActionResult TicketReturnInformation()
        {
            if (_memoryCache.TryGetValue("FlightReturnSelection", out List<Flights> flightReturnSelection) && _memoryCache.TryGetValue("seatReturnSelection", out List<Seats> seatReturnSelection)
                && _memoryCache.TryGetValue("passengerSelection", out List<PassengersRequest> passengersSelection))
            {
                // Trả về thông tin đã chọn và đã điền
                return Ok(new { status = true, message = "", flightReturnSelection = flightReturnSelection, seatReturnSelection = seatReturnSelection, passengersSelection = passengersSelection });
            }
            else
            {
                return BadRequest("Booking information not found.");
            }
        }

        [HttpPost]
        [Route("Booking")]
        public async Task<IActionResult> booking(CheckOutRequest request)
        {
            Payments objpayment = new Payments();
            objpayment.PaymentDate = DateTime.Now;
            objpayment.PaymentMethod = false;
            objpayment.PaymentAmount = request.total;
            await checkOutService.insertPayment(objpayment);
            List<Flights> flightList = _memoryCache.Get<List<Flights>>("flightSelection");
            List<Flights> flightReturnList = _memoryCache.Get<List<Flights>>("FlightReturnSelection");
            TimeSpan totalTime = (TimeSpan)(flightList[0].ArrivalTime - flightList[0].DepartureTime);
            List<PassengersRequest> passengersList = _memoryCache.Get<List<PassengersRequest>>("passengerSelection");
            List<Seats> seatList = _memoryCache.Get<List<Seats>>("seatSelection");
            List<Seats> seatReturnList = _memoryCache.Get<List<Seats>>("seatReturnSelection");
            foreach (Seats seat in seatList)
            {
                await checkOutService.ChangeSeat_1(seat.FlightID, seat.SeatNumber);
            }
            foreach (PassengersRequest passengers in passengersList)
            {
                Passengers passengers1 = new Passengers();
                passengers1.FullName = passengers.FullName;
                passengers1.Phone = passengers.Phone;
                passengers1.Email = passengers.Email;
                passengers1.Gender = passengers.Gender;
                passengers1.NgaySinh = DateTime.ParseExact(passengers.NgaySinh, "dd/MM/yyyy", null);
                passengers1.Address = passengers.Address;

                await checkOutService.insertPassenger(passengers1);
                int passengerId = passengers1.PassengerID;

                Bookings bookings = new Bookings()
                {
                    PassengerID = passengerId,
                    FlightID = seatList[0].FlightID,
                    PaymentID = objpayment.PaymentID,
                    SeatID = seatList[passengersList.IndexOf(passengers)].SeatID,
                    BookingDate = DateTime.Now,
                    BookingStatus = true,
                    TotalPrice = request.total,
                    Verification = MyString.RandomString(),
                };
                await checkOutService.insertBooking(bookings);
                string email = passengers.Email;
                string filePath = Path.Combine(hostEnvironment.WebRootPath, "template", "neworder.html");
                string content = System.IO.File.ReadAllText(filePath);
                content = content.Replace("{{TongTien}}", request.total.ToString("N0"));
                content = content.Replace("{{NgayDat}}", objpayment.PaymentDate.Value.ToString("dd/MM/yyyy"));
                content = content.Replace("{{HoTen}}", passengers.FullName);
                content = content.Replace("{{MaXacNhan}}", bookings.Verification);
                content = content.Replace("{{MaChuyenBay}}", flightList[0].FlightID.ToString());
                content = content.Replace("{{DiemKhoiHanh}}", flightList[0].Airports1.City);
                content = content.Replace("{{DiemDen}}", flightList[0].Airports.City);
                content = content.Replace("{{NgayKhoiHanh}}", flightList[0].DepartureDay.Value.ToString("dd/MM/yyyy"));
                content = content.Replace("{{GioKhoiHanh}}", flightList[0].DepartureTime.Value.ToString());
                content = content.Replace("{{GioDen}}", flightList[0].ArrivalTime.Value.ToString());
                content = content.Replace("{{TongThoiGian}}", totalTime.ToString());
                //content = content.Replace("{{GiaChuyenBayChieuDi}}", flightList[0].Fares.Where(fa).ToString("N0"));
                content = content.Replace("{{HieuMayBay}}", flightList[0].FlightNumber);
                content = content.Replace("{{ChoNgoi}}", seatList[passengersList.IndexOf(passengers)].SeatNumber.ToString());


                if (seatReturnList != null)
                {
                    TimeSpan totalTimeReturn = (TimeSpan)(flightReturnList[0].ArrivalTime - flightReturnList[0].DepartureTime);
                    foreach (Seats seat in seatReturnList)
                    {
                        await checkOutService.ChangeSeat_1(seat.FlightID, seat.SeatNumber);
                    }
                    Bookings bookings1 = new Bookings()
                    {
                        PassengerID = passengerId,
                        FlightID = seatReturnList[0].FlightID,
                        PaymentID = objpayment.PaymentID,
                        SeatID = seatReturnList[passengersList.IndexOf(passengers)].SeatID,
                        BookingDate = DateTime.Now,
                        BookingStatus = true,
                        TotalPrice = request.total,
                        Verification = MyString.RandomString(),
                    };
                    await checkOutService.insertBooking(bookings1);
                    content = content.Replace("{{MaXacNhanKH}}", bookings1.Verification);
                    content = content.Replace("{{HoTenKH}}", passengers.FullName);
                    content = content.Replace("{{MaChuyenBayKH}}", flightReturnList[0].FlightID.ToString());
                    content = content.Replace("{{DiemKhoiHanhKH}}", flightReturnList[0].Airports1.City);
                    content = content.Replace("{{DiemDenKH}}", flightReturnList[0].Airports.City);
                    content = content.Replace("{{NgayKhoiHanhKH}}", flightReturnList[0].DepartureDay.Value.ToString("dd/MM/yyyy"));
                    content = content.Replace("{{GioKhoiHanhKH}}", flightReturnList[0].DepartureTime.Value.ToString());
                    content = content.Replace("{{GioDenKH}}", flightReturnList[0].ArrivalTime.Value.ToString());
                    content = content.Replace("{{TongThoiGianKH}}", totalTimeReturn.ToString());
                    content = content.Replace("{{HieuMayBayKH}}", flightReturnList[0].FlightNumber);
                    //content = content.Replace("{{GiaChuyenBayChieuKH}}", giachuyenbayKH.ToString("N0"));
                    content = content.Replace("{{ChoNgoiKH}}", seatReturnList[passengersList.IndexOf(passengers)].SeatNumber.ToString());
                }
                else
                {
                    string phraseToHide = "<div>\r\n                                                                                    <div style=\"padding-bottom:8px\">\r\n                                                                                        <span style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Số xác nhận</span>\r\n                                                                                        <div>{{MaXacNhanKH}}</div>\r\n                                                                                    </div>\r\n                                                                                    <div style=\"padding-bottom:8px\">\r\n                                                                                        <span style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Hành khách</span>\r\n                                                                                        <div>MR {{HoTenKH}}</div>\r\n                                                                                    </div>\r\n                                                                                </div>\r\n                                                                                <div>\r\n\r\n\r\n                                                                                    <div style=\"border-top:solid 1px black;padding-top:8px\">\r\n                                                                                        <table border=\"1\">\r\n                                                                                            <tbody>\r\n                                                                                                <tr>\r\n                                                                                                    <th colspan=\"6\" style=\"background-color:#d99c00\">\r\n                                                                                                        Chi tiết lộ trình cho:\r\n                                                                                                        <span>{{MaChuyenBayKH}}</span>\r\n                                                                                                        <span style=\"margin-right:1px\"></span>: Sân bay quốc tế {{DiemKhoiHanhKH}} - Sân bay quốc tế {{DiemDenKH}}\r\n                                                                                                    </th>\r\n                                                                                                </tr>\r\n                                                                                                <tr>\r\n                                                                                                    <td>\r\n                                                                                                        <div>\r\n                                                                                                            <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Khởi hành</div>\r\n                                                                                                            <div style=\"font:bold 16px arial;color:#424242;text-align:center\">\r\n                                                                                                                <span>{{NgayKhoiHanhKH}}</span>\r\n                                                                                                                <span style=\"color:#389f08\">{{GioKhoiHanhKH}}</span>\r\n                                                                                                            </div>\r\n                                                                                                        </div>\r\n                                                                                                        <div>\r\n                                                                                                            <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Đến</div>\r\n                                                                                                            <div style=\"font:bold 16px arial;color:#424242;text-align:center\">\r\n                                                                                                                <span>{{NgayKhoiHanhKH}}</span>\r\n                                                                                                                <span style=\"color:#389f08\">{{GioDenKH}}</span>\r\n                                                                                                            </div>\r\n                                                                                                        </div>\r\n                                                                                                    </td>\r\n                                                                                                    <td>\r\n                                                                                                        <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Thời gian bay</div>\r\n                                                                                                        <div style=\"font:bold 24px arial;text-align:center\">\r\n                                                                                                            <span style=\"color:#424242\">{{TongThoiGianKH}}</span>\r\n                                                                                                        </div>\r\n                                                                                                    </td>\r\n                                                                                                    <td>\r\n                                                                                                        <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Chỗ ngồi</div>\r\n                                                                                                        <div style=\"font:bold 24px arial;text-align:center\">\r\n                                                                                                            <span style=\"color:#424242\">{{ChoNgoiKH}}</span>\r\n                                                                                                        </div>\r\n                                                                                                    </td>\r\n                                                                                                    <td>\r\n                                                                                                        <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Nhóm</div>\r\n                                                                                                        <div style=\"font:bold 24px arial;text-align:center\">\r\n                                                                                                            <span style=\"color:#424242\"></span>\r\n                                                                                                        </div>\r\n                                                                                                    </td>\r\n                                                                                                    <td>\r\n                                                                                                        <div style=\"font:bold 10px arial,sans-serif;color:#656565;text-transform:uppercase\">Giờ có mặt tại cửa lên máy bay</div>\r\n                                                                                                        <div style=\"font:bold 24px arial;text-align:center\">\r\n                                                                                                            <span style=\"color:#389f08\">15:00</span>\r\n                                                                                                        </div>\r\n                                                                                                    </td>\r\n\r\n                                                                                                </tr>\r\n                                                                                            </tbody>\r\n                                                                                        </table>\r\n\r\n                                                                                    </div>\r\n\r\n                                                                                </div>";
                    content = content.Replace(phraseToHide, "");
                }
                checkOutService.sendEmail(email, "Vé máy bay từ Travelite", content);
            }
            var url = VnPayService.CreatePaymentUrl(objpayment.PaymentID, HttpContext);
            return Ok(new { status = true, message = "", data = url });
        }

        [HttpGet]
        [Route("searchTicket")]
        public async Task<IActionResult> searchTicket(string searchString)
        {
            try
            {
                List<Bookings> ticketList = await checkOutService.searchTicket(searchString);

                if (ticketList != null && ticketList.Count > 0)
                {
                    return Ok(new { status = true, message = "", searchTicket = ticketList });
                }
                else
                {
                    return Ok(new { status = false, message = "No results found", searchTicket = new List<Bookings>() });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = false, message = "Error processing the request", error = ex.Message });
            }
        }
    }
}