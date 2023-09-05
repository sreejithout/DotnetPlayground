namespace DotnetPlayground.WebApi.Middlewares;

public class SampleConventionalMiddleware
{
    private readonly RequestDelegate _next;

    public SampleConventionalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<SampleConventionalMiddleware> logger)
    {
        logger.LogInformation("Before next in Sample Factory Middleware with DI");
        Console.WriteLine("Before next in Sample Factory Middleware with DI");
        await _next(context);
        Console.WriteLine("After next in Sample Factory Middleware with DI");
        logger.LogInformation("After next in Sample Factory Middleware with DI");
    }
}
