using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DotnetPlayground.WebApi.Filters;

public class IdempotencyFilter : IAsyncActionFilter
{
    private readonly IDistributedCache _cache;

    public IdempotencyFilter(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // 1. Check if the header exists
        if (!context.HttpContext.Request.Headers.TryGetValue("Idempotency-Key", out var idempotencyKey) ||
            string.IsNullOrWhiteSpace(idempotencyKey))
        {
            context.Result = new BadRequestObjectResult("The 'Idempotency-Key' header is required.");
            return;
        }

        string cacheKey = $"idempotency_{idempotencyKey}";

        // 2. Check if the request was already processed
        var cachedData = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(cachedData))
        {
            // Deserialize our cached wrapper
            var cachedResponse = JsonSerializer.Deserialize<CachedResponse>(cachedData);

            // Return a ContentResult with the exact JSON and Status Code from the first run
            context.Result = new ContentResult
            {
                Content = cachedResponse?.Content,
                ContentType = "application/json",
                StatusCode = cachedResponse?.StatusCode ?? 200
            };
            return; // Short-circuit
        }

        // 3. Let the controller action execute
        var executedContext = await next();

        // 4. If successful, capture the result, serialize it, and cache it
        if (executedContext.Exception == null && executedContext.Result is ObjectResult objectResult)
        {
            var responseToCache = new CachedResponse
            {
                StatusCode = objectResult.StatusCode ?? 200,
                // Serialize the actual value returned by the controller (e.g., the Product object)
                Content = JsonSerializer.Serialize(objectResult.Value)
            };

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            };

            // Serialize the wrapper and save to cache
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(responseToCache), cacheOptions);
        }
    }

    // Private helper record to store both the status code and the stringified JSON body
    private record CachedResponse
    {
        public int StatusCode { get; init; }
        public string? Content { get; init; }
    }
}