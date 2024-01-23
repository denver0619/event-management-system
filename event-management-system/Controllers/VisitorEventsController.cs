using event_management_system.Domain.Models;
using event_management_system.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace event_management_system.Controllers
{
    public class VisitorEventsController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
