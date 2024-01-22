using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using event_management_system.Services;
using Org.BouncyCastle.Bcpg;

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

            // Debug.WriteLine(JsonSerializer.Serialize(userCredential));
            // get list of user then validate iif user or org
            string email = userCredential.Email!;
            string password = userCredential.Password!;

            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.AuthenticateStudent(email, password);
            if(!authenticationService.Model.IsAuthenticated)
            {
                authenticationService.AuthenticateOrganization(email, password);
                if(!authenticationService.Model.IsAuthenticated) 
                { 
                    return Ok();
                }
                else
                {
                    //string userId = authenticationService.Model.Organization!.OrganizationID!;
                    return Json(new { redirectTo = Url.Action("Index", "OrganizationHome", new { userId = authenticationService.Model.Organization!.OrganizationID! }) });
                }
               
            }
            else
            {
                //string userId = authenticationService.Model.Student!.StudentID!;
                return Json(new { redirectTo = Url.Action("Index", "UserHome", new { userId = authenticationService.Model.Student!.StudentID! }) });
            }



            
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
