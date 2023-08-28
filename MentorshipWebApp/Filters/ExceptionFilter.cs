using Microsoft.AspNetCore.Mvc.Filters;

namespace MentorshipWebApp.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);

            context.ExceptionHandled = true;
        }
    }
}
