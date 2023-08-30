using DotnetPlayground.WebApi.Filters;
using Repositories;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class DependencyInjections
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddRepositories();

        services.AddSingleton<SampleResultFilterAttribute>();
    }
}
