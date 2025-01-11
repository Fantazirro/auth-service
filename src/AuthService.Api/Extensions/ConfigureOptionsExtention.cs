using AuthService.Api.Configurations.Options;

namespace AuthService.Api.Extensions
{
    public static class ConfigureOptionsExtention
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.ConfigureOptions<UserOptionsSetup>();
            services.ConfigureOptions<ResetPasswordOptionsSetup>();

            return services;
        }
    }
}