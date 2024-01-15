namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class InlineMiddlewares
{
    public static void RegisterInlineMiddlewares(this WebApplication app)
    {
        // 01_01. Use will get a context and next parameter
        app.Use(async (context, next) =>
        {
            Console.WriteLine("Before Request");
            await next();
            Console.WriteLine("After Request");
        });

        // 01_02. UseWhen
        app.UseWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);

        // 02_01. Map
        app.Map("/map_sample", MapHandler);

        // 02_02. MapWhen
        app.MapWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);


        // 03. Run is a Terminal Delegate. It only recieves the context. It terminates/ends the pipeline
        //
        ///// app.Run(async context => await context.Response.WriteAsync("Inline Run "));
        //
        // Whatever we write after does not get executed.
    }

    private static void HandleRequestWithQuery(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            Console.WriteLine("Contains Query");
            await next(); // this line will not be required for MapWhen
        });
    }

    private static void MapHandler(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            Console.WriteLine("Reached Map Sample");
            await context.Response.WriteAsync("Reached Map Sample");
        });
    }
}
