using Asp.Versioning;
using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly AppOptions _appOptions;
    private readonly AngularFeatureOptions _angularFeatureOptions;
    private readonly IDistributedCache _cache;

    public ProductController(
        IProductService productService,
        IOptions<AppOptions> appOptions, // NOTE: We are using IOptions. This will get the changed configuration value after restarting the app only.
        IOptionsSnapshot<AngularFeatureOptions> angularFeatureOptions, // NOTE: We are using IOptionsSnapshot to get the changed configuration value without restarting the app
        IDistributedCache cache
        )
    {
        _productService = productService;
        _appOptions = appOptions.Value;
        _angularFeatureOptions = angularFeatureOptions.Value;
        _cache = cache;
    }

    // GET: api/<ProductController>
    [HttpGet("GetProducts")]
    public async Task<List<Product>> Get(CancellationToken token)
    {
        Console.WriteLine($"DI configure value 'C# Version' inside ProductController: {_appOptions.CSharpFeatures.Version}");
        Console.WriteLine($"DI configure value 'Angular Version' inside ProductController: {_angularFeatureOptions.Version}");
        return await _productService.GetAllProducts(token);
    }

    // GET api/<ProductController>/5
    [HttpGet("/[action]/{id}")]
    public async Task<Product> GetProductDetails(int id, CancellationToken token)
    {
        return await _productService.GetProduct(id, token);
    }

    // POST api/<ProductController>
    [HttpPost("/AddProduct")] // Leading slash("/") will make sure to discard the parent route
    public async Task<IActionResult> Post([FromHeader(Name = "Idempotency-Key")] string idempotencyKey, [FromBody] Product prod, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(idempotencyKey))
        {
            return BadRequest("The 'Idempotency-Key' header is required.");
        }
        // 1. Check the distributed cache asynchronously
        var existingRequest = await _cache.GetStringAsync(idempotencyKey, token);
        if (!string.IsNullOrEmpty(existingRequest))
        {
            return Ok(new { Message = "Product creation already processed (Idempotent response)." });
        }

        await _productService.AddProduct(prod, token);
        // 3. Configure cache expiration (e.g., 24 hours)
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
        };

        // 4. Save to the distributed cache
        await _cache.SetStringAsync(idempotencyKey, "processed", cacheOptions, token);

        return CreatedAtAction(nameof(GetProductDetails), new { id = prod.Id }, prod);
    }

    // PUT api/<ProductController>/5
    [HttpPut("[action]")]
    public async Task UpdateProduct([FromBody] Product prod, CancellationToken token)
    {
        await _productService.UpdateProduct(prod, token);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("DeleteProduct/{id}")]
    public async Task Delete(int id, CancellationToken token)
    {
        await _productService.RemoveProduct(id, token);
    }
}
