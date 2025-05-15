using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Users;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(string userId);
        Task AddUserAsync(UserRequest userRequest);
        Task UpdateUserAsync(UserRequest userRequest);
        Task DeleteUserAsync(string userId);
    }
}
