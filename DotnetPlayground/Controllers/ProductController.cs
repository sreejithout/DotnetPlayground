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

    public ProductController(IProductRepository productRepository, IOptions<AppOptions> appOptions)
    {
        _productRepository = productRepository;
        _appOptions = appOptions.Value;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        Console.WriteLine($"DI configure value 'C# Version' inside ProductController: {_appOptions.CSharpFeatures.Version}");
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
