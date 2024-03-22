using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IFlightsRepository : IRepository<Flights>
    {
        Task<List<Flights>> FindAirport(string departureCode, string arriveCode, string ngayden, int availableSeats);
        Task<List<Flights>> FlightSelection(int id);
        Task changeAvailableSeats(int flightId);
        Task notChangeAvailableSeats(int flightId);
        Task<PageList<Flights>> GetAll(PagingParameters pagingParameters);
        Task<PageList<Flights>> SearchFlight(string keySearch, PagingParameters pagingParameters);
        Task<List<Flights>> GetFlights(int id);
        Task AddFlight(Flights flights);
        Task<Flights> GetFlightNumber();
        Task UpdateFlight(int id, Flights flight);
        Task DeleteFlight(int id);
    }
    public class FlightsRepository : RepositoryBase<Flights>,IFlightsRepository
    {
        public FlightsRepository(ModelFlightContext dbcontext) : base(dbcontext)
        {
        }
        public async Task<List<Flights>> FindAirport(string departureCode, string arriveCode, string ngayden,int availableSeats)
        {
            DateTime departureDay = DateTime.ParseExact(ngayden, "dd/M/yyyy", CultureInfo.InvariantCulture);
            return await _dbContext.Flights.Where(m => m.Airports1.AirportCode.Contains(departureCode) && m.Airports.AirportCode.Contains(arriveCode)).Where(m =>m.DepartureDay == departureDay)
                                           .Where(m => m.AvailableSeats >= availableSeats).Include(m=>m.Airports).Include(m => m.Airports1)
                                           .Include(m => m.Fares).Include(m => m.Bookings).Include(m => m.Seats).AsSingleQuery().ToListAsync() ;
        }
        public async Task<List<Flights>> FlightSelection(int id)
        {
            return await _dbContext.Flights.Where(m => m.FlightID == id).Include(m => m.Airports).Include(m => m.Airports1).Include(m => m.Fares).Include(m => m.Bookings).Include(m => m.Seats).ToListAsync() ;
        }
        public async Task changeAvailableSeats(int flightId)
        {
            var flight = await _dbContext.Flights.FindAsync(flightId);
            if(flight != null)
            {
                flight.AvailableSeats--;
            }
        }
        public async Task notChangeAvailableSeats(int flightId)
        {
            var flight = await _dbContext.Flights.FindAsync(flightId);
            if(flight != null)
            {
                flight.AvailableSeats++;
            }
        }
        public async Task<PageList<Flights>> GetAll(PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Flights>.GetPagedList(_dbContext.Flights.Include(m => m.AspNetUser).Include(m => m.Airports).Include(m => m.Airports1).Include(m => m.Fares).OrderBy(s => s.FlightID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<PageList<Flights>> SearchFlight(string keySearch, PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Flights>.GetPagedList(_dbContext.Flights.Where(m => m.FlightNumber.Contains(keySearch)).OrderBy(s => s.FlightID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<List<Flights>> GetFlights(int id)
        {
            return await _dbContext.Flights.Where(m =>m.FlightID==id).Include(m => m.AspNetUser).Include(m => m.Airports).Include(m => m.Airports1).Include(m => m.Fares).ToListAsync();
        }
        public async Task AddFlight(Flights flights)
        {
            await _dbContext.Flights.AddAsync(flights);
        }
        public async Task<Flights> GetFlightNumber()
        {
            return await _dbContext.Flights.OrderByDescending(m => m.FlightNumber).FirstOrDefaultAsync();
        }
        public async Task UpdateFlight(int id, Flights flight)
        {
            var flights1 = await _dbContext.Flights.FirstOrDefaultAsync(m => m.FlightID == id);
            if (flights1 != null)
            {
                flights1.DepartureDay = flight.DepartureDay;
                flights1.ArrivalTime = flight.ArrivalTime;
                flights1.DepartureTime = flight.DepartureTime;
                flights1.ArrivlaCity = flight.ArrivlaCity;
                flights1.DepartureCity = flight.DepartureCity;
                flights1.HinhAnh = flight.HinhAnh;
                flights1.created_by = flight.created_by;
            }
        }
        public async Task DeleteFlight(int id)
        {
            var flight = await _dbContext.Flights.FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight != null)
            {
                _dbContext.Flights.Remove(flight);
            }
        }
    }
}
