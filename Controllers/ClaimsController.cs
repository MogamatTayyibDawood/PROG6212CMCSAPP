using Microsoft.AspNetCore.Mvc;
using PROG6212CMCSAPP.Data;
using PROG6212CMCSAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace PROG6212CMCSAPP.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create claim (Lecturers)
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Claim claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check for supporting document
                    if (supportingDocument != null)
                    {
                        var allowedExtensions = new[] { ".pdf", ".docx", ".xlsx" };
                        var fileExtension = Path.GetExtension(supportingDocument.FileName).ToLowerInvariant();

                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            ModelState.AddModelError("supportingDocument", "Only .pdf, .docx, and .xlsx files are allowed.");
                            return View(claim);
                        }

                        if (supportingDocument.Length > 5 * 1024 * 1024)
                        {
                            ModelState.AddModelError("supportingDocument", "File size must be less than 5 MB.");
                            return View(claim);
                        }

                        using (var memoryStream = new MemoryStream())
                        {
                            supportingDocument.CopyTo(memoryStream);
                            claim.DocumentData = memoryStream.ToArray();
                        }
                        claim.DocumentType = supportingDocument.ContentType;
                    }

                    // Calculate total amount and set other properties
                    claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
                    claim.Status = "Pending";
                    claim.SubmissionDate = DateTime.Now;

                    // Add to database
                    _context.Claims.Add(claim);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Claim submitted successfully!";
                    return RedirectToAction("TrackClaim", new { id = claim.ClaimId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the claim: " + ex.Message);//Error handling
                }
            }

            return View(claim);
        }

        // View all pending claims (Coordinators and Managers)
        public IActionResult PendingClaims()
        {
            var pendingClaims = _context.Claims
                .Where(c => c.Status == "Pending")
                .ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                claim.Status = status;
                claim.ApprovalDate = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("PendingClaims");
        }

        // Track claim status (Lecturer)
        public IActionResult TrackClaim(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View(claim);
        }

        // Download document (for Managers or Coordinators)
        public IActionResult Download(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null || claim.DocumentData == null)
            {
                return NotFound();
            }

            return File(claim.DocumentData, claim.DocumentType, "supporting-document");
        }

        // List all claims (for overview purposes)
        public IActionResult Index()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }
    }
}
