using Microsoft.AspNetCore.Mvc;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index()
            {
            var result = await _productService.GetAllAsync();
            
            return View(result);
        }
    }
}
