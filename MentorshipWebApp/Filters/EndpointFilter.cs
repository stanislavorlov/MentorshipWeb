namespace MentorshipWebApp.Filters
{
    public class EndpointFilter : Attribute, IEndpointFilter
    {
        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
