using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;

namespace event_management_system.Controllers
{

    public class OrganizationEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentCreation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEventData() {
            /* Add Field */


            return Ok();
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



        public IActionResult EventDetails(string EventID)
        {
            return PartialView("EventManagement/EventDetails");

        }
        public IActionResult EventAttendees(string EventID)
        {
            return PartialView("EventManagement/EventAttendees");
        }

        public IActionResult EventAttendanceLog(string EventID)
        {
            return PartialView("EventManagement/EventAttendanceLog");
        }
        

    }
}
