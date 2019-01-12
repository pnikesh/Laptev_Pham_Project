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
    public class DepartureCitiesController : ControllerBase
    {
        private readonly FlightsDBContext _context;

        public DepartureCitiesController(FlightsDBContext context)
        {
            _context = context;
        }

        // GET: api/DepartureCities
        [HttpGet]
        public IEnumerable<DepartureCity> GetDepartureCity()
        {
            return _context.DepartureCity;
        }

        // GET: api/DepartureCities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartureCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departureCity = await _context.DepartureCity.FindAsync(id);

            if (departureCity == null)
            {
                return NotFound();
            }

            return Ok(departureCity);
        }

        // PUT: api/DepartureCities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartureCity([FromRoute] int id, [FromBody] DepartureCity departureCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departureCity.ID)
            {
                return BadRequest();
            }

            _context.Entry(departureCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartureCityExists(id))
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

        // POST: api/DepartureCities
        [HttpPost]
        public async Task<IActionResult> PostDepartureCity([FromBody] DepartureCity departureCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DepartureCity.Add(departureCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartureCity", new { id = departureCity.ID }, departureCity);
        }

        // DELETE: api/DepartureCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartureCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departureCity = await _context.DepartureCity.FindAsync(id);
            if (departureCity == null)
            {
                return NotFound();
            }

            _context.DepartureCity.Remove(departureCity);
            await _context.SaveChangesAsync();

            return Ok(departureCity);
        }

        private bool DepartureCityExists(int id)
        {
            return _context.DepartureCity.Any(e => e.ID == id);
        }
    }
}