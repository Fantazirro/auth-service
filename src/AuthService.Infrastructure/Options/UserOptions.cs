using AuthService.Application.Abstractions.Options;

namespace AuthService.Infrastructure.Options
{
    public class UserOptions : IUserOptions
    {
        public int PasswordMinLength { get; set; }
        public int PasswordMaxLength { get; set; }
    }
}