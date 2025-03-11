using FluentValidation;

namespace AuthService.Application.Core.ConfirmEmail
{
    internal class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Code).InclusiveBetween(0, 9999);
        }
    }
}