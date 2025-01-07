using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.CreateRefreshToken
{
    public record CreateRefreshTokenCommand(Guid UserId, int ExpirationTimeInMonths) : ICommand<Guid>;
}