using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;

namespace AuthService.Application.Core.GetUser
{
    public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, Task<User?>>
    {
        public Task<User?> Handle(GetUserQuery request)
        {
            var user = userRepository.GetByEmail(request.Email);
            return user;
        }
    }
}