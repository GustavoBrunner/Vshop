using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Context;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Contracts;

namespace VShop.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductApiContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ProductRepository(ProductApiContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        await _context.AddAsync(product);
        if (!await _unitOfWork.SaveChangesAsync()) 
        {
            return null;
        }
        return product;
    }
    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        if (!await _unitOfWork.SaveChangesAsync())
        {
            return null;
        }
        return product;
    }
    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }
    public async Task<bool> DeleteProductAsync(string id)
    {
        if (await CheckIfExists(id))
        {
            var product = GetProductByIdAsync(id);
            _context.Entry(product).State = EntityState.Deleted;
            if(!await _unitOfWork.SaveChangesAsync())
            {
                return false;
            }
        }
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsIncludeCategoryAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    private async Task<bool> CheckIfExists(string id)
    {
        return await _context.Products.AnyAsync(p => p.ProductId == id);
    }
}
