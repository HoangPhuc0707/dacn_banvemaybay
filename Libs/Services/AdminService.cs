using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class AdminService
    {
        public IAirportsRepository airportsRepository;
        public IPassengerRepository passengerRepository;
        public IBookingsRepository bookingsRepository;
        public ISeatsRepository seatsRepository;
        public IFlightsRepository flightsRepository;
        public IFaresRepository faresRepository;
        private ModelFlightContext modelFlightContext;
        public AdminService(ModelFlightContext context)
        {
            modelFlightContext = context;
            airportsRepository = new AirportsRepository(context);
            passengerRepository = new PassengersRepository(context);
            bookingsRepository = new BookingsRepository(context);
            seatsRepository = new SeatsRepository(context);
            flightsRepository = new FlightsRepository(context);
            faresRepository = new FaresRepository(context);
        }
        public async Task SaveChange()
        {
            await modelFlightContext.SaveChangesAsync();
        }
        //Airport
        public async Task<PageList<Airports>> GetAll(PagingParameters pagingParameters)
        {
            return await airportsRepository.GetAll(pagingParameters);
        }
        public async Task<PageList<Airports>> SearchAirport(string keySearch, PagingParameters pagingParameters)
        {
            return await airportsRepository.SearchAirport(keySearch, pagingParameters);
        }
        public async Task<List<Airports>> getAllAirport()
        {
            return await airportsRepository.GetAllAirport();
        }
        public async Task<Airports?> GetAirport(int id)
        {
            return await airportsRepository.GetAirport(id);
        }
        public async Task addAirport(Airports airports)
        {
            await airportsRepository.AddAirport(airports);
            await SaveChange();
        }
        public async Task UpdateAirport(int id, Airports airports)
        {
            await airportsRepository.UpdateAirport(id,airports);
            await SaveChange();
        }
        public async Task DeleteAirport(int id)
        {
            await airportsRepository.DeleteAirport(id);
            await SaveChange();
        }
        //Passenger
        public async Task<PageList<Passengers>> GetAllPassengers(PagingParameters pagingParameters)
        {
            return await passengerRepository.GetAll(pagingParameters);
        }
        public async Task<PageList<Passengers>> SearchPassengers(string keySearch, PagingParameters pagingParameters)
        {
            return await passengerRepository.SearchPassenger(keySearch, pagingParameters);
        }
        public async Task<Passengers?> GetPassengers(int id)
        {
            return await passengerRepository.GetPassenger(id);
        }
        public async Task addPassengers(Passengers airports)
        {
            await passengerRepository.addPassenger(airports);
            await SaveChange();
        }
        public async Task UpdatePassengers(int id, Passengers airports)
        {
            await passengerRepository.UpdatePassenger(id, airports);
            await SaveChange();
        }
        public async Task DeletePassengers(int id)
        {
            await passengerRepository.DeletePassenger(id);
            await SaveChange();
        }
        //Booking
        public async Task<PageList<Bookings>> GetAllBookings(PagingParameters pagingParameters)
        {
            return await bookingsRepository.GetAll(pagingParameters);
        }
        public async Task<PageList<Bookings>> SearchBookings(string keySearch, PagingParameters pagingParameters)
        {
            return await bookingsRepository.SearchBooking(keySearch, pagingParameters);
        }
        public async Task<List<Bookings>> GetBookings(int id)
        {
            return await bookingsRepository.GetBooking(id);
        }
        public async Task UpdateBookings(int id, Bookings bookings)
        {
            await bookingsRepository.UpdateBooking(id, bookings);
            await SaveChange();
        }
        public async Task DeleteBookings(int id)
        {
            await bookingsRepository.DeleteBooking(id);
            await SaveChange();
        }
        //Flights
        public async Task<PageList<Flights>> GetAllFlights(PagingParameters pagingParameters)
        {
            return await flightsRepository.GetAll(pagingParameters);
        }
        public async Task<PageList<Flights>> SearchFlights(string keySearch, PagingParameters pagingParameters)
        {
            return await flightsRepository.SearchFlight(keySearch, pagingParameters);
        }
        public async Task<List<Flights>> GetFlights(int id)
        {
            return await flightsRepository.GetFlights(id);
        }
        public async Task addFlights(Flights flights)
        {
            await flightsRepository.AddFlight(flights);
            await SaveChange();
        }
        public async Task<Flights> GetFlightNumber()
        {
            return  await flightsRepository.GetFlightNumber();
        }
        public async Task UpdateFlights(int id, Flights flights)
        {
            await flightsRepository.UpdateFlight(id, flights);
            await SaveChange();
        }
        public async Task deleteFlight(int id)
        {
            await flightsRepository.DeleteFlight(id);
            await SaveChange();
        }
        //Seats
        public async Task addSeats(Seats seats)
        {
            await seatsRepository.AddSeat(seats);
            await SaveChange();
        }
        public async Task deleteSeats(int id)
        {
            await seatsRepository.DeleteSeat(id);
            await SaveChange();
        }
        //Fares
        public async Task addFares(List<Fares> fares)
        {
            if (fares != null)
            {
                await faresRepository.AddFares(fares);
                await SaveChange();
            }
        }
        public async Task updateFares(List<Fares> fares)
        {
            await faresRepository.updateFares(fares);
            await SaveChange();
        }
        public async Task deleteFares(int id)
        {
            await faresRepository.deleteFares(id); 
            await SaveChange();
        }
    }
}
