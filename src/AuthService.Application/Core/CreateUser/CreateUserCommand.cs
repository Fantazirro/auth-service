using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.CreateUser
{
    public record CreateUserCommand(string Email, string Password) : ICommand;
}