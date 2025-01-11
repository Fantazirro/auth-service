using FluentValidation;

namespace AuthService.Application.Core.ResetPassword
{
    internal class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}