using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ecommerce.Core.Enums;

namespace Ecommerce.Core.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Column("nvarchar(255)")]
        public string Name { get; set; }
        [Column("nvarchar(1000)")]
        public string? Description { get; set; }
        [Required]
        [Column("decimal(18,2)")]
        [Range(0.0, 99999999999999.00)]
        public decimal Price { get; set; }
        [Required]
        [Column("int")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("CategoryId")]
        public ICollection<Category> Categories { get; set; } // -> 1 sách - nhiều Category
        public ICollection<Image> Images { get; set; } // -> 1 sách - nhiều Image
    }
}
