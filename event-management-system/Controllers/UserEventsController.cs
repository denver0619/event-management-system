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
            // Get upcoming events list then pass model to view
            return PartialView("EventCategory/EventsUpcoming");
        }

        public IActionResult EventsPrevious()
        {
            // Get upcoming events list then pass model to view
            return PartialView("EventCategory/EventsPrevious");
        }

        public IActionResult EventInfo()
        {
            string eventId = HttpContext.Request.Query["id"]!;
            Debug.WriteLine(eventId);

            // Find event details based on the event id then return it to view
            
            

            return View();
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
            string userId = HttpContext.Request.Query["userId"]!;
            Debug.WriteLine(userId);
            // get list of vents based on who is user
            return View();
        }
    }

    public class RegisterCredentials()
    {
        public string? UserID { get; set; }
        public string? EventID { get; set; }
    }
}
