using DotnetPlayground.WebApi.Middlewares;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class AllMiddlewares
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
