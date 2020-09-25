using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class Appointment
    {
        [Key]
        public string AppointmentId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Event { get; set; }
        public string Department { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string PatientId { get; set; }
        public string ClinicianId { get; set; }
    }
}
