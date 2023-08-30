using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetPlayground.WebApi.Filters
{
    public class SampleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<SampleResultFilterAttribute> _logger;
        private readonly string _name;

        public SampleResultFilterAttribute(ILogger<SampleResultFilterAttribute> logger, string name = "Global")
        {
            _logger = logger;
            _name = name;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Sample Attribute OnResultExecuted {_name}");
            _logger.LogInformation($"Sample Attribute OnResultExecuted {_name}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Sample Attribute OnResultExecuting {_name}");
            _logger.LogInformation($"Sample Attribute OnResultExecuting {_name}");
        }
    }
}
