using Libs.EF;
using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface ISeatsRepository : IRepository<Seats>
    {
        Task<List<Seats>> GetAllSeats(int flightID);
        Task<List<Seats>> SeatSelect(int flightID, List<string> seatNumbers);
        Task ChangeSeat_1(int flightID, string seatNumbers);
        Task AddSeat(Seats seat);
        Task DeleteSeat(int id);
    }
    public class SeatsRepository : RepositoryBase<Seats>, ISeatsRepository
    {
        public SeatsRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Seats>> GetAllSeats(int flightID)
        {
            return await _dbContext.Seats.Where(m => m.FlightID == flightID).ToListAsync();
        }
        public async Task<List<Seats>> SeatSelect(int flightID, List<string> seatNumbers)
        {
            return await _dbContext.Seats.Where(m => m.FlightID == flightID && seatNumbers.Contains(m.SeatNumber)).ToListAsync();
        }
        //public async Task<Seats> findSeat(int flightId, string seatNumbers)
        //{
        //    return await _dbContext.Seats.FirstOrDefaultAsync(m => m.FlightID == flightId && seatNumbers == seatNumbers);
        //}
        public async Task ChangeSeat_1(int flightID, string seatNumbers)
        {
            var firstseat = await _dbContext.Seats.FirstOrDefaultAsync(m => m.FlightID == flightID && m.SeatNumber == seatNumbers);
            firstseat.SeatAvailable = 1;
        }
        public async Task AddSeat(Seats seat)
        {
            await _dbContext.Seats.AddAsync(seat);
        }
        public async Task DeleteSeat(int id)
        {
            var seats = await _dbContext.Seats.Where(m => m.FlightID == id).ToListAsync();
            if(seats != null)
            {
               _dbContext.Seats.RemoveRange(seats);
            }
            
        }
    }
}
