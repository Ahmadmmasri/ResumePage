using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePage.Models
{
    public class Experince
    {
        public Experince()
        {
        }

        [Key]
        public int ExperinceId { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; private set; }

        public string CompanyName { get; set; }
        public string Desgination { get; set; }

        [Required]
        public int YearWorked { get; set; }

    }
}
