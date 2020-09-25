using System;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class Patient
    {
        [Key]
        public string PatientId { get; set; }
        public string ImgUrl { get; set; }
    }
}
