using AuthService.Application.Abstractions.Options;
using FluentValidation;

namespace AuthService.Application.Core.ChangePassword
{
    internal class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator(IUserOptions options)
        {
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.CurrentPassword).Length(options.PasswordMinLength, options.PasswordMaxLength);
            RuleFor(request => request.NewPassword)
                .Length(options.PasswordMinLength, options.PasswordMaxLength)
                .Must((model, prop) => prop != model.CurrentPassword);
        }
    }
}