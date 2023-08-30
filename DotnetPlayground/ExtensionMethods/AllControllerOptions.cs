using DotnetPlayground.WebApi.Filters;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class AllControllerOptions
{
    public static void RegisterControllerOptions(this MvcOptions options)
    {
        var parameterTransformer = new SlugifyParameterTransformer();
        var routeTokenTransformerConvention = new RouteTokenTransformerConvention(parameterTransformer);
        options.Conventions.Add(routeTokenTransformerConvention);

        options.Filters.Add(new SampleGlobalActionFilter());
        options.Filters.Add(new SampleResourceFilterAttribute("Global"));
        options.Filters.AddService<SampleResultFilterAttribute>();
        options.Filters.Add<SampleResultFilterAttribute>();
    }
}
