using EntityFrameworkCorePlayground.Models;

namespace Repositories.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Get All Products
    /// </summary>
    /// <returns></returns>
    Task<List<Product>> GetAllProducts(CancellationToken token);

    /// <summary>
    /// Get a Product's Details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product> GetProduct(int id, CancellationToken token);

    /// <summary>
    /// Add a Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> AddProduct(Product product, CancellationToken token);

    /// <summary>
    /// Update a Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<Product> UpdateProduct(Product product, CancellationToken token);

    /// <summary>
    /// Remove a Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> RemoveProduct(int id, CancellationToken token);
}
