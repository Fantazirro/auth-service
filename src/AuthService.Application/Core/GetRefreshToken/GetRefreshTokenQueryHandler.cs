using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.VerifyRefreshToken
{
    public class GetRefreshTokenQueryHandler(IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<GetRefreshTokenQuery, Task<RefreshToken>>
    {
        public async Task<RefreshToken> Handle(GetRefreshTokenQuery request)
        {
            var token = await refreshTokenRepository.GetById(request.Id);
            if (token is null) throw new NotFoundException($"This refresh token doesn't exists");

            return token;
        }
    }
}