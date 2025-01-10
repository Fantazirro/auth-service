using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Exceptions;

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
            var getCachedToken = await cacheService.GetAsync<Guid>($"reset_{request.Email}");
            if (request.Token != getCachedToken) throw new BadRequestException("Invalid token");

            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException("User not found");

            user.PasswordHash = passwordHasher.Hash(request.NewPassword);

            userRepository.Update(user);
            await unitOfWork.Commit();
        }
    }
}