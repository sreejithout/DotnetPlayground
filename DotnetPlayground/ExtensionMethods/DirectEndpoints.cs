namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class DirectEndpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            var endpoint = context.GetEndpoint();
            await next();
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World");
            });

            endpoints.MapGet("authotizedRouteSample", async context =>
            {
                await context.Response.WriteAsync("Hello World");
            })
            .RequireAuthorization();

            endpoints.MapGet("/hello/{name}", async context =>
            {
                var name = context.GetRouteValue("name");
                await context.Response.WriteAsync($"Hello {name}!");
            });

            endpoints.MapGet("/helloAlphabets/Sreejith", async context =>
            {
                await context.Response.WriteAsync($"Specific route will have more precedence than the generic route defined below!");
            });

            // Route Constraints
            endpoints.MapGet("/helloAlphabets/{name:alpha:minlength(2)?}", async context =>
            {
                var name = context.GetRouteValue("name");
                await context.Response.WriteAsync($"Hello {name}!");
            });

            // Custom Route Constraints
            endpoints.MapGet("/custom/{name:myCustom}", async context =>
            {
                var name = context.GetRouteValue("name");
                await context.Response.WriteAsync($"Hello {name}!");
            });
        });
    }
}
