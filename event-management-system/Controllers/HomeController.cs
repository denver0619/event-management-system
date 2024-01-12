using event_management_system.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
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

            return PartialView("EventsOngoing");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
