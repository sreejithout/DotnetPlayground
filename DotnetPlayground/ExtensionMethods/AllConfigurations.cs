using SharedPocos.Options;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class AllConfigurations
{
    public static void RegisterConfigurations(this IServiceCollection services, ConfigurationManager configuration)
    {
        // binding a parent node to the option model
        services.Configure<AppOptions>(configuration.GetSection("appOptions"));

        // binding a child node to the option model
        services.Configure<AngularFeatureOptions>(configuration.GetSection(AngularFeatureOptions.AngularFeatures));

        // This is the better way to bind configurations to options with validations.
        services.AddOptions<PokemonApiOptions>()
            .Bind(configuration.GetSection(PokemonApiOptions.PokemonApi))
            .ValidateDataAnnotations();

        services.AddOptions<WeatherApiOptions>()
            .Bind(configuration.GetSection(WeatherApiOptions.WeatherApi))
            .ValidateDataAnnotations();
    }
}
