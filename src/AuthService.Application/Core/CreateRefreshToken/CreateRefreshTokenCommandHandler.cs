using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.CreateRefreshToken
{
    public class CreateRefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateRefreshTokenCommand, Task<Guid>>
    {
        public async Task<Guid> Handle(CreateRefreshTokenCommand request)
        {
            var token = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                ExpiredAtUtc = DateTime.UtcNow.AddMonths(6)
            };

            await refreshTokenRepository.Add(token);
            await unitOfWork.Commit();

            return token.Id;
        }
    }
}