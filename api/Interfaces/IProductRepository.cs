using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();

        Task<Product?> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product?> UpdateProductAsync(int id, Product product);

        Task<Product?> DeleteProductAsync(int id);
    }
}