using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class ObservedItem
    {
        public string ObservedItemId { get; set; }

        public ICollection<BloodPressure> bloodPressures { get; set; }
        public ICollection<BodyHeat> bodyHeats { get; set; }
        public ICollection<RespiratoryRate> respiratoryRates { get; set; }
        public ICollection<SinusRhythm> sinusRhythms { get; set; }
    }
}
