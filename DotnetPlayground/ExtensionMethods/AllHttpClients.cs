using SharedPocos.Options;

namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class AllHttpClients
{
    public static void RegisterHttpClients(this IServiceCollection services, ConfigurationManager configuration)
    {
        // 1. This can be used to consume any endpoint
        services.AddHttpClient();

        // 2. This can be used only for consuming weather api endpoints
        services.AddHttpClient("weatherApi", c =>
        {
            var weatherApiOptions = configuration.GetSection(WeatherApiOptions.WeatherApi).Get<WeatherApiOptions>();

            c.BaseAddress = new Uri(weatherApiOptions.ApiBaseUrl); // It somehow removing the "v1" part if I'm not giving a trailing slash("/"). Check this key's value in appsettings.json
        });
    }
}
