using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MentorshipWebApp.Interface;
using MentorshipWebApp.Model;

namespace MentorshipWebApp.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private IProductService ProductService { get; set; }

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult Action([FromQuery] int id)
        {
            ProductService.AddProduct(new Product { Id = id });

            return Ok("action");
        }

        [HttpPost("details")]
        public IActionResult Details([FromQuery] int id, [FromBody] Details details)
        {
            return Ok("details");
        }
    }
}
