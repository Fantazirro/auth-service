using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Models;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.ResetPassword
{
    // TODO: сделать сброс пароля по ссылке
    public class ResetPasswordCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IEmailSender emailSender) : ICommandHandler<ResetPasswordCommand>
    {
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var newPassword = Guid.NewGuid().ToString();

            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException("User not found");

            user.PasswordHash = passwordHasher.Hash(newPassword);

            userRepository.Update(user);
            await unitOfWork.Commit();

            var message = new EmailMessage()
            {
                ReceiverEmail = request.Email,
                Subject = "Сброс пароля",
                Body = $"Ваш новый пароль: {newPassword}"
            };

            await emailSender.SendMessage(message);
        }
    }
}