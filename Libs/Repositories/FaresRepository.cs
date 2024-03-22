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
    public interface IFaresRepository: IRepository<Fares>
    {
        Task AddFares(List<Fares> fares);
        Task updateFares(List<Fares> fares);
        Task deleteFares(int id);
    }
    public class FaresRepository:RepositoryBase<Fares>, IFaresRepository
    {
        public FaresRepository(ModelFlightContext dbcontext):base(dbcontext)
        {

        }
        public async Task AddFares(List<Fares> fares)
        {
            foreach(var fare in fares)
            {
                await _dbContext.Fares.AddAsync(fare);
            }
        }
        public async Task updateFares(List<Fares> fares)
        {
            foreach (var fare in fares)
            {
                var existingFare = await _dbContext.Fares
                .FirstOrDefaultAsync(f => f.FlightID == fare.FlightID && f.FareType == fare.FareType);
                if (existingFare != null)
                {
                    existingFare.FareAmount = fare.FareAmount;
                }
            }
        }
        public async Task deleteFares(int id) 
        {
            var fares = await _dbContext.Fares.FindAsync(id);
            if (fares != null)
            {
                _dbContext.Fares.Remove(fares);
            }
            
        }
    }
}
