using Asp.Versioning;
using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
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

    public ProductController(
        IProductService productService,
        IOptions<AppOptions> appOptions, // NOTE: We are using IOptions. This will get the changed configuration value after restarting the app only.
        IOptionsSnapshot<AngularFeatureOptions> angularFeatureOptions // NOTE: We are using IOptionsSnapshot to get the changed configuration value without restarting the app
        )
    {
        _productService = productService;
        _appOptions = appOptions.Value;
        _angularFeatureOptions = angularFeatureOptions.Value;
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
    public async Task Post([FromBody] Product prod, CancellationToken token)
    {
        await _productService.AddProduct(prod, token);
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
