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
    public class AppointmentController : ControllerBase
    {
        private readonly HealthContext _context;

        public AppointmentController(HealthContext context)
        {
            _context = context;
        }

        // Get all appointments
        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // Get certain appointment by ID
        // GET: api/Appointment/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(string id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // Get all appointments by patientId
        // GET: api/Appointment/Patient/patientId
        [HttpGet("Patient/{patientId}")]
        public async Task<List<Appointment>> GetAppointmentByPatient(string patientId)
        {
            return await _context.Appointments
                .Where(p => p.PatientId == patientId).ToListAsync();
        }


        private bool AppointmentExists(string id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
