using Microsoft.AspNetCore.Mvc;

namespace MentorshipWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            return Ok("Login page");
        }
    }
}
