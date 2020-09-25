using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class Report
    {
        [Key]
        public string ReportId { get; set; }
        public string Datetime { get; set; }
        public string PatientId { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Diagnose> Diagnoses { get; set; }
        public ICollection<Medication> Medications { get; set; }
    }
}
