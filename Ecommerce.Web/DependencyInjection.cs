using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Services;
using Ecommerce.Infrastructure.Data.Repositories;
using Ecommerce.Web.Services;

namespace Ecommerce.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            // Book 
            services.AddScoped<BookViewService>();

            return services;
        }
    }
}
