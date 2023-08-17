using Microsoft.AspNetCore.Mvc;

namespace MentorshipWebApp.Model
{
    public class MyCustomActionResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await context.HttpContext.Response.WriteAsync("");
        }
    }
}
