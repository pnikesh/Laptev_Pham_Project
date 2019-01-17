using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laptev_Pham_Project.Models;
using Microsoft.AspNetCore.Cors;

namespace Laptev_Pham_Project.Controllers
{
    [EnableCors()]

    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightsDBContext _context;

        public FlightsController(FlightsDBContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public IEnumerable<Flight> GetFlight()
        {
            return _context.Flight;
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }


        // GET: api/Flights?departCity=DeptCity
        [HttpGet]
        [Route("GetLFlightsByDepartureCity")]
        public async Task<IEnumerable<Flight>> GetFlightByDepartCity([FromQuery] string departCity)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

           //var flight = await _context.Flight.Where(departCity);

            var flights =  await Task.FromResult(_context.Flight.Where(x => x.DepartureCity == departCity));

            if (flights == null)
            {
                return null;
            }

            return flights;
        }


        // GET: api/Flights/GetFlightsByCities?departCity=DeptCity&arrCity=ArrCity
        [HttpGet]
        [Route("GetFlightsByCities")]
        public async Task <IEnumerable<Flight>> GetFlightByDepartCityAndArrCity([FromQuery] string departCity, [FromQuery] string arrCity)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            //var flight = await _context.Flight.FindAsync(departCity);

            var flights = await Task.FromResult(_context.Flight.Where(x => x.DepartureCity == departCity).Where(y => y.ArrivalCity == arrCity));

            if (flights == null)
            {
                //string str = "No such flights found";
                //IEnumerable<string> strings = null //new IEnumerable<string>();
                //strings.Append(str);
                return null;

            }

            return flights;
        }


        // GET: api/Flights/GetFlightsByCitiesAndPrice?departCity=DeptCity&arrCity=ArrCity&maxPrice=Price
        [HttpGet]
        [Route("GetFlightsByCitiesAndPrice")]
        public async Task <IEnumerable<Flight>> GetFlightByDepartCityAndArrCityAndMaxPrice([FromQuery] string departCity, [FromQuery] string arrCity, [FromQuery] int maxPrice)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            //var flight = await _context.Flight.FindAsync(departCity);

            var flights = await Task.FromResult(_context.Flight.Where(x => x.DepartureCity == departCity).Where(y => y.ArrivalCity == arrCity)
                 .Where(z=>z.TicketPrice <= maxPrice));

            if (flights == null)
            {
                //string str = "No such flights found";
                //IEnumerable<string> strings = null //new IEnumerable<string>();
                //strings.Append(str);
                return null;

            }

            return flights;
        }

        // GET: api/Flights/GetDirectFlights?departCity=DeptCity&arrCity=ArrCity&direct=true
        [HttpGet]
        [Route("GetDirectFlights")]
        public async Task <IEnumerable<Flight>> GetFlightByDepartCityAndArrCityAndDirect([FromQuery] string departCity, [FromQuery] string arrCity, [FromQuery] bool direct)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            //var flight = await _context.Flight.FindAsync(departCity);

            var flights = await Task.FromResult(_context.Flight.Where(x => x.DepartureCity == departCity)
                    .Where(y => y.ArrivalCity == arrCity).Where(z => z.Direct));
            if (flights == null)
            {
                //string str = "No such flights found";
                //IEnumerable<string> strings = null //new IEnumerable<string>();
                //strings.Append(str);
                return null;

            }

            return flights;
        }


        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight([FromRoute] int id, [FromBody] Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.ID)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        [HttpPost]
        public async Task<IActionResult> PostFlight([FromBody] Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Flight.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.ID }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();

            return Ok(flight);
        }
        //test
        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.ID == id);
        }
    }
}