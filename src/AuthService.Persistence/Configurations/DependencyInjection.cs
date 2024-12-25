using AuthService.Application.Abstractions.Data;
using AuthService.Persistence.Interceptors;
using AuthService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Persistence.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<AuditInterceptor>();

            services.AddDbContext<AuthDbContext>((serviceProvider, options) =>
            {
                var auditInterceptor = serviceProvider.GetService<AuditInterceptor>()!;

                options
                    .UseNpgsql("Host=localhost;Port=5432;Database=auth-service;Username=postgres;Password=postgres")
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(auditInterceptor);
            });

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AuthDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}