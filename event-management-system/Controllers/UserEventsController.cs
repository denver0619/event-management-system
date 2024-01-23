using event_management_system.Domain.Models;
using event_management_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace event_management_system.Controllers
{
    public class UserEventsController : Controller
    {
        public IActionResult Index()
        {
            string userId = HttpContext.Request.Query["userId"]!;
            
            return View();
        }

        public IActionResult EventsUpcoming()
        {
            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllUpcomingEvents();
            eventsServices.Dispose();
            //return Ok();
            return PartialView("EventCategory/EventsUpcoming", eventsModel);
        }

        public IActionResult EventsPrevious()
        {
            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetAllPreviousEvents();
            eventsServices.Dispose();
            return PartialView("EventCategory/EventsPrevious", eventsModel);
        }

        public IActionResult EventInfo()
        {
            string EventID = HttpContext.Request.Query["id"];
            Debug.WriteLine(EventID);
            EventsServices eventsServices = new EventsServices();
            EventsModel eventsModel = eventsServices.GetEventInfoById(EventID);
            //EventsModel eventsModel = eventsServices;

            //get card info from url then find from list then return model
            return View(eventsModel);
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody]RegisterCredentials registerCredentials)
        {

            Debug.WriteLine(JsonSerializer.Serialize(registerCredentials));
            Debug.WriteLine(registerCredentials.UserID);
            Debug.WriteLine(registerCredentials.EventID);
            return Ok();
        }

        public IActionResult MyEvents()
        {
            return View();
        }
    }

    public class RegisterCredentials()
    {
        public string? UserID { get; set; }
        public string? EventID { get; set; }
    }
}
