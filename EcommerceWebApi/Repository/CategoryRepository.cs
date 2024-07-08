using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Category;
using EcommerceWebApi.Dtos.User;
using EcommerceWebApi.Interface;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;

        }


        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var category = await _context.Categories.ToListAsync();
            return category;

        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Category?> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            category.Name = categoryDto.Name;
          

            await _context.SaveChangesAsync();
            return category;
        }
    }
}
