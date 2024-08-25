using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface ICategoryService
{
    Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel categoryViewModel);
    
    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

    Task<CategoryViewModel> GetCategoryByIdAsync(string id);

    Task<CategoryViewModel> UpdateCategoryAsync(CategoryViewModel categoryViewModel);

    Task<bool> DeleteCategoryAsync(int id);
}
