using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetPlayground.WebApi.Filters;

public class SampleActionFilterAttribute : Attribute, IActionFilter
{
    private readonly string _name;

    public SampleActionFilterAttribute(string name)
    {
        _name = name;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Sample Attribute OnActionExecuted with name: {_name}");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Sample Attribute OnActionExecuting with name: {_name}");
    }
}
