using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class RateLimiter
{

    public static void RateLimiters(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            // Global RateLimiter. This applies to all endpoints automatically.
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                return RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.Request.Headers.Host.ToString(),
                    factory: partition => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        AutoReplenishment = true,
                        QueueLimit = 2,
                        Window = TimeSpan.FromSeconds(10)
                    });
            });
            options.RejectionStatusCode = 429;
        });

        // Named Policy. Applies only to the endpoints where the policy is applied using [EnableRateLimiting("fixed")] attribute.
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("fixed", opt =>
            {
                opt.PermitLimit = 4;
                opt.Window = TimeSpan.FromSeconds(12);
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 2;
            });
        });
    }
}
