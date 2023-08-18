using MentorshipWebApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Person), 200)]
        [ProducesResponseType(typeof(string), 204)]
        public IResult Login([Bind("name,age")] Person person)
        {
            return Results.NoContent();
        }
    }
}
