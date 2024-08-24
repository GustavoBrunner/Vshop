using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories.Contracts;

public interface IProductRepository
{
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> GetProductByIdAsync(string id);
    Task<bool> DeleteProductAsync(string id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetAllProductsIncludeCategoryAsync();
}
