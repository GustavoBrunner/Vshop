using AutoMapper;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories.Contracts;
using VShop.ProductAPI.Services.Contracts;

namespace VShop.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(CategoryDto category)
        {
            var entity = _mapper.Map<Category>(category);
            await _categoryRepository.AddCategoryAsync(entity);
        }
        public async Task UpdateCategoryAsync(CategoryDto category)
        {
            var entity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateCategoryAsync(entity);
        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }


        public async Task<CategoryDto> GetCategoryByIdAsync(string id)
        {
            var entity = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var entities = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(entities);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesIncludeProductsAsync()
        {
            var entities = await _categoryRepository.GetAllCategoriesIncludeProductsAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(entities);
        }
    }
}
