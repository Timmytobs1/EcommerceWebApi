using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dtos.Product
{
    public class UpdateProductDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        [Range(1, 1000000000)]
        public decimal Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public DateTime LastModifiedAt { get; set; } = DateTime.Now;

    }
}
