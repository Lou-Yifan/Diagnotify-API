using System;
using System.ComponentModel.DataAnnotations;

namespace HealthAPI.Models
{
    public class RespiratoryRate
    {
        [Key]
        public string ID { get; set; }
        public string Item { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}
