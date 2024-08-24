using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories.Contracts;

public interface ICategoryRepository
{
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(string id);
    Task<Category> GetCategoryByIdAsync(string id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<IEnumerable<Category>> GetAllCategoriesIncludeProductsAsync();
}
