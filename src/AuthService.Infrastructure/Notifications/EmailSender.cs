using AuthService.Application.Abstractions.Notifications;
using AuthService.Application.Models;
using FluentEmail.Core;

namespace AuthService.Infrastructure.Notifications
{
    public class EmailSender(IFluentEmail fluentEmail) : IEmailSender
    {
        public async Task SendMessage(EmailMessage message)
        {
            await fluentEmail
                .To(message.ReceiverEmail)
                .Subject(message.Subject)
                .Body(message.Body)
                .SendAsync();
        }
    }
}