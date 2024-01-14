using Microsoft.AspNetCore.Mvc;

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
        public IActionResult EventContent()
        {
            return PartialView("EventContent");

        }
        public IActionResult EventLog()
        {
            return PartialView("EventLog");

        }

        public IActionResult EventsUpcoming() {

            return PartialView("EventsUpcoming");
        }

        public IActionResult EventsOngoing()
        {

            return PartialView("EventsOngoing");
        }

        public IActionResult EventsPrevious()
        {

            return PartialView("EventsPrevious");
        }
    }
}
