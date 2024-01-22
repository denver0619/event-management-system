using Microsoft.AspNetCore.Mvc;

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
