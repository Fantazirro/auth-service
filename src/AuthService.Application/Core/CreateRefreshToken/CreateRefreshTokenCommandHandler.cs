using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.CreateRefreshToken
{
    public class CreateRefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateRefreshTokenCommand, Guid>
    {
        public async Task<Guid> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                ExpiredAtUtc = DateTimeOffset.UtcNow.AddMonths(request.ExpirationTimeInMonths)
            };

            await refreshTokenRepository.Add(token);
            await unitOfWork.Commit();

            return token.Id;
        }
    }
}