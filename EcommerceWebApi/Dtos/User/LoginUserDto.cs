using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dtos.User
{
    public class LoginUserDto
    {

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(25)]
      
        public string Password { get; set; } = string.Empty;
    }
}
