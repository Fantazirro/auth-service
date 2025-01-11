using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.ChangePassword
{
    public class ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IUserIdentifierProvider userIdentifierProvider) : ICommandHandler<ChangePasswordCommand>
    {
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException("User not found");

            if (user.Id != userIdentifierProvider.UserId)
                throw new BadRequestException("Invalid user data");

            if (!passwordHasher.Verify(request.CurrentPassword!, user.PasswordHash))
                throw new BadRequestException("Incorrect password");

            user.PasswordHash = passwordHasher.Hash(request.NewPassword);

            userRepository.Update(user);
            await unitOfWork.Commit();
        }
    }
}