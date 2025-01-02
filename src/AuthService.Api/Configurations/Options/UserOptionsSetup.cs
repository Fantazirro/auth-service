using AuthService.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AuthService.Api.Configurations.Options
{
    public class UserOptionsSetup(IConfiguration configuration) : IConfigureOptions<UserOptions>
    {
        public void Configure(UserOptions options)
        {
            configuration.GetRequiredSection("UserOptions").Bind(options);
        }
    }
}