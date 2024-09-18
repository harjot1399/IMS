using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository(ApplicationDBContext context) : ICategoryRepository
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // public Task<Category?> DeleteCategoryAsync(int id)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var Category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            return Category;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var Categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            return Categories;
        }

        public async Task<Category?> UpdateCategoryAsync(int id, Category category)
        {
            var exisitingCategory = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (exisitingCategory == null)
            {
                return null;
            }

            exisitingCategory.Name = category.Name;
            exisitingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
            return exisitingCategory;
        }

        public async Task<Category?> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }


        
    }
}