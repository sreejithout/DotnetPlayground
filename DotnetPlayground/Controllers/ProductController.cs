using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
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
    public IEnumerable<Product> Get()
    {
        Console.WriteLine($"DI configure value 'C# Version' inside ProductController: {_appOptions.CSharpFeatures.Version}");
        Console.WriteLine($"DI configure value 'Angular Version' inside ProductController: {_angularFeatureOptions.Version}");
        return _productService.GetAllProducts();
    }

    // GET api/<ProductController>/5
    [HttpGet("/[action]/{id}")]
    public async Task<Product> GetProductDetails(int id)
    {
        return await _productService.GetProduct(id);
    }

    // POST api/<ProductController>
    [HttpPost("/AddProduct")] // Leading slash("/") will make sure to discard the parent route
    public async Task Post([FromBody] Product prod)
    {
        await _productService.AddProduct(prod);
    }

    // PUT api/<ProductController>/5
    [HttpPut("[action]")]
    public async Task UpdateProduct([FromBody] Product prod)
    {
        await _productService.UpdateProduct(prod);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("DeleteProduct/{id}")]
    public async Task Delete(int id)
    {
        await _productService.RemoveProduct(id);
    }
}
