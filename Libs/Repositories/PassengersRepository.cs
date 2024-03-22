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
    public interface IPassengerRepository : IRepository<Passengers>
    {
        Task<List<Passengers>> GetAllPassenger();
        Task<PageList<Passengers>> GetAll(PagingParameters pagingParameters);
        Task<PageList<Passengers>> SearchPassenger(string keySearch, PagingParameters pagingParameters);
        Task<Passengers?> GetPassenger(int id);
        Task addPassenger(Passengers passengers);
        Task UpdatePassenger(int id, Passengers Passenger);
        Task DeletePassenger(int id);
    }
    public class PassengersRepository : RepositoryBase<Passengers>, IPassengerRepository
    {
        public PassengersRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Passengers>> GetAllPassenger()
        {
            return await _dbContext.Passengers.ToListAsync();
        }
        public async Task<PageList<Passengers>> GetAll(PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Passengers>.GetPagedList(_dbContext.Passengers.OrderBy(s => s.PassengerID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<PageList<Passengers>> SearchPassenger(string keySearch, PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Passengers>.GetPagedList(_dbContext.Passengers.Where(m => m.FullName.Contains(keySearch)).OrderBy(s => s.PassengerID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<Passengers?> GetPassenger(int id)
        {
            return await _dbContext.Passengers.FindAsync(id);
        }
        public async Task addPassenger(Passengers passengers)
        {
            await _dbContext.AddAsync(passengers);
        }
        public async Task UpdatePassenger(int id, Passengers Passenger)
        {
            var Passengers1 = await _dbContext.Passengers.FirstOrDefaultAsync(m => m.PassengerID == id);
            if (Passengers1 != null)
            {
                Passengers1.FullName = Passenger.FullName;
                Passengers1.Phone = Passenger.Phone;
                Passengers1.Email = Passenger.Email;
                Passengers1.Gender = Passenger.Gender;
                Passengers1.NgaySinh = Passenger.NgaySinh;
                Passengers1.Address = Passenger.Address;
            }

        }
        public async Task DeletePassenger(int id)
        {
            var Passenger = await _dbContext.Passengers.FirstOrDefaultAsync(m => m.PassengerID == id);
            if (Passenger != null)
            {
                _dbContext.Passengers.Remove(Passenger);
            }

        }
    }
}
