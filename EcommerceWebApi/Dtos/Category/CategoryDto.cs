namespace EcommerceWebApi.Dtos.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int SubCategory { get; set; } = 0;

    }
}
