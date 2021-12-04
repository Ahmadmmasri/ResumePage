using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePage.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [Range(18,55,ErrorMessage ="Currently no position available for your age")]
        [DisplayName("Age in years ")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";

        [Required]
        [Range(1, 25, ErrorMessage = "Currently no position available for your experince")]
        [DisplayName("Total Experince in years")]
        public int TotalExperince { get; set; }

        public virtual List<Experince> Experince { get; set; } = new List<Experince>();

        public string PhotoUrl { get; set; }

        [Required(ErrorMessage ="Please choose the profile Photo")]
        [Display(Name ="Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }


    }

}
