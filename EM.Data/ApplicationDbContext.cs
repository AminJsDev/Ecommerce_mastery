using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Domain.Admin;
using EM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        // DbSet for core entities
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        // DbSet for admin-specific entities
        public DbSet<AdminActivityLog> AdminActivityLogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  // Each product has one category
                .WithMany(c => c.Products) // Each category can have many products
                .HasForeignKey(p => p.CategoryId) // Foreign key in Product table
                .OnDelete(DeleteBehavior.Cascade); // Delete products when a category is deleted

            // Relationship between ProductImage and Product
            //modelBuilder.Entity<ProductImage>()
            //    .HasOne(pi => pi.Product) // Each product image is related to one product
            //    .WithMany(p => p.Images) // A product can have many images
            //    .HasForeignKey(pi => pi.ProductId) // Foreign key in ProductImage table
            //    .OnDelete(DeleteBehavior.Cascade); // Delete images when a product is deleted

            // Relationship between OrderItem and Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order) // Each order item belongs to one order
                .WithMany(o => o.Items) // Each order can have many order items
                .HasForeignKey(oi => oi.OrderId); // Foreign key in OrderItem table

            // Relationship between OrderItem and Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product) // Each order item relates to one product
                .WithMany() // A product can have many order items
                .HasForeignKey(oi => oi.ProductId); // Foreign key in OrderItem table

            // Configuration for the User Role enum
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>(); // Save enum values as strings

            // Seed data into the Categories table
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "دیجیتالی",
                    Description = "محصولات دیجیتالی و الکترونیک"
                },
                new Category
                {
                    Id = 2,
                    Name = "کتاب ها",
                    Description = "کتاب ها و مجله ها"
                }
            );

            // Seed data into the Products table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "محصول 1",
                    Description = "توضیحات محصول 1",
                    Price = 29.99m,
                    StockQuantity = 100,
                    CategoryId = 1, // Assuming CategoryId 1 exists in your Categories table
                    ImagePath = "https://localhost:7246/images/test1.png"
                },
                new Product
                {
                    Id = 2,
                    Name = "محصول 2",
                    Description = "توضیحات محصول 2",
                    Price = 49.99m,
                    StockQuantity = 200,
                    CategoryId = 2, // Assuming CategoryId 2 exists in your Categories table,
                    ImagePath = "https://localhost:7246/images/test2.png"
                }
            );


            // Apply configurations for auditing, soft deletes, etc.
            base.OnModelCreating(modelBuilder);
        }


    }
}
