using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Models;
using AuthService.Domain.Models;

namespace AuthService.Application.Core.SendCode
{
    public class SendVerificationCodeCommandHandler(IEmailSender emailSender, ICacheService cacheService) : ICommandHandler<SendVerificationCodeCommand>
    {
        public async Task Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            var codeObject = new NotificationCode()
            {
                Email = request.Email,
                Code = new Random().Next(0, 10000)
            };

            await cacheService.SetAsync(request.Email, codeObject, TimeSpan.FromDays(1));

            var message = new EmailMessage()
            {
                ReceiverEmail = request.Email,
                Subject = "Подтверждение адреса электронной почты",
                Body = $"Код подтверждения: {codeObject.Code:d4}"   
            };

            await emailSender.SendMessage(message);
        }
    }
}