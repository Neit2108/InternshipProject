using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(EcommerceDbContext context, UserManager<User> userManager, ILogger<UserRepository> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                var users = await _context.Users
                    .ToListAsync();
                if(!users.Any())
                {
                    throw new Exception("No users found");
                }
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy user : {ex}", ex.Message);
                return null;
            }
        }
        public async Task<IEnumerable<string>> GetRoleAsync(string userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return await _userManager.GetRolesAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy role của user : {ex}", ex.Message);
                return null;
            }
        }
        public Task<User> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
