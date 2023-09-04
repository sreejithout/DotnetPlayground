using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class AllCorsOptions
{
    public static void RegisterCorsOptions(this CorsOptions options, ConfigurationManager config)
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                .WithOrigins(config.GetSection("AllowedOrigins").Get<string[]>())
                .WithMethods("GET", "POST", "DELETE");
        });

        options.AddPolicy("sampleNamedPolicy", policy => {
            policy
               .WithOrigins("https:localhost:2020")
               .WithHeaders("Authorization");
        });
    }
}
