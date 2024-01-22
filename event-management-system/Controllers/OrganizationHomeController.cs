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

        

        /*public IActionResult ValidateOrganizationLogin()
        {
            // Replace with your logic to get the account ID
            int accountId = 123; 

            TempData["AccountId"] = accountId;
            return RedirectToAction("Index");
        }*/

        public IActionResult Index()
        {
            // get user list for org then extract userId then find it in list
            // string userId = HttpContext.Request.Query["userId"];
            // pass it into view bag then adjust js in view
            // ViewBag.UserName = user.UserName;

            return View();
        }

        public IActionResult SendOrganizationAccount() 
        {
            return RedirectToAction();
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
