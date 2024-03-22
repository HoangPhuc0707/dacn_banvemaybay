using Libs.Entity;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMayBayCN.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        public FlightsService flightsService;
        public FlightsController(FlightsService flightsService)
        {
            this.flightsService = flightsService;
        }
        [HttpGet]
        [Route("GetAirport")]
        public async Task<IActionResult> GetAirport()
        {
            List<Airports> airportsList = await flightsService.GetAirports();
            return Ok(new { status = true, message = "", data = airportsList });
        }
        [HttpGet]
        [Route("FlightSearch")]
        public async Task<IActionResult> FlightSearch(string departureCode,string arriveCode, string departureDay,int availableSeats)
        {
            List<Flights> list = await flightsService.FindAirport(departureCode, arriveCode, departureDay, availableSeats);
            return Ok(new { status = true, message = "", data=list });
        }    
        [HttpGet]
        [Route("FlightSearchReturn")]
        public async Task<IActionResult> FlightSearchReturn(string departureCode, string arriveCode, string arrivalDay, int availableSeats)
        {
            List<Flights> list = await flightsService.FindAirport(arriveCode, departureCode, arrivalDay, availableSeats);
            return Ok(new { status = true, message = "", data = list });
        }
    }
}
