﻿namespace EM.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
