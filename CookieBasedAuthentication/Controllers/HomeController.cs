using Microsoft.AspNetCore.Mvc;

namespace CookieBasedAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
