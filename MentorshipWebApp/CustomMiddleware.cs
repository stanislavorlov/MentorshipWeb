using System.Globalization;
using System.IO.Pipelines;
using System.Text;
using System.Text.Unicode;
using MentorshipWebApp.Repositories;

namespace MentorshipWebApp
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IProductRepo productRepo)
        {
            context.Items["test_item"] = "Context item from Middleware";

            await _next(context);

            if (context.Request.Path.Value.Contains(""))
            {
                // do something
            }

            //context.Request
            //context.Response
            //context.Items
            //context.User
            //context.Connection.Id
            //context.Features
            //context.TraceIdentifier
            //context.WebSockets.

            //context.Request.BodyReader

            //PipeWriter
            //PipeReader

            //var stream = new MemoryStream();
            //await context.Request.Body.CopyToAsync(stream);

            //PipeReader reader = new PipeReader(stream);
            //while (sr.Peek() != 0)
            //{
            //    var line = sr.ReadLine();
            //}


        }
    }
}
