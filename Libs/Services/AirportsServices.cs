using Libs.EF;
using Libs.Entity;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class AirportsServices
    {
        private IAirportsRepository airportsRepository;
        public AirportsServices(ModelFlightContext context)
        {
            airportsRepository= new AirportsRepository(context);
        }

        public async Task<List<Airports>> GetAirports()
        {
            return await airportsRepository.GetAllAirport();
        }
    }
}
