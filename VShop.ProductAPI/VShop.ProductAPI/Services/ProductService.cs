using AutoMapper;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Contracts;
using VShop.ProductAPI.Services.Contracts;

namespace VShop.ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AddNewProductAsync(ProductDto product)
    {
        var entity = _mapper.Map<Product>(product);
        await _productRepository.AddProductAsync(entity);
    }
    public async Task UpdateProductAsync(ProductDto product)
    {
        var entity = await _productRepository.GetProductByIdAsync(product.ProductId);
        if (entity == null) 
        {
            return;
        }
        entity.Price = product.Price;
        entity.Description = product.Description;
        entity.Name = product.Name;
        entity.Stock = product.Stock;
        entity.Category = product.Category;
        entity.CategoryId = product.CategoryId;
        entity.ImageUrl = product.ImageUrl;
        await _productRepository.UpdateProductAsync(entity);
    }
    public async Task<ProductDto> GetProductByIdAsync(string id)
    {
        var entity = await _productRepository.GetProductByIdAsync(id);
        return _mapper.Map<ProductDto>(entity);
    }


    public async Task DeleteProductByIdAsync(string id)
    {
        await _productRepository.DeleteProductAsync(id);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var entities = await _productRepository.GetAllProductsAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(entities);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsIncludeCategoryAsync()
    {
        var entities = await _productRepository.GetAllProductsIncludeCategoryAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(entities);
    }

    
}
