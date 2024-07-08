﻿using EcommerceWebApi.Dtos.Category;
using EcommerceWebApi.Interface;
using EcommerceWebApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [Route("api/category")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository category)
        {
            _categoryRepository = category;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryDto = categories.Select(c => c.ToCategoryDto());
            return Ok(categoryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var categoryModel = categoryDto.ToCategoryFromCreateCategoryDto();
                Console.WriteLine(categoryModel.Name);
                Console.WriteLine(categoryModel);
                var category = await _categoryRepository.CreateCategoryAsync(categoryModel);
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category.ToCategoryDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto categoryDto, [FromRoute] Guid id)
        {
            var category = await _categoryRepository.UpdateCategoryAsync(id, categoryDto);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }


    }
}
