namespace DotnetPlayground.WebApi.Middlewares;

public class SampleFactoryMiddlewareWithDI : IMiddleware
{
    private readonly ILogger<SampleFactoryMiddlewareWithDI> _logger;
    public SampleFactoryMiddlewareWithDI(ILogger<SampleFactoryMiddlewareWithDI> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Before next in Sample Factory Middleware with DI");
        Console.WriteLine("Before next in Sample Factory Middleware with DI");
        await next(context);
        Console.WriteLine("After next in Sample Factory Middleware with DI");
        _logger.LogInformation("After next in Sample Factory Middleware with DI");
    }
}
