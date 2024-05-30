using DotnetPlayground.WebApi.Filters;
using DotnetPlayground.WebApi.Middlewares;
using DotnetPlayground.WebApi.Utilities;
using DotnetPlayground.WebApi.Utilities.Interfaces;
using Repositories;
using Services;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class DependencyInjections
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddServices();

        services.AddSingleton<SampleResultFilterAttribute>();
        services.AddTransient<ExceptionHandlingMiddleware>();

        services.AddTransient<IJWTGenerator, JWTGenerator>();
        services.AddTransient<SampleFactoryMiddleware>();
        services.AddTransient<SampleFactoryMiddlewareWithDI>();
    }
}
