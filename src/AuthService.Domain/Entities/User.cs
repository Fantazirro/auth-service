using AuthService.Domain.Common;

namespace AuthService.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string? UserName { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool IsEmailConfirmed { get; set; }
    }
}