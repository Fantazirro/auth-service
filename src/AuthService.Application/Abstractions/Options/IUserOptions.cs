namespace AuthService.Application.Abstractions.Options
{
    public interface IUserOptions
    {
        int PasswordMinLength { get; set; }
        int PasswordMaxLength { get; set; }
    }
}