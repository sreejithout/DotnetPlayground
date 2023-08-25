using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories.Interfaces;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly AppOptions _appOptions;
    private readonly AngularFeatureOptions _angularFeatureOptions;

    public ProductController(
        IProductRepository productRepository,
        IOptions<AppOptions> appOptions, // NOTE: We are using IOptions. This will get the changed configuration value after restarting the app only.
        IOptionsSnapshot<AngularFeatureOptions> angularFeatureOptions // NOTE: We are using IOptionsSnapshot to get the changed configuration value without restarting the app
        )
    {
        _productRepository = productRepository;
        _appOptions = appOptions.Value;
        _angularFeatureOptions = angularFeatureOptions.Value;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        Console.WriteLine($"DI configure value 'C# Version' inside ProductController: {_appOptions.CSharpFeatures.Version}");
        Console.WriteLine($"DI configure value 'Angular Version' inside ProductController: {_angularFeatureOptions.Version}");
        return _productRepository.GetAllProducts();
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<Product> Get(int id)
    {
        return await _productRepository.GetProduct(id);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task Post([FromBody] Product prod)
    {
        await _productRepository.AddProduct(prod);
    }

    // PUT api/<ProductController>/5
    [HttpPut]
    public async Task Put([FromBody] Product prod)
    {
        await _productRepository.UpdateProduct(prod);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _productRepository.RemoveProduct(id);
    }
}
