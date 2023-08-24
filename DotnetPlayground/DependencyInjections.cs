using Repositories;

namespace DotnetPlayground;
public static class DependencyInjections
{
    public static void AllDependencies(this IServiceCollection services)
    {
        services.AddRepositories();
    }
}
