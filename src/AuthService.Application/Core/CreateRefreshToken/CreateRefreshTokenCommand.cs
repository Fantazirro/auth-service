namespace AuthService.Application.Core.CreateRefreshToken
{
    public record CreateRefreshTokenCommand(Guid UserId, int ExpirationTimeInMonths);
}