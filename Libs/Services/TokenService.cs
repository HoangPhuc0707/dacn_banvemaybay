using Libs.EF;
using Libs.Entity;
using Libs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class TokenService
    {
        private ITokenRepository tokenRepository;
        public TokenService(ModelFlightContext applicationDbContext)
        {
            this.tokenRepository = new TokenRepository(applicationDbContext);
        }
        public async Task AddTokenAsync(RefeshToken token)
        {
            await tokenRepository.AddTokenAsync(token);
        }
        public async Task SaveTokenAsync()
        {
            await tokenRepository.SaveTokenAsync();
        }
        public async Task UpdateToken(RefeshToken token)
        {
            await tokenRepository.UpdateTokenAsync(token);
        }
    }
}
