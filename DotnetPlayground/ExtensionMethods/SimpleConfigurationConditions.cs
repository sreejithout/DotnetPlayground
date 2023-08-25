using SharedPocos.Options;

namespace DotnetPlayground.WebApi.ExtensionMethods
{
    public static class SimpleConfigurationConditions
    {
        public static void RegisterSimpleConfigs(this WebApplication app, WebApplicationBuilder builder)
        {
            // CONFIGURATIONS: Creating a simple custom middleware to read from configurations
            app.Use(async (context, next) =>
            {
                // 1. take directly from configuration
                Console.WriteLine($"inside: {builder.Configuration.GetValue<string>("hi")}");

                // 2. take directly from configuration, from a key inside a section
                Console.WriteLine($"inside angular version: {builder.Configuration.GetValue<string>("appOptions:angularFeatures:version")}");

                // 3. Bind Configuration to a model
                var appOptions1 = new AppOptions();
                builder.Configuration.GetSection("appOptions").Bind(appOptions1);
                Console.WriteLine($"inside .NET version: {appOptions1.CSharpFeatures.Version}");

                // 4. Bind Configuration to model: different approach
                var appOptions = builder.Configuration.GetSection("appOptions").Get<AppOptions>();
                Console.WriteLine($"inside .NET version: {appOptions.DotnetFeatures.Version}");

                await next();
            });
        }
    }
}
