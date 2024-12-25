using AuthService.Application.Abstractions.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Mapper>();

            return services;
        }
    }
}