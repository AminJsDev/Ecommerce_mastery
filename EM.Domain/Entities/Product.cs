using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        public virtual Category Category { get; set; } // Add this navigation property

        // Navigation property for related images
        public string Icon { get; set; } // Add this property
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }


    }

}
