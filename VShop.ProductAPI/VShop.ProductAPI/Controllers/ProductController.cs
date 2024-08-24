using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using VShop.ProductAPI.DTOs;
using VShop.ProductAPI.Services.Contracts;

namespace VShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost] 
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(product);

            var productDto = await _productService.GetProductByIdAsync(product.ProductId);
            if (productDto is not null)
                return BadRequest("Product already exists!");

            await _productService.AddNewProductAsync(product);
            return Ok(product);
        }

        [HttpGet("{id:string}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Product not informed!");
            }
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null)
            {
                return NotFound("Product not found!");
            }
            return Ok(product);
        }

        [HttpDelete("{id:string}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("No product informed!");
         
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null)
                return NotFound("Product not found!");

            await _productService.DeleteProductByIdAsync(product.ProductId);
            return Ok(product);
        }

        [HttpPut("{id:string}")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product, string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("No product informed!");
            if (!ModelState.IsValid)
                return BadRequest(product);

            var entity = await _productService.GetProductByIdAsync(id);
            if (entity is null) 
            {
                return NotFound("Product not found!");
            }
            await _productService.UpdateProductAsync(entity);

            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = _productService.GetAllProductsAsync();
            if (products == null)
                return NotFound("No products found!");
            return Ok(products);
        }

        [HttpGet("/category")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllIncludeCategories()
        {
            var categories = _productService.GetAllProductsIncludeCategoryAsync();
            if (categories == null)
                return NotFound("No product found!");
            return Ok(categories);
        }
    }
}
