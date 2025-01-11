using AuthService.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AuthService.Api.Configurations.Options
{
    public class ResetPasswordOptionsSetup(IConfiguration configuration) : IConfigureOptions<ResetPasswordOptions>
    {
        public void Configure(ResetPasswordOptions options)
        {
            options.Url = configuration["ClientUrls:ResetPasswordUrl"]!;
        }
    }
}