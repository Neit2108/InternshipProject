using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ecommerce.Core.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ecommerce.Core.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public required string FullName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
        [EnumDataType(typeof(Gender))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? AvatarUrl { get; set; }

    }
}
