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

    public async Task<bool> AddProduct(Product product, CancellationToken token)
    {
        return await _productRepository.AddProduct(product, token);
    }

    public async Task<List<Product>> GetAllProducts(CancellationToken token)
    {
        return await _productRepository.GetAllProducts(token);
    }

    public async Task<Product> GetProduct(int id, CancellationToken token)
    {
        return await _productRepository.GetProduct(id, token);
    }

    public async Task<bool> RemoveProduct(int id, CancellationToken token)
    {
        return await _productRepository.RemoveProduct(id, token);
    }

    public async Task<Product> UpdateProduct(Product product, CancellationToken token)
    {
        return await _productRepository.UpdateProduct(product, token);
    }
}
