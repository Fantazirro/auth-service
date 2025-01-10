using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.ConfirmReset
{
    public record ConfirmResetCommand(Guid Token, string Email, string NewPassword) : ICommand;
}