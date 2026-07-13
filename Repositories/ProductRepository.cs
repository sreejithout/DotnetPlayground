using EntityFrameworkCorePlayground.Data;
using EntityFrameworkCorePlayground.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Repositories.Interfaces;

namespace Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly DummyDbContext _dbContext;
    private readonly HybridCache _hybridCache;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext"></param>
    public ProductRepository(DummyDbContext dbContext)
    {
        _dbContext = dbContext;
        _hybridCache = _hybridCache;
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
        string cacheKey = $"product:{id}";

        // GetOrCreateAsync does all the heavy lifting
        return await _hybridCache.GetOrCreateAsync(
            cacheKey,
            async cancelToken =>
            {
                // This factory only runs if the cache is completely empty for this key
                // and it only runs ONCE even if 100 requests hit it at the same time.
                return await _dbContext.Products.FindAsync([id], cancelToken);
            },
            options: null, // Use global defaults, or pass specific HybridCacheEntryOptions here
            tags: ["all-products"], // Tags for easy invalidation
            cancellationToken: token
        );
    }

    public async Task<bool> RemoveProduct(int id, CancellationToken token)
    {
        var product = await this.GetProduct(id, token);
        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync(token);
        // Evict the specific item from the cache
        await _hybridCache.RemoveAsync($"product:{product.Id}", token);

        // OR: If you updated multiple products, you can clear by tag
        // await _hybridCache.RemoveByTagAsync("all-products", token);
        return true;
    }

    public async Task<Product> UpdateProduct(Product product, CancellationToken token)
    {
        var newProd = _dbContext.Products.Single(p => p.Id == product.Id);
        newProd.Name = product.Name;
        newProd.Price = product.Price;
        await _dbContext.SaveChangesAsync(token);
        // Evict the specific item from the cache
        await _hybridCache.RemoveAsync($"product:{product.Id}", token);

        // OR: If you updated multiple products, you can clear by tag
        // await _hybridCache.RemoveByTagAsync("all-products", token);
        return newProd;
    }
}
