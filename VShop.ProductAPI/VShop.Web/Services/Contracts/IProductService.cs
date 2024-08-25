using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<ProductViewModel> CreateProductAsync(ProductViewModel model);
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetByIdAsync(string id);
    Task<ProductViewModel> UpdateProductAsync(ProductViewModel model);
    Task<bool> DeleteProductAsync(string id);
}
