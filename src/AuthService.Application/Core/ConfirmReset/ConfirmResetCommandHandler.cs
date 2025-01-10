using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Exceptions;
using AuthService.Domain.Models;

namespace AuthService.Application.Core.ConfirmReset
{
    public class ConfirmResetCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ICacheService cacheService) : ICommandHandler<ConfirmResetCommand>
    {
        public async Task Handle(ConfirmResetCommand request, CancellationToken cancellationToken)
        {
            var isTokenValid = await cacheService.ContainsKey(CacheKeys.ResetPasswordToken(request.Token));
            if (!isTokenValid) throw new BadRequestException("Invalid token");

            var email = await cacheService.GetAsync<string>(CacheKeys.ResetPasswordToken(request.Token));

            var user = await userRepository.GetByEmail(email);
            user!.PasswordHash = passwordHasher.Hash(request.NewPassword);

            userRepository.Update(user);
            await unitOfWork.Commit();

            await cacheService.RemoveAsync(CacheKeys.ResetPasswordToken(request.Token));
        }
    }
}