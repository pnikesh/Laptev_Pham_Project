using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laptev_Pham_Project.Models;

namespace Laptev_Pham_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalCitiesController : ControllerBase
    {
        private readonly FlightsDBContext _context;

        public ArrivalCitiesController(FlightsDBContext context)
        {
            _context = context;
        }

        // GET: api/ArrivalCities
        [HttpGet]
        public IEnumerable<ArrivalCity> GetArrivalCity()
        {
            return _context.ArrivalCity;
        }

        // GET: api/ArrivalCities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArrivalCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrivalCity = await _context.ArrivalCity.FindAsync(id);

            if (arrivalCity == null)
            {
                return NotFound();
            }

            return Ok(arrivalCity);
        }

        // PUT: api/ArrivalCities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrivalCity([FromRoute] int id, [FromBody] ArrivalCity arrivalCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arrivalCity.ID)
            {
                return BadRequest();
            }

            _context.Entry(arrivalCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrivalCityExists(id))
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

        // POST: api/ArrivalCities
        [HttpPost]
        public async Task<IActionResult> PostArrivalCity([FromBody] ArrivalCity arrivalCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ArrivalCity.Add(arrivalCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArrivalCity", new { id = arrivalCity.ID }, arrivalCity);
        }

        // DELETE: api/ArrivalCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrivalCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrivalCity = await _context.ArrivalCity.FindAsync(id);
            if (arrivalCity == null)
            {
                return NotFound();
            }

            _context.ArrivalCity.Remove(arrivalCity);
            await _context.SaveChangesAsync();

            return Ok(arrivalCity);
        }

        private bool ArrivalCityExists(int id)
        {
            return _context.ArrivalCity.Any(e => e.ID == id);
        }
    }
}