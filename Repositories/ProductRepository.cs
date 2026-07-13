using EntityFrameworkCorePlayground.Data;
using EntityFrameworkCorePlayground.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly DummyDbContext _dbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext"></param>
    public ProductRepository(DummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddProduct(Product product, CancellationToken token)
    {
        await _dbContext.AddAsync(new Product { Name = product.Name, Price = product.Price });
        await _dbContext.SaveChangesAsync(token);
        return true;
    }

    public async Task<List<Product>> GetAllProducts(CancellationToken token)
    {
        return await _dbContext.Products.ToListAsync(token);
    }

    public async Task<Product> GetProduct(int id, CancellationToken token)
    {
        return await _dbContext.Products.SingleAsync(x => x.Id == id, token);
    }

    public async Task<bool> RemoveProduct(int id, CancellationToken token)
    {
        var product = await this.GetProduct(id, token);
        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync(token);
        return true;
    }

    public async Task<Product> UpdateProduct(Product product, CancellationToken token)
    {
        var newProd = _dbContext.Products.Single(p => p.Id == product.Id);
        newProd.Name = product.Name;
        newProd.Price = product.Price;
        await _dbContext.SaveChangesAsync(token);
        return newProd;
    }
}
