using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto (this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                CategoryId = product.CategoryId
            };
        }

        public static Product ToProductFromCreateProductDto (this CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                QuantityInStock = createProductDto.QuantityInStock,
                CategoryId = createProductDto.CategoryId
            };
        }

        public static Product ToProductFromUpdateProductDto (this UpdateProductDto updateProductDto)
        {
            return new Product
            {
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                QuantityInStock = updateProductDto.QuantityInStock,
                CategoryId = updateProductDto.CategoryId
            };
        }
    }
}