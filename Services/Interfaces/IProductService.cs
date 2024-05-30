using EntityFrameworkCorePlayground.Models;

namespace Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Get All Products
    /// </summary>
    /// <returns></returns>
    IEnumerable<Product> GetAllProducts();

    /// <summary>
    /// Get a Product's Details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product> GetProduct(int id);

    /// <summary>
    /// Add a Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> AddProduct(Product product);

    /// <summary>
    /// Update a Product
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<Product> UpdateProduct(Product product);

    /// <summary>
    /// Remove a Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> RemoveProduct(int id);
}
