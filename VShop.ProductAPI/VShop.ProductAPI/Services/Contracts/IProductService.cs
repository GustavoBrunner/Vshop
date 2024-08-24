using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services.Contracts;

public interface IProductService
{

    Task<ProductDto> GetProductByIdAsync(string id);
    Task DeleteProductByIdAsync(string id);
    Task AddNewProductAsync(ProductDto product);
    Task UpdateProductAsync(ProductDto product);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductDto>> GetAllProductsIncludeCategoryAsync();


}