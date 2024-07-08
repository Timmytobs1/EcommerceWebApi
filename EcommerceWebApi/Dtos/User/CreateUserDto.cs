﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(25)]
        public string Password { get; set; } = string.Empty;
    }
}