using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Auths;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthService> _logger;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<bool> Login(LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return false;
            }

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, false, false);

            return result.Succeeded;
        }
        public async Task<bool> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return false;
            }

            var existingUser = await _userManager.FindByEmailAsync(registerRequest.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("User with email {Email} already exists.", registerRequest.Email);
                return false;
            }

            var user = new User
            {
                FullName = registerRequest.FullName,
                Email = registerRequest.Email,
                UserName = registerRequest.Email,
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User {Id} created successfully.", user.Id);
                return true;
            }
            else
            {
                _logger.LogError("Error creating user {Id}: {Errors}", user.Id, string.Join(", ", result.Errors.Select(e => e.Description)));
                return false;
            }
        }
    }

}
