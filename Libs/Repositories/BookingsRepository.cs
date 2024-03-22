using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IBookingsRepository : IRepository<Bookings>
    {
        Task insertBooking(Bookings bookings);
        Task<List<Bookings>> searchTicket(string searchString);
        Task<PageList<Bookings>> GetAll(PagingParameters pagingParameters);
        Task<PageList<Bookings>> SearchBooking(string keySearch, PagingParameters pagingParameters);
        Task<List<Bookings>> GetBooking(int id);
        Task UpdateBooking(int id, Bookings bookings);
        Task DeleteBooking(int id);
    }
    public class BookingsRepository : RepositoryBase<Bookings>, IBookingsRepository
    {
        public BookingsRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task insertBooking(Bookings bookings)
        {
            await _dbContext.Bookings.AddAsync(bookings);
        }
        public async Task<List<Bookings>> searchTicket(string searchString)
        {
            return await _dbContext.Bookings.Where(m => m.Verification == searchString).Include(m => m.Flights).Include(m => m.Flights.Airports).Include(m => m.Flights.Airports1).Include(m => m.Passengers).Include(m => m.Seats).ToListAsync();
        }
        public async Task<PageList<Bookings>> GetAll(PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Bookings>.GetPagedList(_dbContext.Bookings.Include(m => m.Flights).Include(m => m.Flights.Airports).Include(m => m.Flights.Airports1).Include(m => m.Passengers).Include(m => m.Seats).Include(m => m.Payments).OrderBy(s => s.BookingID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<PageList<Bookings>> SearchBooking(string keySearch, PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Bookings>.GetPagedList(_dbContext.Bookings.Where(m => m.Passengers.FullName.Contains(keySearch)).Include(m => m.Flights).Include(m => m.Flights.Airports).Include(m => m.Flights.Airports1).Include(m => m.Passengers).Include(m => m.Seats).Include(m => m.Payments).OrderBy(s => s.BookingID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<List<Bookings>> GetBooking(int id)
        {
            return await _dbContext.Bookings.Where(m => m.BookingID == id).Include(m => m.Flights).Include(m => m.Flights.Seats).Include(m => m.Flights.Airports).Include(m => m.Flights.Airports1).Include(m => m.Passengers).Include(m => m.Seats).Include(m => m.Payments).ToListAsync();
        }
        public async Task UpdateBooking(int id, Bookings bookings)
        {
            var bookings1 = await _dbContext.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);
            if (bookings1 != null)
            {
                var newSeat = await _dbContext.Seats.FirstOrDefaultAsync(s => s.SeatID == bookings.SeatID);
                if(newSeat != null)
                {
                    newSeat.SeatAvailable = 1;
                }
                var oldSeat = await _dbContext.Seats.FirstOrDefaultAsync(s => s.SeatID == bookings1.SeatID && s.FlightID == bookings1.FlightID);
                if (oldSeat != null)
                {
                    oldSeat.SeatAvailable = 0;
                }
                bookings1.BookingDate = DateTime.Now;
                bookings1.SeatID = bookings.SeatID;
            }
        }
        public async Task DeleteBooking(int id)
        {
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
            }
        }
    }
}
