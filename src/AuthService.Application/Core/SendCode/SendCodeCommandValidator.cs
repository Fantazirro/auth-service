using FluentValidation;

namespace AuthService.Application.Core.SendCode
{
    internal class SendCodeCommandValidator : AbstractValidator<SendCodeCommand>
    {
        public SendCodeCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}