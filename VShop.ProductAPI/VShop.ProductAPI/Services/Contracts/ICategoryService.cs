using VShop.ProductAPI.DTOs;

namespace VShop.ProductAPI.Services.Contracts;

public interface ICategoryService
{
    Task<CategoryDto> GetCategoryByIdAsync(string id);
    Task AddCategoryAsync(CategoryDto category);
    Task UpdateCategoryAsync(CategoryDto category);
    Task<bool> DeleteCategoryAsync(string id);

    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<IEnumerable<CategoryDto>> GetAllCategoriesIncludeProductsAsync();
}