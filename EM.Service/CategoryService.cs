using EM.Data;
using EM.Domain.Entities;
using EM.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Service
{

    public interface ICategoryService
    {
        Task<Product> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.Include(p => p.Products).ToListAsync();
    }

    public Task<Product> GetCategoryByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
