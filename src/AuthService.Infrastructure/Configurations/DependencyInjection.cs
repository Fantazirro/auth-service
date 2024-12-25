using AuthService.Application.Abstractions.Auth;
using AuthService.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserIdentifierProvider, UserIdentifierProvider>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}