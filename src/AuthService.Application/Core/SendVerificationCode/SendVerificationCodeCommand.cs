using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.SendCode
{
    public record SendVerificationCodeCommand(string Email) : ICommand;
}