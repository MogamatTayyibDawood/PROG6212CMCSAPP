using Microsoft.AspNetCore.Mvc;

namespace PROG6212CMCSAPP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
