using AuthService.Application.Abstractions.Options;
using FluentValidation;

namespace AuthService.Application.Core.SignIn
{
    internal class SignInQueryValidator : AbstractValidator<SignInQuery>
    {
        public SignInQueryValidator(IUserOptions userOptions)
        {
            RuleFor(query => query.Email).EmailAddress();
            RuleFor(query => query.Password).Length(userOptions.PasswordMinLength, userOptions.PasswordMaxLength);
        }
    }
}