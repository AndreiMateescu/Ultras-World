using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackUp1Final.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public double TransferValue { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public double BestTransferValue { get; set; }

        [Range(0, int.MaxValue)]
        public int Trophies { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public string Club { get; set; }

        public string CoverImageFileName
        {
            get
            {
                return "~/Content/images/Players/" + FirstName.ToLower() + "-" + LastName.ToLower() + ".jpg";
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}