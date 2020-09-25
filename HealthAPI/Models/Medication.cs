using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class Medication
    {
        public string MedicationId { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}
