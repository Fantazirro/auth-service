using FluentValidation;

namespace AuthService.Application.Core.ConfirmEmail
{
    internal class ConfirmEmailQueryValidator : AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailQueryValidator()
        {
            RuleFor(q => q.Email).EmailAddress();
            RuleFor(q => q.Code).InclusiveBetween(0, 9999);
        }
    }
}