using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.DeleteRefreshToken
{
    public class DeleteRefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteRefreshTokenCommand, bool>
    {
        public async Task<bool> Handle(DeleteRefreshTokenCommand request)
        {
            var token = await refreshTokenRepository.GetById(request.Id);
            if (token is null) throw new NotFoundException($"This refresh token doesn't exists");

            refreshTokenRepository.Delete(token);
            await unitOfWork.Commit();

            return true;
        }
    }
}