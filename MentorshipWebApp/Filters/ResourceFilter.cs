using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MentorshipWebApp.Filters
{
    public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.HttpContext.Request.Path.Value.Contains("api") && true /* business logic */)
            {
                context.Result = new JsonResult("Resource filter result");
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
