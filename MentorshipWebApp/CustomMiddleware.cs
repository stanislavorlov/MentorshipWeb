using System.Globalization;
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
            await _next(context);
        }
    }
}
