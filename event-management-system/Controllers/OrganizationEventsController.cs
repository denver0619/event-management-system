using event_management_system.Domain.Models;
using event_management_system.Services;
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

            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllUpcomingEventsByOrganizationID(userID);
            eventsServices.Dispose();

            // get list of upcoming based on orgID then return as model
            return PartialView("EventCategory/EventsUpcoming", eventsModel);
            // return PartialView("EventCategory/EventsUpcoming", modelHere);
        }

        public IActionResult EventsPrevious()
        {
            string userID = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userID);

            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllPreviousEventsByOrganizationID(userID);
            eventsServices.Dispose();

            // get list of previous based on orgID then return as model
            return PartialView("EventCategory/EventsPrevious", eventsModel);
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
