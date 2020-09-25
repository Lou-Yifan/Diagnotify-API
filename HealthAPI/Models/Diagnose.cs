using System;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Diagnose
    {
        [Key]
        public string DiagnoseId { get; set; }
        public string SelfDescription { get; set; }
        public string ClinicianDescription { get; set; }
        public string Suggestions { get; set; }
    }
}
