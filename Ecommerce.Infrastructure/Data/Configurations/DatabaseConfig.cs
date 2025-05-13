using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Core.Entities;
using Ecommerce.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Data.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Ecommerce.Infrastructure")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<EcommerceDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
