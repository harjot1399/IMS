using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(int id);

        Task<Category> CreateCategoryAsync(Category category); 

        Task<Category?> UpdateCategoryAsync(int id, Category category);

        Task<Category?> DeleteCategoryAsync(int id);

    }
}