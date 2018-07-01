using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackUp1Final.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Range(1,5)]
        public int Rating { get; set; } //5 maximum

        [Range(0, Double.MaxValue)]
        public int Championships { get; set; }

        [Range(0, Double.MaxValue)]
        public int Cups { get; set; }

        public DateTime FoundingDate { get; set; }

        [Required]
        public string Stadium { get; set; }

        [Range(0, Double.MaxValue)]
        public int Seats { get; set; }

        public string CoverImageFileName
        {
            get
            {
                return "~/Content/images/Teams/" + Name.Replace(" ", "-").ToLower() + ".jpg";
            }
        }
    }
}