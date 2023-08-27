using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.WebApi.ExampleModels
{
    public class ModelBindingExample
    {
        [FromRoute]
        public int Id { get; set; }

        [FromQuery]
        public string? Name { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string? Language { get; set; }

        public int[]? Marks { get; set; }
    }
}
