using Libs.EF;
using Libs.Entity;
using Libs.Repositories;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;

namespace Libs.Services
{
    public class CheckOutService
    {
        private ModelFlightContext modelFlightContext;
        private IFlightsRepository flightsRepository;
        private ISeatsRepository seatsRepository;
        private IpaymentsRepository paymentsRepository;
        private IPassengerRepository passengerRepository;
        private IBookingsRepository bookingsRepository;
        public readonly IConfiguration _config;
        public CheckOutService(ModelFlightContext context,IConfiguration config)
        {
            this.modelFlightContext = context;
            flightsRepository = new FlightsRepository(context);
            seatsRepository= new SeatsRepository(context);
            paymentsRepository = new PaymentsRepository(context);
            passengerRepository = new PassengersRepository(context);
            bookingsRepository = new BookingsRepository(context);
            _config = config;
        }
        public async Task saveChange()
        {
            await modelFlightContext.SaveChangesAsync();
        }
        public async Task<List<Flights>> FlightSelection(int id)
        {
            return await flightsRepository.FlightSelection(id);
        }
        public async Task<List<Seats>> SeatSelect(int flightId, List<string> seatNumbers)
        {
            return await seatsRepository.SeatSelect(flightId, seatNumbers);
        }
        public async Task insertPayment(Payments payments)
        {
            await paymentsRepository.insertPayment(payments);
            await saveChange();
        }
        public async Task insertPassenger(Passengers passengers)
        {
            await passengerRepository.addPassenger(passengers);
            await saveChange();
        }
        public async Task ChangeSeat_1(int flightID, string seatNumbers)
        {
            await seatsRepository.ChangeSeat_1(flightID,seatNumbers);
            await flightsRepository.changeAvailableSeats(flightID);
            await saveChange();
        }
        public async Task NotChangeSeat(int flightID)
        {
            await flightsRepository.notChangeAvailableSeats(flightID);
            await saveChange();
        }
        public async  Task insertBooking(Bookings bookings)
        {
            await bookingsRepository.insertBooking(bookings);
            await saveChange();
        }
        public async Task<List<Bookings>> searchTicket(string searchString)
        {
            return await bookingsRepository.searchTicket(searchString);
        }
        public void sendEmail(string To, string Subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(To));
            email.Subject = Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
