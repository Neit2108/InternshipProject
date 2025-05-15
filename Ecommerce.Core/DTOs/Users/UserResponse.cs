using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTOs.Users
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public List<string> Roles { get; set; } 
        public string AvatarUrl { get; set; }
    }
}
