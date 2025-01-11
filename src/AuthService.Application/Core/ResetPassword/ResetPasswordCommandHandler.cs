using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Abstractions.Options;
using AuthService.Application.Models;
using AuthService.Domain.Exceptions;
using AuthService.Domain.Models;

namespace AuthService.Application.Core.ResetPassword
{
    public class ResetPasswordCommandHandler(
        IEmailSender emailSender,
        ICacheService cacheService,
        IUserRepository userRepository,
        IResetPasswordOptions options) : ICommandHandler<ResetPasswordCommand>
    {
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException($"User with email {request.Email} not found");

            var resetToken = Guid.NewGuid();
            await cacheService.SetAsync(CacheKeys.ResetPasswordToken(resetToken), request.Email, TimeSpan.FromHours(1));

            // TODO: отрефакторить
            var url = $"{options.Url}?token={resetToken}";

            var message = new EmailMessage()
            {
                ReceiverEmail = request.Email,
                Subject = "Сброс пароля",
                Body = $"Перейдите по ссылке для сброса пароля: {url}"
            };

            await emailSender.SendMessage(message);
        }
    }
}