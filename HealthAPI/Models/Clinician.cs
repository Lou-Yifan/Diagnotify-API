using System;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Clinician
    {
        [Key]
        public string ClinicianId { get; set; }
        public string ClinicianName { set; get; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
