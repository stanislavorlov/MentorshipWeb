using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MentorshipWebApp.Interface;
using MentorshipWebApp.Model;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

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

        private IMemoryCache memoryCache { get; set; }

        public ProductController(
            IProductService productService,
            IOptions<ProductSettings> options,
            ILogger<ProductController> logger,
            ILoggerProvider loggerProvider,
            ILoggerFactory loggerFactory,
            IMemoryCache memoryCache)
        {
            ProductService = productService;
            this.logger = logger;
            this.loggerFactory = loggerFactory;
            this.memoryCache = memoryCache;
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = true, 
            VaryByHeader = "Client-Id", VaryByQueryKeys = new string[] { "clientId" })]
        public IActionResult Action([FromQuery] int id)
        {
            var logger = this.loggerFactory.CreateLogger<ProductController>();

            var context = HttpContext;

            //HttpContext.Session.Set("key", Encoding.UTF8.GetBytes("Hello world!"));

            var features = context.Features.ToList();

            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");

            this.memoryCache.Set("id12345", new { Id = 1, Name = "Person Name", Age = 25 },
                DateTime.Now.AddSeconds(30));

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
            var personCacheObj = this.memoryCache.Get("id12345");

            return Ok("details");
        }
    }
}
