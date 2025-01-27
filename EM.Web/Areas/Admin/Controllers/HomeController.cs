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
                Image = p.Icon,
                StockQuantity = p.StockQuantity,
                Description = p.Description,
                // Add other properties you need
            }).ToList();

            return View(productViewModels);
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


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel =  new ProductCreateViewModel
            {
                categories = _categoryService.GetAllCategoriesAsync()
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Icon != null)
                {
                    // Generate a unique file name
                    var fileName = Path.GetFileNameWithoutExtension(product.Image.FileName);
                    var extension = Path.GetExtension(product.Image.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                    // Save the file to wwwroot/images
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.Icon.CopyToAsync(fileStream);
                    }

                    // Set the image path to be saved in the database
                    product.Icon = $"/images/{uniqueFileName}";
                }

                await _productService.AddProductAsync(product);
                return RedirectToAction("index");
            }

            return View(product);
        }

        [HttpPost("Upload/UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("فایلی وجود ندارد ");
            }

            // مسیر روت پروژه
            var rootPath = Directory.GetCurrentDirectory(); // مسیر روت پروژه

            // مسیر ذخیره‌سازی فایل در روت پروژه (در کنار فایل‌های دیگر)
            var filePath = Path.Combine(rootPath, file.FileName);

            // ذخیره‌سازی فایل
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Content($"File {file.FileName} uploaded successfully.");
        }

    }
}
