using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace event_management_system.Controllers
{
    public class VisitorHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {

            
            return View();
        }
        
        public IActionResult ValidateLogin([FromBody] UserCredential userCredential) 
        {

            Debug.WriteLine(JsonSerializer.Serialize(userCredential));
            // get list of user then validate iif user or org
            string email = userCredential.Email!;
            string password = userCredential.Password!;
            string userId = "3";

            Debug.WriteLine(email);

            if (email == "org")
            {
                return Json(new { redirectTo = Url.Action("Index", "OrganizationHome", new { userId = userId }) });
            } else if (email == "user")
            {
                return Json(new { redirectTo = Url.Action("Index", "UserHome", new { userId = userId }) });
            }

            return Ok();
        }

        public IActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }

    public class UserCredential
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
