using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Entities;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.VerifyRefreshToken
{
    public class GetRefreshTokenQueryHandler(IRefreshTokenRepository refreshTokenRepository) : IQueryHandler<GetRefreshTokenQuery, RefreshToken>
    {
        public async Task<RefreshToken> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var token = await refreshTokenRepository.GetById(request.Id);
            if (token is null) throw new NotFoundException($"This refresh token doesn't exists");

            return token;
        }
    }
}