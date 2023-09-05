namespace DotnetPlayground.WebApi.Middlewares;

public class SampleFactoryMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Before next in Sample Factory Middleware");
        await next(context);
        Console.WriteLine("After next in Sample Factory Middleware");
    }
}
