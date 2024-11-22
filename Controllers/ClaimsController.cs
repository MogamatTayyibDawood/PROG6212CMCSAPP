using Microsoft.AspNetCore.Mvc;
using PROG6212CMCSAPP.Data;
using PROG6212CMCSAPP.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PROG6212CMCSAPP.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var claims = await _context.Claims.ToListAsync();
            return View("MyClaims", claims);
        }

     
        public async Task<IActionResult> MyClaims()
        {
            var claims = await _context.Claims.ToListAsync();
            return View(claims);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Claim claim)
        {
            if (!ModelState.IsValid) return View(claim);

            // Set default values or remove dependency on user
            claim.LecturerName = "Anonymous"; // Default lecturer name or leave it null
            claim.Lecturer = null; // No lecturer associated
            claim.Status = "Pending";
            claim.SubmissionDate = DateTime.UtcNow;

            // Generate a new claim ID (optional, if you're using an auto-incrementing ID in the database, this will happen automatically)
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Details(int id)//details
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            return View(claim);
        }

        
        public async Task<IActionResult> Delete(int id)// delete
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            return View(claim);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
