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
    public class ObservationController : ControllerBase
    {
        private readonly HealthContext _context;

        public ObservationController(HealthContext context)
        {
            _context = context;
        }

        // Get all the observations
        // GET: api/Observation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Observation>>> GetObservations()
        {
            return await _context.Observations
                .Include(o => o.observedItems).ThenInclude(bp => bp.bloodPressures)
                .Include(o => o.observedItems).ThenInclude(bh => bh.bodyHeats)
                .Include(o => o.observedItems).ThenInclude(rr => rr.respiratoryRates)
                .Include(o => o.observedItems).ThenInclude(sr => sr.sinusRhythms)
                .ToListAsync();
        }

        // Get a certain observation by Id
        // GET: api/Observation/id
        [HttpGet("{id}")]
        public async Task<List<Observation>> GetObservation(string id)
        {
            var observation = await _context.Observations
                .Include(o => o.observedItems).ThenInclude(bp => bp.bloodPressures)
                .Include(o => o.observedItems).ThenInclude(bh => bh.bodyHeats)
                .Include(o => o.observedItems).ThenInclude(rr => rr.respiratoryRates)
                .Include(o => o.observedItems).ThenInclude(sr => sr.sinusRhythms)
                .Where(ob => ob.ObservationId == id).ToListAsync();


            return observation;
        }

        // Get all the observations of a patient by patientId
        // GET: api/Observation/Patient/patientId
        [HttpGet("Patient/{patientId}")]
        public async Task<List<Observation>> GetAppointmentByPatient(string patientId)
        {
            return await _context.Observations
                .Include(o => o.observedItems).ThenInclude(bp => bp.bloodPressures)
                .Include(o => o.observedItems).ThenInclude(bh => bh.bodyHeats)
                .Include(o => o.observedItems).ThenInclude(rr => rr.respiratoryRates)
                .Include(o => o.observedItems).ThenInclude(sr => sr.sinusRhythms)
                .Where(p => p.PatientId == patientId).ToListAsync();
        }



        private bool ObservationExists(string id)
        {
            return _context.Observations.Any(e => e.ObservationId == id);
        }
    }
}
