using Microsoft.AspNetCore.Mvc;

namespace Coverage.Web.Controllers
{
    public class HomeController : Controller
    {
        // Default action method for the HomeController
        [HttpGet]
        public IActionResult Index()
        {
            // Passing data (if needed) to the view in the future is straightforward.
            return View();
        }

        // Example of a future-proof About action
        [HttpGet]
        public IActionResult About()
        {
            // Placeholder for About page logic
            return View();
        }
    }
}
