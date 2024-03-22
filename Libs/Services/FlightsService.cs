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
    public class FlightsService 
    {
        private IFlightsRepository flightsRepository;
        private IAirportsRepository airportsRepository;
        private ISeatsRepository seatsRepository;
        public FlightsService(ModelFlightContext context)
        {
            flightsRepository = new FlightsRepository(context);
            airportsRepository = new AirportsRepository(context);
            seatsRepository= new SeatsRepository(context);
        }
        public async Task<List<Airports>> GetAirports()
        {
            return await airportsRepository.GetAllAirport();
        }
        public async Task<List<Flights>> FindAirport(string deparuteCode, string arriveCode, string departureDay,int availableSeats)
        {
            return await flightsRepository.FindAirport(deparuteCode, arriveCode, departureDay, availableSeats);
        }
        public async Task<List<Seats>> GetAllSeats(int flightID)
        {
            return await seatsRepository.GetAllSeats(flightID);
        }
    }
}
