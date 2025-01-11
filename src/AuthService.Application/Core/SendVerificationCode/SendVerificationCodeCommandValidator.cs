using FluentValidation;

namespace AuthService.Application.Core.SendCode
{
    internal class SendVerificationCodeCommandValidator : AbstractValidator<SendVerificationCodeCommand>
    {
        public SendVerificationCodeCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}