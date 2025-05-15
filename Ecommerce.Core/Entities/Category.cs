using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [StringLength(1000)]
        [Column(TypeName = "nvarchar")]
        public string? Description { get; set; }
        public ICollection<Book> Books { get; set; } // -> 1 Category - nhiều sách
    }
}
