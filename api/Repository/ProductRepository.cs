using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductRepository(ApplicationDBContext context) : IProductRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Product>> GetProductsAsync()
        {
            var Products = await _context.Products.ToListAsync();
            return Products;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return Product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (Product == null)
            {
                return null;
            }

            

            Product.Name = product.Name;
            Product.Description = product.Description;
            Product.Price = product.Price;
            Product.QuantityInStock = product.QuantityInStock;
            Product.CategoryId = product.CategoryId;
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (Product == null)
            {
                return null;
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
            return Product;
        }
        
    }
}