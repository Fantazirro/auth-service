using AuthService.Application.Models;

namespace AuthService.Application.Abstractions.Notifications
{
    public interface IEmailSender
    {
        Task SendMessage(EmailMessage message);
    }
}