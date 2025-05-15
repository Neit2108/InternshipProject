using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Users;
using Ecommerce.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public Task AddUserAsync(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                if (!users.Any())
                {
                    _logger.LogError("Lỗi khi lấy user tại Service");
                    return null;
                }
                var userResponses = users.Select(async user => new UserResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    BirthDay = user.BirthDay,
                    Roles = (await _userRepository.GetRoleAsync(user.Id)).ToList(),
                }).ToList();
                return await Task.WhenAll(userResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy user : {ex}", ex.Message);
                return null;
            }
        }
        public Task<UserResponse> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public Task UpdateUserAsync(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }
    }
}
