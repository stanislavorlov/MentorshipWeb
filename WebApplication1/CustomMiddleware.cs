using System.Globalization;
using WebApplication1.Repositories;

namespace WebApplication1
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
