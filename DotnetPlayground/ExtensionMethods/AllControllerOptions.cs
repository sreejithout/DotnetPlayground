using DotnetPlayground.WebApi.Filters;
using DotnetPlayground.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class AllControllerOptions
{
    public static void RegisterControllerOptions(this MvcOptions options)
    {
        // Adding a route convention
        var parameterTransformer = new SlugifyParameterTransformer();
        var routeTokenTransformerConvention = new RouteTokenTransformerConvention(parameterTransformer);
        options.Conventions.Add(routeTokenTransformerConvention);

        // Adding Global Action filter
        options.Filters.Add(new SampleGlobalActionFilter());

        // Adding Global Resource filter with attribute
        options.Filters.Add(new SampleResourceFilterAttribute("Global"));

        // Adding Global Result filter for supporting dependency injection
        options.Filters.AddService<SampleResultFilterAttribute>();

        // Adding Global Result filter for supporting dependency injection
        options.Filters.Add<SampleResultFilterAttribute>();
    }
}
