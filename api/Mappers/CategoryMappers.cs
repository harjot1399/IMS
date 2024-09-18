using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {

        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category.Products.Select(p => p.ToProductDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateCategoryDto (this CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description
            };
        }

        public static Category ToCategoryFromUpdateCategoryDto (this UpdateCategoryDto updateCategoryDto)
        {
            return new Category
            {
                Name = updateCategoryDto.Name,
                Description = updateCategoryDto.Description
            };
        }        
    }
}