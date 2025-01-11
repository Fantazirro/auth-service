using AuthService.Application.Abstractions.Options;
using FluentValidation;

namespace AuthService.Application.Core.ConfirmReset
{
    internal class ConfirmResetCommandValidator : AbstractValidator<ConfirmResetCommand>
    {
        public ConfirmResetCommandValidator(IUserOptions options)
        {
            RuleFor(command => command.NewPassword).Length(options.PasswordMinLength, options.PasswordMaxLength);
        }
    }
}