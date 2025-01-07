using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.ConfirmEmail
{
    public record ConfirmEmailQuery(string Email, int Code) : IQuery;
}