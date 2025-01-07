using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Models;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.SendCode
{
    public class SendCodeCommandHandler(IEmailSender emailSender, ICacheService cacheService) : IRequestHandler<SendCodeCommand, bool>
    {
        public async Task<bool> Handle(SendCodeCommand request)
        {
            var codeObject = new EmailVerificationCode()
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

            return true;
        }
    }
}