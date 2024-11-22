using Microsoft.AspNetCore.Mvc;
using PROG6212CMCSAPP.Data;
using PROG6212CMCSAPP.Models;
using System.Linq;
using System;

namespace PROG6212CMCSAPP.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View("AdminDashboard");// Admin Dashboard 
        }

       
        public IActionResult GenerateReport(DateTime? startDate, DateTime? endDate) // Generate Report (Handles Report Generation for Claims)
        {
            if (startDate == null)  // dates and months 
                startDate = DateTime.Today.AddMonths(-1); 

            if (endDate == null)
                endDate = DateTime.Today; 

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            var claims = _context.Claims
                                 .Where(c => (startDate == null || c.SubmissionDate >= startDate) &&
                                             (endDate == null || c.SubmissionDate <= endDate))
                                 .ToList();

            return View(claims);
        }

       
        public IActionResult PendingClaims() // Pending Claims (View Pending Claims)
        {
            var pendingClaims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        // Track Claims (View All Claims, No ID required)
        public IActionResult TrackClaim()
        {
            var claims = _context.Claims.ToList();  // Retrieve all claims
            return View(claims);  // Pass claims list to view
        }
    }
}
