using event_management_system.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace event_management_system.Controllers
{
    public class OrganizationHomeController : Controller
    {
        private readonly ILogger<OrganizationHomeController> _logger;

        public OrganizationHomeController(ILogger<OrganizationHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {


            
            return View();
        }

        public IActionResult ValidateOrganizationLogin()
        {
            // Replace with your logic to get the account ID
            int accountId = 123; 

            TempData["AccountId"] = accountId;
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendOrganizationAccount() 
        {
            return RedirectToAction();
        }

        public IActionResult About()
        {
            Debug.Write("Aboput");
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
