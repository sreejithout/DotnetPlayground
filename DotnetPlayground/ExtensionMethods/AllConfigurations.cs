﻿using SharedPocos.Options;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class AllConfigurations
{
    public static void RegisterConfigurations(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<AppOptions>(configuration.GetSection("appOptions"));
        
        // This is the better way to bind configurations to options with validations.
        services.AddOptions<PokemonApiOptions>()
            .Bind(configuration.GetSection(PokemonApiOptions.PokemonApi))
            .ValidateDataAnnotations();
    }
}
