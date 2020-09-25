using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class Observation
    {
        [Key]
        public string ObservationId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string PatientId { get; set; }

        public ICollection<ObservedItem> observedItems { get; set; }
    }
}
