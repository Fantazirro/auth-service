using AuthService.Application.Abstractions.Options;
using FluentValidation;

namespace AuthService.Application.Core.ConfirmReset
{
    internal class ConfirmResetCommandValidator : AbstractValidator<ConfirmResetCommand>
    {
        public ConfirmResetCommandValidator(IUserOptions options)
        {
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.NewPassword).Length(options.PasswordMinLength, options.PasswordMaxLength);
        }
    }
}