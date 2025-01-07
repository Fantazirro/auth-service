using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.VerifyRefreshToken
{
    public record GetRefreshTokenQuery(Guid Id) : IQuery<RefreshToken>;
}