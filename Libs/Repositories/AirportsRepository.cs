using DemoMayBayCN.Areas.Admin.ModelView;
using Libs.EF;
using Libs.Entity;
using Libs.ModelViews;
using Microsoft.EntityFrameworkCore;

namespace Libs.Repositories
{
    public interface IAirportsRepository : IRepository<Airports>
    {
        Task<List<Airports>> GetAllAirport();
        Task<PageList<Airports>> GetAll(PagingParameters pagingParameters);
        Task<PageList<Airports>> SearchAirport(string keySearch, PagingParameters pagingParameters);
        Task<Airports?> GetAirport(int id);
        Task AddAirport(Airports airports);
        Task UpdateAirport(int id, Airports airports);
        Task DeleteAirport(int id);
    }
    public class AirportsRepository : RepositoryBase<Airports>, IAirportsRepository
    {
        public AirportsRepository(ModelFlightContext dbcontext) : base(dbcontext)
        {
        } 
        public async Task<List<Airports>> GetAllAirport()
        {
            return await _dbContext.Airports.ToListAsync();
        }
        public async Task<PageList<Airports>> GetAll(PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Airports>.GetPagedList(_dbContext.Airports.OrderBy(s => s.AirportID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<PageList<Airports>> SearchAirport(string keySearch, PagingParameters pagingParameters)
        {
            return await Task.FromResult(PageList<Airports>.GetPagedList(_dbContext.Airports.Where(m => m.City.Contains(keySearch)).OrderBy(s => s.AirportID), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
        public async Task<Airports?> GetAirport(int id)
        {
            return await _dbContext.Airports.FindAsync(id);
        }
        public async Task AddAirport(Airports airports)
        {
             await _dbContext.Airports.AddAsync(airports);
        }

        public async Task UpdateAirport(int id,Airports airports)
        {
            var airports1 = await _dbContext.Airports.FirstOrDefaultAsync(m => m.AirportID == id);
            if (airports1 != null)
            {
                airports1.AirportCode = airports.AirportCode;
                airports1.AirportName = airports.AirportName;
                airports1.City = airports.City;
            }
           
        }
        public async Task DeleteAirport(int id)
        {
            var airPort = await _dbContext.Airports.FirstOrDefaultAsync(m => m.AirportID == id);
            if(airPort != null)
            {
                _dbContext.Airports.Remove(airPort);
            }
        }
    }
}
