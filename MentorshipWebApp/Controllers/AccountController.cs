using MentorshipWebApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        [HttpGet()]
        [Produces()]
        [ProducesResponseType(typeof(Person), 200)]
        [ProducesResponseType(typeof(string), 204)]
        public IActionResult Login([Bind("name,age")] Person person)
        {
            Results.NoContent();
        }
    }
}
