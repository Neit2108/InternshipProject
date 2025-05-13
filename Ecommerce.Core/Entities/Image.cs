using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.Entities
{
    [Index(nameof(ReferenceId), nameof(ReferenceType))]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReferenceId { get; set; }
        [Required]
        public ImageType ReferenceType { get; set; }
        [Required]
        [StringLength(1000)]
        public required string Url { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
