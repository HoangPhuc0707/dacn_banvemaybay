using Libs.EF;
using Libs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface ITokenRepository : IRepository<RefeshToken>
    {
        Task AddTokenAsync(RefeshToken token);
        Task SaveTokenAsync();
        Task UpdateTokenAsync(RefeshToken token);
    }
    public class TokenRepository : RepositoryBase<RefeshToken>, ITokenRepository
    {
        public TokenRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }

        public async Task AddTokenAsync(RefeshToken token)
        {
            await _dbContext.RefeshToken.AddAsync(token);
        }
        public async Task SaveTokenAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateTokenAsync(RefeshToken token)
        {
            _dbContext.RefeshToken.Update(token);
            await _dbContext.SaveChangesAsync();
        }

    }
}
