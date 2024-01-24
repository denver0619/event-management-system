using event_management_system.Domain.Models;
using event_management_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllUpcomingEvents();
            eventsServices.Dispose();
            string userId = HttpContext.Request.Query["userId"]!;
            TempData["UserId"] = userId;
            return View(eventsModel);
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
