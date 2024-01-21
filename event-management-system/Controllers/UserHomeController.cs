using Microsoft.AspNetCore.Mvc;

namespace event_management_system.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
