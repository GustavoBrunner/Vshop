using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Context;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Contracts;

namespace VShop.ProductAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductApiContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryRepository(ProductApiContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        var prod = await _context.Categories.AddAsync(category);
        if(!await _unitOfWork.SaveChangesAsync())
        {
            return null;
        }
        return prod.Entity;
    }
    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        if(!await _unitOfWork.SaveChangesAsync() )
        {
            return null;
        }
        return category;
    }
    public async Task<Category> GetCategoryByIdAsync(string id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    public async Task<bool> DeleteCategoryAsync(string id)
    {
        var category = await GetCategoryByIdAsync(id);
        _context.Categories?.Remove(category);

        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .OrderBy(c => c.CategoryName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesIncludeProductsAsync()
    {
        return await _context.Categories 
            .AsNoTracking()
            .OrderBy(c => c.CategoryName)
            .Include(c => c.Products)
            .ToListAsync();
    }
    private async Task<bool> CheckIfExists(string id)
    {
        return await _context.Categories.AnyAsync(c => c.CategoryId == id);
    }
}
