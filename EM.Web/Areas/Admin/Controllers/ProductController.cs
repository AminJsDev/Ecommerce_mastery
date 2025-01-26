using EM.Domain.Entities;
using EM.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
        }

        [HttpGet("Create")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Image != null)
                {
                    // Generate a unique file name
                    var fileName = Path.GetFileNameWithoutExtension(product.Image.FileName);
                    var extension = Path.GetExtension(product.Image.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                    // Save the file to wwwroot/images
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.Image.CopyToAsync(fileStream);
                    }

                    // Set the image path to be saved in the database
                    product.ImagePath = $"/images/{uniqueFileName}";
                }

                await _productService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


    }
}
