using EcommerceWebApi.Data;
using EcommerceWebApi.Dtos.Product;
using EcommerceWebApi.Interface;
using EcommerceWebApi.Mappers;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> CheckCategory(Guid categoryId)
        {
            return _context.Categories.AnyAsync(x => x.Id == categoryId);
        }


        public async Task<Product> CreateProduct(CreateProductDto productDto)
        {
            var productModel = productDto.ToProductFromCreate();
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }

        public async Task<Product?> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }


        public async Task<Product?> UpdateProduct(Guid id, UpdateProductDto product)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }


            productModel.Name = product.Name;
            productModel.Description = product.Description;
            productModel.Price = product.Price;
            productModel.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return productModel;
        }

     
    }
}
