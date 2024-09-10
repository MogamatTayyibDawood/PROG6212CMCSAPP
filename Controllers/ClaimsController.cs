using Microsoft.AspNetCore.Mvc;

namespace PROG6212CMCSAPP.Controllers
{
    public class ClaimsController : Controller
    {
        // This action returns the page for submitting claims
        public IActionResult Create()
        {
            return View();
        }

        // This action returns the page for viewing claims
        public IActionResult Index()
        {
            return View();
        }
    }
}
