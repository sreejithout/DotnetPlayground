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

    public async Task<bool> AddProduct(Product product)
    {
        await _dbContext.AddAsync(new Product { Name = product.Name, Price = product.Price });
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _dbContext.Products;
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _dbContext.Products.SingleAsync(x => x.Id == id);
    }

    public async Task<bool> RemoveProduct(int id)
    {
        var newProd = _dbContext.Products.Single(p => p.Id == id);
        _dbContext.Remove(newProd);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var newProd = _dbContext.Products.Single(p => p.Id == product.Id);
        newProd.Name = product.Name;
        newProd.Price = product.Price;
        await _dbContext.SaveChangesAsync();
        return newProd;
    }
}
