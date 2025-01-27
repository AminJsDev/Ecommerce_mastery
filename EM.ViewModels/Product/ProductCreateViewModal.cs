using EM.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EM.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Icon { get; set; }  // This will store the file path
        [Display(Name = "Product Image")]
        public IFormFile Image { get; set; } // For file uploads
    }
}