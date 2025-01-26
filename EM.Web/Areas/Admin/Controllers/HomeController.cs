using EM.Domain.Entities;
using EM.Service;
using EM.ViewModels.Category;
using EM.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            // index something 
        {
            var products = await _productService.GetAllProductsAsync();

            var productViewModels = products.Select(p => new ProductDetailsViewModel
            {
                // Map properties from Product to ProductDetailsViewModel
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ImagePath,
                StockQuantity = p.StockQuantity,
                Description = p.Description,
                // Add other properties you need
            }).ToList();

            return View(productViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CategoryManagement()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            var categoriesViewModel = categories.Select(p => new CategoryViewModel
            {
                // Map properties from Product to ProductDetailsViewModel
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                // Add other properties you need
            }).ToList();

            return View(categoriesViewModel);
        }

    }
}
