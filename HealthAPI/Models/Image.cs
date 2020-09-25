using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthAPI.Models
{
    public class Image
    {
        [Key]
        public string ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
