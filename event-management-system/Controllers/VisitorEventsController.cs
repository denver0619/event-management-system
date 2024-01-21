using Microsoft.AspNetCore.Mvc;

namespace event_management_system.Controllers
{
    public class VisitorEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
