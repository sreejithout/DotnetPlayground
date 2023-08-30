using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetPlayground.WebApi.Filters
{
    public class SampleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly string _name;

        public SampleResourceFilterAttribute(string name)
        {
            _name = name;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Sample Attribute OnResourceExecuted with name: {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Sample Attribute OnResourceExecuting with name: {_name}");
        }
    }
}
