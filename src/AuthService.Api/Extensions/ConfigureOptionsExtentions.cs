using AuthService.Api.Configurations.Options;

namespace AuthService.Api.Extensions
{
    public static class ConfigureOptionsExtentions
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<UserOptionsSetup>();

            return services;
        }
    }
}