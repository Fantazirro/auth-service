using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Entities;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.SignIn
{
    public class SignInQueryHandler(
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher) : IQueryHandler<SignInQuery, User>
    {
        public async Task<User> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException($"User with email {request.Email} doesn't exists");

            if (!passwordHasher.Verify(request.Password, user.PasswordHash)) throw new BadRequestException("Incorrect password");

            return user;
        }
    }
}