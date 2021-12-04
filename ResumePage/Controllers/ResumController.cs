using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ResumePage.Data;
using ResumePage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePage.Controllers
{
    public class ResumController : Controller
    {
        private readonly ResumeDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ResumController(ResumeDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }

        public IActionResult Create() 
        {
            Applicant applicant = new Applicant();
            applicant.Experince.Add(new Experince() { ExperinceId = 1 });

            return View(applicant);
        } 
        
        [HttpPost]
        public IActionResult Create(Applicant applicant) 
        {
            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;

            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;

            if (applicant.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
