namespace EcommerceWebApi.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
