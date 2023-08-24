namespace DotnetPlayground.WebApi.ExtensionMethods;
public static class AllHttpClients
{
    public static void RegisterHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient();
    }
}
