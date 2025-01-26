using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }                 // Unique identifier for the image
        public int ProductId { get; set; }         // Foreign key to the associated product
        public Product Product { get; set; }       // Navigation property for the associated product
        public string Url { get; set; }            // URL or file path of the image
        public string AltText { get; set; }        // Alternative text for accessibility
        public bool IsPrimary { get; set; }        // Indicates if this is the primary image for the product
        public DateTime CreatedAt { get; set; }    // Timestamp for when the image was added
    }

}
