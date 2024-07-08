using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Models
{
    [Index("Name", IsUnique = true)]
  
    public class Category
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        public int SubCategory { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
      

    }
}
