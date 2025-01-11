using AuthService.Application.Abstractions.Options;

namespace AuthService.Infrastructure.Options
{
    public class ResetPasswordOptions : IResetPasswordOptions
    {
        public string Url { get; set; } = null!;
    }
}