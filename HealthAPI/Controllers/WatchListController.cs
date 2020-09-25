using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace HealthAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("HealthPolicy")]
    public class WatchListController : ControllerBase
    {
        private readonly HealthContext _context;

        public WatchListController(HealthContext context)
        {
            _context = context;
        }

        // Get all the watchList
        // GET: api/WatchList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchList>>> GetWatchLists()
        {
            return await _context.WatchLists.ToListAsync();
        }

        // Get watchlist by Id
        // GET: api/WatchList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchList>> GetWatchList(int id)
        {
            var watchList = await _context.WatchLists.FindAsync(id);

            if (watchList == null)
            {
                return NotFound();
            }

            return watchList;
        }

        // Get all watchList by userId
        // GET: api/WatchList/Clinician/clinicianId
        [HttpGet("Clinician/{clinicianId}")]
        public async Task<List<WatchList>> GetAppointmentByPatient(string clinicianId)
        {
            return await _context.WatchLists
                .Where(p => p.ClinicianId == clinicianId).ToListAsync();
        }

        // PUT: api/WatchList/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchList(int id, WatchList watchList)
        {
            if (id != watchList.WatchListId)
            {
                return BadRequest();
            }

            _context.Entry(watchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListExists(id))
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

        // POST: api/WatchList
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WatchList>> PostWatchList(WatchList watchList)
        {
            // Check if row is already exist
            var item = _context.WatchLists.Where(p => p.ClinicianId.Equals(watchList.ClinicianId) && p.PatientId.Equals(watchList.PatientId)).FirstOrDefault();
            if (item != null)
            {
                return NotFound();
            }

            _context.WatchLists.Add(watchList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchList", new { id = watchList.WatchListId }, watchList);
        }


        // DELETE: api/WatchList/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WatchList>> DeleteWatchList(int id)
        {
            var watchList = await _context.WatchLists.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }

            _context.WatchLists.Remove(watchList);
            await _context.SaveChangesAsync();

            return watchList;
        }

        // DELETE: api/WatchList/Patient/
        [HttpDelete("Patient/{userId}/{patientId}")]
        public async Task<ActionResult<WatchList>> DeleteWatchListByPatient(string userId, string patientId)
        {
            var item2 = _context.WatchLists.Where(p => p.ClinicianId.Equals(userId) && p.PatientId.Equals(patientId)).FirstOrDefault();
            if (item2 == null)
            {
                return NotFound();
            }

            _context.WatchLists.Remove(item2);
            await _context.SaveChangesAsync();

            return item2;
        }


        private bool WatchListExists(int id)
        {
            return _context.WatchLists.Any(e => e.WatchListId == id);
        }
    }
}
