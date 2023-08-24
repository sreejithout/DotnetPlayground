using SharedPocos.Options;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class AllConfigurations
{
    public static void RegisterConfigurations(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<AppOptions>(configuration.GetSection("appOptions"));
        services.Configure<PokemonApiOptions>(configuration.GetSection(PokemonApiOptions.PokemonApi));

        services.AddOptions<PokemonApiOptions>()
            .Bind(configuration.GetSection(PokemonApiOptions.PokemonApi));
    }
}
