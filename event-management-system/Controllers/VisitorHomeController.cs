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

            string email = userCredential.Email!;
            string password = userCredential.Password!;

            Debug.WriteLine(email);

            if (email == "org")
            {
                Debug.WriteLine("inside");
                return Json(new { redirectTo = Url.Action("Index", "OrganizationHome") });
            }

            return Ok();
        }
    }

    public class UserCredential
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
