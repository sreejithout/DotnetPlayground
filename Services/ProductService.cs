using EntityFrameworkCorePlayground.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> AddProduct(Product product)
    {
        return await _productRepository.AddProduct(product);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _productRepository.GetProduct(id);
    }

    public async Task<bool> RemoveProduct(int id)
    {
        return await _productRepository.RemoveProduct(id);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        return await _productRepository.UpdateProduct(product);
    }
}
