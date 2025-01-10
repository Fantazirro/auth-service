using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Abstractions.Options;
using AuthService.Application.Models;

namespace AuthService.Application.Core.ResetPassword
{
    public class ResetPasswordCommandHandler(
        IEmailSender emailSender,
        ICacheService cacheService,
        IResetPasswordOptions options) : ICommandHandler<ResetPasswordCommand>
    {
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var resetToken = Guid.NewGuid();
            await cacheService.SetAsync($"reset_{request.Email}", resetToken, TimeSpan.FromHours(1));

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