using DotnetPlayground.WebApi.Exceptions;
using System.Net;

namespace DotnetPlayground.WebApi.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    // Using a middleware instead of using a filter for faster processing.
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (SampleNotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(ex.Message);
            throw;
        }
        catch (SampleValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(ex.Message);
            throw;
        }
    }
}
