using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dtos.Category
{
    public class UpdateCategoryDto
    {

        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
