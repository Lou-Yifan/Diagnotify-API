using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;

namespace HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationController : ControllerBase
    {
        private readonly HealthContext _context;

        public ObservationController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/Observation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Observation>>> GetObservations()
        {
            return await _context.Observations.ToListAsync();
        }

        // GET: api/Observation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Observation>> GetObservation(string id)
        {
            var observation = await _context.Observations.FindAsync(id);

            if (observation == null)
            {
                return NotFound();
            }

            return observation;
        }

        // PUT: api/Observation/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObservation(string id, Observation observation)
        {
            if (id != observation.ObservationId)
            {
                return BadRequest();
            }

            _context.Entry(observation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservationExists(id))
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

        // POST: api/Observation
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Observation>> PostObservation(Observation observation)
        {
            _context.Observations.Add(observation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ObservationExists(observation.ObservationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetObservation", new { id = observation.ObservationId }, observation);
        }

        // DELETE: api/Observation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Observation>> DeleteObservation(string id)
        {
            var observation = await _context.Observations.FindAsync(id);
            if (observation == null)
            {
                return NotFound();
            }

            _context.Observations.Remove(observation);
            await _context.SaveChangesAsync();

            return observation;
        }

        private bool ObservationExists(string id)
        {
            return _context.Observations.Any(e => e.ObservationId == id);
        }
    }
}
