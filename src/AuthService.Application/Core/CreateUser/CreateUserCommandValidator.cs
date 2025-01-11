using AuthService.Application.Abstractions.Options;
using FluentValidation;

namespace AuthService.Application.Core.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserOptions userOptions)
        {
            RuleFor(command => command.Email).EmailAddress();
            RuleFor(command => command.Password).Length(userOptions.PasswordMinLength, userOptions.PasswordMaxLength);
        }
    }
}