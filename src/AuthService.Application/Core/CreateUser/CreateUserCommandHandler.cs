using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Application.Configurations;

namespace AuthService.Application.Core.CreateUser
{
    public class CreateUserCommandHandler(
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        Mapper mapper)
        : IRequestHandler<CreateUserCommand, Task>
    {
        public async Task Handle(CreateUserCommand request)
        {
            var user = mapper.MapToUser(request);
            user.PasswordHash = passwordHasher.Hash(request.Password);

            await userRepository.Add(user);
            await unitOfWork.Commit();
        }
    }
}