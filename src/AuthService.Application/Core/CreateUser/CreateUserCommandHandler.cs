using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Configurations;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.CreateUser
{
    public class CreateUserCommandHandler(
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        Mapper mapper)
        : IRequestHandler<CreateUserCommand, bool>
    {
        public async Task<bool> Handle(CreateUserCommand request)
        {
            var existingUser = await userRepository.GetByEmail(request.Email);
            if (existingUser is not null) throw new BadRequestException($"User with email {request.Email} already exists");

            var user = mapper.MapToUser(request);
            user.PasswordHash = passwordHasher.Hash(request.Password);

            await userRepository.Add(user);
            await unitOfWork.Commit();

            return true;
        }
    }
}