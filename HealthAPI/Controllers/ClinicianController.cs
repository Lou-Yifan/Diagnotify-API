using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HealthAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HealthPolicy")]
    public class ClinicianController : ControllerBase
    {
        private readonly HealthContext _context;

        public ClinicianController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/Clinician
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinician>>> GetClinicians()
        {
            return await _context.Clinicians.ToListAsync();
        }

        // GET: api/Clinician/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinician>> GetClinician(string id)
        {
            var clinician = await _context.Clinicians.FindAsync(id);

            if (clinician == null)
            {
                return NotFound();
            }

            return clinician;
        }

        // GET: api/Clinician/Email/5
        [HttpGet("Email/{email}")]
        public async Task<List<Clinician>> GetCliniciansByEmail(string email)
        {
            return await _context.Clinicians
                .Where(c => c.Email == email).ToListAsync();
        }


        // PUT: api/Clinician/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinician(string id, Clinician clinician)
        {
            if (id != clinician.ClinicianId)
            {
                return BadRequest();
            }

            _context.Entry(clinician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicianExists(id))
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

        // POST: api/Clinician
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Clinician>> PostClinician(Clinician clinician)
        {
            _context.Clinicians.Add(clinician);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClinicianExists(clinician.ClinicianId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClinician", new { id = clinician.ClinicianId }, clinician);
        }

        // DELETE: api/Clinician/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clinician>> DeleteClinician(string id)
        {
            var clinician = await _context.Clinicians.FindAsync(id);
            if (clinician == null)
            {
                return NotFound();
            }

            _context.Clinicians.Remove(clinician);
            await _context.SaveChangesAsync();

            return clinician;
        }

        private bool ClinicianExists(string id)
        {
            return _context.Clinicians.Any(e => e.ClinicianId == id);
        }
    }
}
