using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HealthAPI.Models
{
    public class WatchList
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WatchListId { get; set; }
        public string PatientId { get; set; }
        public string ClinicianId { get; set; }
    }
}
