using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class UserEventsController : Controller
    {
        public IActionResult Index()
        {
            string userId = HttpContext.Request.Query["userId"]!;
            TempData["UserId"] = userId;
            Debug.WriteLine(userId);
            return View();
        }

        public IActionResult EventsUpcoming()
        {

            return PartialView("EventCategory/EventsUpcoming");
        }

        public IActionResult EventsPrevious()
        {

            return PartialView("EventCategory/EventsPrevious");
        }

        public IActionResult EventInfo()
        {
            //get card info from url then find from list then return model
            return View();
        }
    }
}
