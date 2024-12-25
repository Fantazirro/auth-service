namespace AuthService.Application.Abstractions.Auth
{
    public interface IUserIdentifierProvider
    {
        Guid UserId { get; }
    }
}