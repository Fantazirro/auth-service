using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.ChangePassword
{
    public record ChangePasswordCommand(string Email, string CurrentPassword, string NewPassword) : ICommand;
}