using EntityFrameworkCorePlayground.Data;
using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TextDbContext _context;

        public ProductController(TextDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] Product prod)
        {
            _context.AddAsync(new Product { Name = prod.Name, Price = prod.Price });
            await _context.SaveChangesAsync();
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task Put([FromBody] Product prod)
        {
            var newProd = _context.Products.Single(p => p.Id == prod.Id);
            newProd.Name = prod.Name;
            newProd.Price = prod.Price;
            await _context.SaveChangesAsync();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var newProd = _context.Products.Single(p => p.Id == id);
            _context.Remove(newProd);
            await _context.SaveChangesAsync();
        }
    }
}
