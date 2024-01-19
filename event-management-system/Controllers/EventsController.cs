using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;

namespace event_management_system.Controllers
{

    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentCreation()
        {
            return View();
        }

        
        public IActionResult EventMain()
        {
            string EventID = HttpContext.Request.Query["id"]!;
            ViewData["EventID"] = EventID;

            return View();
        }



        public IActionResult EventsUpcoming() {

            return PartialView("EventCategory/EventsUpcoming");
        }

        public IActionResult EventsPrevious()
        {

            return PartialView("EventCategory/EventsPrevious");
        }



        public IActionResult EventDetails()
        {
            return PartialView("EventManagement/EventDetails");

        }
        public IActionResult EventAttendanceLog()
        {

            return PartialView("EventManagement/EventAttendanceLog");
        }
        
        public IActionResult EventAttendees()
        {

            return PartialView("EventManagement/EventAttendees");
        }
    }
}
