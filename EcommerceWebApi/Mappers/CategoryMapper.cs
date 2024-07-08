using EcommerceWebApi.Dtos.Category;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToCategoryFromCreateCategoryDto(this CreateCategoryDto categoryDto)
        {
           
            return new Category
            {
                Name = categoryDto.Name,
              
            };
        }

        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                SubCategory = category.SubCategory,
             
            };
        }

    }
}
