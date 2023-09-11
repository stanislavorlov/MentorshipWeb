using MentorshipWebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieBasedAuthentication.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string? userName = User?.Identity?.Name;
            string? actor = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)?.Value;

            var profile = new ProfileDetails { UserName = userName, Actor = actor };

            return View();
        }
    }
}
