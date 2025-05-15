using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Auths;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterRequest registerRequest);
        Task<bool> Login(LoginRequest loginRequest);
    }
}
