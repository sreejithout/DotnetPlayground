using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetPlayground.WebApi.Filters
{
    public class SampleAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public SampleAsyncActionFilterAttribute(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before Async Action Filter Execution. name: {_name}");
            await next();
            Console.WriteLine($"After Async Action Filter Execution. name: {_name}");
        }
    }
}
