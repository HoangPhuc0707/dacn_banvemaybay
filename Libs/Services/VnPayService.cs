using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class VnPayService
    {
        private readonly IConfiguration _configuration;
        private readonly IpaymentsRepository paymentsRepository;
        private readonly IFlightsRepository flightsRepository;
        private ModelFlightContext modelFlightContext;
        public VnPayService(ModelFlightContext context,IConfiguration configuration)
        {
            modelFlightContext = context;
            paymentsRepository = new PaymentsRepository(context);
            _configuration = configuration;
            flightsRepository = new FlightsRepository(context);
        }
        public void saveChange()
        {
            modelFlightContext.SaveChanges();
        }
        public string CreatePaymentUrl(int paymentId, HttpContext context)
        {
            Payments payment = paymentsRepository.GetPayment(paymentId);
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            //var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"];

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)payment.PaymentAmount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang" + payment.PaymentID.ToString());
            pay.AddRequestData("vnp_OrderType", "other");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", payment.PaymentID.ToString());

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }
        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            string hashSecret = _configuration["Vnpay:HashSecret"];
            var pay = new VnPayLibrary();
            foreach (var (key, value) in collections)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    pay.AddResponseData(key, value);
                }
            }

            var orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef"));
            var vnPayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo"));
            var vnpResponseCode = pay.GetResponseData("vnp_ResponseCode");
            var vnpSecureHash =
                collections.FirstOrDefault(k => k.Key == "vnp_SecureHash").Value; //hash của dữ liệu trả về
            var orderInfo = pay.GetResponseData("vnp_OrderInfo");

            var checkSignature =
                pay.ValidateSignature(vnpSecureHash, hashSecret); //check Signature

            if (checkSignature)
            {
                if (vnpResponseCode == "00")
                {

                    Payments payment = paymentsRepository.GetPayment((int)orderId);
                    if (payment != null)
                    {
                        payment.PaymentMethod = true;//đã thanh toán
                        saveChange();
                    }
                    return new PaymentResponseModel()
                    {
                        Success = true,
                        PaymentMethod = "VnPay",
                        OrderDescription = orderInfo,
                        OrderId = orderId.ToString(),
                        PaymentId = vnPayTranId.ToString(),
                        TransactionId = vnPayTranId.ToString(),
                        Token = vnpSecureHash,
                        VnPayResponseCode = vnpResponseCode
                    };
                }
                else
                {
                    //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                    Payments payment = paymentsRepository.GetPayment((int)orderId);
                    if (payment != null)
                    {
                        // Kiểm tra trạng thái thanh toán
                        if (payment.PaymentMethod == false)
                        {
                            var bookings = modelFlightContext.Bookings.Where(m => m.PaymentID == payment.PaymentID);
                            modelFlightContext.Payments.Remove(payment);
                            foreach (var booking in bookings)
                            {
                                var Passenger = modelFlightContext.Passengers.Find(booking.PassengerID);
                                var seat = modelFlightContext.Seats.Find(booking.SeatID);
                                seat.SeatAvailable = 0;
                                if (Passenger != null)
                                {
                                    modelFlightContext.Passengers.Remove(Passenger);
                                }
                                flightsRepository.notChangeAvailableSeats(booking.FlightID);
                                modelFlightContext.Bookings.Remove(booking);
                            }
                            
                            modelFlightContext.SaveChanges();
                        }
                        return new PaymentResponseModel()
                        {
                            Success = false,
                            PaymentMethod = "VnPay",
                            OrderDescription = orderInfo,
                            OrderId = orderId.ToString(),
                            PaymentId = vnPayTranId.ToString(),
                            TransactionId = vnPayTranId.ToString(),
                            Token = vnpSecureHash,
                            VnPayResponseCode = vnpResponseCode
                        };
                    }
                }
                return new PaymentResponseModel()
                {
                    Success = true,
                    PaymentMethod = "VnPay",
                    OrderDescription = orderInfo,
                    OrderId = orderId.ToString(),
                    PaymentId = vnPayTranId.ToString(),
                    TransactionId = vnPayTranId.ToString(),
                    Token = vnpSecureHash,
                    VnPayResponseCode = vnpResponseCode
                };
            }
            else
            {
                return new PaymentResponseModel()
                {
                    Success = false,
                    PaymentMethod = "VnPay",
                    OrderDescription = orderInfo,
                    OrderId = orderId.ToString(),
                    PaymentId = vnPayTranId.ToString(),
                    TransactionId = vnPayTranId.ToString(),
                    Token = vnpSecureHash,
                    VnPayResponseCode = vnpResponseCode
                };
            }
           
        }
    }
}
