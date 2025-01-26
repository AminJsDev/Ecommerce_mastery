using EM.Data;
using EM.Domain.Entities;
using EM.Service;
using Microsoft.EntityFrameworkCore;
using System;

namespace EM.Service
{

    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddProductAsync(Product product)
    {
        if (product == null) { throw new ArgumentNullException(nameof(product)); }
        _context.Products.Add(product); 
        await _context.SaveChangesAsync();
    }

    public Task DeleteProductAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public Task<Product> GetProductByIdAsync(int productId)
    {
        throw new NotImplementedException("This method should be overridden in subclasses.");
        //return await _context.Products
        //    .Include(p => p.Images)
        //    .Include(p => p.CategoryId)
        //    .FirstOrDefaultAsync(p => p.Id == productId);
    }


    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
