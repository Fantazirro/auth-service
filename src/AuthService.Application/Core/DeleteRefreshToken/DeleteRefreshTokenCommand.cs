using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.DeleteRefreshToken
{
    public record DeleteRefreshTokenCommand(Guid Id) : ICommand;
}