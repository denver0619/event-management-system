using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;

namespace event_management_system.Controllers
{

    public class OrganizationEventsController : Controller
    {
        public IActionResult Index()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);
            return View();
        }

        public IActionResult ContentCreation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEventData() {
            


            return Ok();
        }

        
        public IActionResult EventMain()
        {
            
            

            return View();
        }



        public IActionResult EventsUpcoming() 
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);

            // get list of upcoming based on orgID then return as model
            return PartialView("EventCategory/EventsUpcoming");
            // return PartialView("EventCategory/EventsUpcoming", modelHere);
        }

        public IActionResult EventsPrevious()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);
            // get list of previous based on orgID then return as model
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
