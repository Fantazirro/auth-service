using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.ConfirmEmail
{
    public record ConfirmEmailCommand(string Email, int Code) : ICommand;
}