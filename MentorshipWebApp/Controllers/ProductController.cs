using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipWebApp.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Index()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product name"}
            };
        }
    }
}
