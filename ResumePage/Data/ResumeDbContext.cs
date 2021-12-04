using Microsoft.EntityFrameworkCore;
using ResumePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePage.Data
{
    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Experince> Experinces { get; set; }
    }
}
