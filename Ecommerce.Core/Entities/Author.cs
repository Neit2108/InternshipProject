using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public required string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Address { get; set; }
        [EmailAddress]
        [StringLength(255)]
        [Column(TypeName ="nvarchar(255)")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public required string Email { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? Bio { get; set; }
        public ICollection<Book> Books { get; set; } // 1 - nhiều sách
    }
}
