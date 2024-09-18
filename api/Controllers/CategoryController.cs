using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Category;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var categoriesDTO = categories.Select(category => category.ToCategoryDto());
            return Ok(categoriesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found with specified id");
            }

            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = createCategoryDto.ToCategoryFromCreateCategoryDto();
            await _categoryRepository.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category.ToCategoryDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = updateCategoryDto.ToCategoryFromUpdateCategoryDto();
            var result = await _categoryRepository.UpdateCategoryAsync(id, updatedCategory);
            if (result == null)
            {
                return NotFound("Category not found with specified id");
            }

            return Ok(result.ToCategoryDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(id);
            if (result == null)
            {
                return NotFound("Category not found with specified id");
            }

            return Ok(result.ToCategoryDto());
        }
    }
}