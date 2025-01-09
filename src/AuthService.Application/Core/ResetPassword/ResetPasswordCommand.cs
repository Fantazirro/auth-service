using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.ResetPassword
{
    public record ResetPasswordCommand(string Email) : ICommand;
}