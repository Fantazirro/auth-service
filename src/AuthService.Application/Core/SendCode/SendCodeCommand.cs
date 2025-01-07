using AuthService.Application.Abstractions.Messaging;

namespace AuthService.Application.Core.SendCode
{
    public record SendCodeCommand(string Email) : ICommand;
}