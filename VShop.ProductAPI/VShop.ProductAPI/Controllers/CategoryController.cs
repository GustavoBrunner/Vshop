using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Services.Contracts;

namespace VShop.ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService) 
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var category = await _categoryService.GetCategoryByIdAsync(categoryDto.CategoryId);
        if(category is not null)
            return BadRequest("Category already exists!");

        await _categoryService.AddCategoryAsync(categoryDto);
        return new CreatedAtRouteResult("GetCategory",
            new { id = category.CategoryId }, category);
    }

    [HttpGet("{id}", Name ="GetCategory")]
    public async Task<ActionResult<CategoryDto>> GetCategory(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("No category informed");
        var category = await _categoryService.GetCategoryByIdAsync(id);
        
        if (category is null)
            return NotFound("Category not found!");

        return Ok(category);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
    {
        var entities = await _categoryService.GetAllCategoriesAsync();
        if (entities is null)
            return NotFound("No category found!");

        return Ok(entities);
    }

    [HttpGet("/products")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategoriesIncludeProducts()
    {
        var entities = await _categoryService.GetAllCategoriesIncludeProductsAsync();
        if (entities is null)
            return NotFound("No category found!");

        return Ok(entities);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCategory([FromBody] CategoryDto categoryDto, string id)
    {
        if (categoryDto.CategoryId != id)
            return BadRequest();

        if (!string.IsNullOrEmpty(id))
            return BadRequest("No category informed!");

        if (!ModelState.IsValid)
            return BadRequest(categoryDto);

        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category is null)
            return NotFound("Category not found!");
        await _categoryService.UpdateCategoryAsync(category);

        return Ok(category);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("No category informed!");

        bool result = await _categoryService.DeleteCategoryAsync(id);
        if (!result)
            return NotFound("Category does not exist!");

        return Ok();
    }

}