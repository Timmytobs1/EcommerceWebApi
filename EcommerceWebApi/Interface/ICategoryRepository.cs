using EcommerceWebApi.Dtos.Category;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category?> GetCategoryByIdAsync(Guid id);
        public Task<Category> CreateCategoryAsync(Category category);
        public Task<Category?> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto);
        public Task<Category?> DeleteCategory(Guid id);
    }
}
