using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.SignIn
{
    public record SignInQuery(string Email, string Password) : IQuery<User>;
}