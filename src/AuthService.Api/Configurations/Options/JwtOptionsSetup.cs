using AuthService.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AuthService.Api.Configurations.Options
{
    public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        public void Configure(JwtOptions options)
        {
            configuration.GetSection("JwtOptions").Bind(options);
        }
    }
}