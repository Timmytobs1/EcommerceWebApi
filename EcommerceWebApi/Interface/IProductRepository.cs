using EcommerceWebApi.Dtos.Product;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Interface
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductById(Guid id);
        public Task<Product> CreateProduct(CreateProductDto productDto);
        public Task<Product?> UpdateProduct(Guid id, UpdateProductDto product);
        public Task<Product?> DeleteProduct(Guid id);
        public Task<bool> CheckCategory(Guid categoryId);
    }
}
