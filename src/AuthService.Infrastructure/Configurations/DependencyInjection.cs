﻿using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Options;
using AuthService.Infrastructure.Auth;
using AuthService.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AuthService.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserIdentifierProvider, UserIdentifierProvider>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IJwtProvider, JwtProvider>();

            services.AddSingleton<IUserOptions>(serviceProvider => 
                serviceProvider.GetRequiredService<IOptions<UserOptions>>().Value);

            return services;
        }
    }
}