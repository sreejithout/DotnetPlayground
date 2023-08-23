using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace DotnetPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
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
}
