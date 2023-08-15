using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MentorshipWebApp.Interface;
using MentorshipWebApp.Model;
using Microsoft.Extensions.Options;
using System.Text;

namespace MentorshipWebApp.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private IProductService ProductService { get; set; }

        private IConfiguration configuration { get; set; }

        private ILogger<ProductController> logger { get; set; }

        private ILoggerProvider loggerProvider { get; set; }

        private ILoggerFactory loggerFactory { get; set; }

        public ProductController(IProductService productService,
            IOptions<ProductSettings> options,
            ILogger<ProductController> logger,
            ILoggerProvider loggerProvider,
            ILoggerFactory loggerFactory)
        {
            ProductService = productService;
            this.logger = logger;
            this.loggerFactory = loggerFactory;
        }

        [HttpGet("{id}")]
        public IActionResult Action([FromQuery] int id)
        {
            var logger = this.loggerFactory.CreateLogger<ProductController>();

            var context = HttpContext;

            HttpContext.Session.Set("key", Encoding.UTF8.GetBytes("Hello world!"));

            var features = context.Features.ToList();

            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");

            try
            {
                ProductService.AddProduct(new Product { Id = id });

                logger.LogInformation("Succesfully added");
            }
            catch (Exception ex)
            {
                logger.LogError("Error occured during bla bla", ex);
            }

            return Ok("action");
        }

        [HttpPost("details")]
        public IActionResult Details([FromQuery] int id, [FromBody] Details details)
        {
            return Ok("details");
        }
    }
}
