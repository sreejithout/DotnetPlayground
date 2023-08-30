using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetPlayground.WebApi.Filters;

public class SampleGlobalActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Sample Global OnActionExecuted");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Sample Global OnActionExecuting");
    }
}
