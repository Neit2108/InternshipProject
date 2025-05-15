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
        [Column(TypeName = "nvarchar(255)")]
        public required string Name { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName ="int")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required ICollection<Category> Categories { get; set; } // -> 1 sách - nhiều Category
        public required ICollection<Author> Authors { get; set; } // -> 1 sách - nhiều Author
    }
}
