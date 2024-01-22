using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
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
