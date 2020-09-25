using System;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Medicine
    {
        [Key]
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineUrl { get; set; }
        public string TimesPerDay { get; set; }
        public string PiecesPerTime { get; set; }
        public string Directions { get; set; }
    }
}
