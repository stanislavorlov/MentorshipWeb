using MentorshipWebApp.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace MentorshipWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Login()
        {
            var claims = new List<Claim> { };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            await HttpContext.SignOutAsync();

            if (true)
            {
                await HttpContext.ForbidAsync();
            }

            if (HttpContext.User.IsInRole(""))
            {

            }

            HttpContext.User.HasClaim(c => c.Value == "custom_claim");
            //var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Subject == ClaimsIdentity.DefaultIssuer);

            if (claim != null)
            {

            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Details()
        {
            if (User.Identity.IsAuthenticated)
            {
                //User.Identity.Name
                if (User.HasClaim(c => c.Value == "custom_claim"))
                {

                }
            }

            return Ok();
        }
    }
}
