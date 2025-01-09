using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Abstractions.Options;
using AuthService.Infrastructure.Auth;
using AuthService.Infrastructure.Cache;
using AuthService.Infrastructure.Notifications;
using AuthService.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AuthService.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IEmailSender, EmailSender>();

            services
               .AddFluentEmail(configuration["SmtpOptions:SenderEmail"]!, configuration["SmtpOptions:Sender"]!)
               .AddSmtpSender(
                   configuration["SmtpOptions:Host"]!,
                   int.Parse(configuration["SmtpOptions:Port"]!));
                   //configuration["SmtpOptions:Username"]!,
                   //configuration["SmtpOptions:Password"]!);

            services.AddSingleton<IUserOptions>(serviceProvider => 
                serviceProvider.GetRequiredService<IOptions<UserOptions>>().Value);

            services.AddStackExchangeRedisCache(options => {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "auth_";
            });

            services.AddScoped<ICacheService, CacheService>();

            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("DatabaseConnection")!)
                .AddRedis(configuration.GetConnectionString("RedisConnection")!);

            return services;
        }
    }
}