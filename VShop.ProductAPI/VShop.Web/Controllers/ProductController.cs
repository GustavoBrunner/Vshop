using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,
                ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _productService.GetAllAsync();

            if (result == null) 
            {
                return View("Error", "Home");
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Register(string pid)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            SelectList listItems = new SelectList(categories,
                nameof(CategoryViewModel.CategoryId), nameof(CategoryViewModel.CategoryName));
            ViewBag.Categories = listItems;


            if (!string.IsNullOrEmpty(pid))
            {
                var product = await _productService.GetByIdAsync(pid);
                if (product is not null)
                {
                    return View(product);
                }
            }
            return View(new ProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(string pid, 
                [FromForm] ProductViewModel product)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction("Error", "Home");
            }
            var entity = await _productService.GetByIdAsync(pid);
            if (entity is not null) 
            {
                //if the entity exist in the database
                var entityUpdated = await _productService.UpdateProductAsync(entity);
                if (entityUpdated is null)
                {
                    //well succeded update
                    return RedirectToAction("Error", "Home");
                }
            }
            //if we are adding a new entity
            var newProduct = await _productService.CreateProductAsync(entity);
            if(newProduct is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
