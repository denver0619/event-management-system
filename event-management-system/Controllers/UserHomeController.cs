using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            // Load Event Model then pas to controller to see list of events
            string userId = HttpContext.Request.Query["userId"]!;
            TempData["UserId"] = userId;
            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
