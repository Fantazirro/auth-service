#pragma warning disable RMG012, RMG020, RMG066

using AuthService.Application.Abstractions.Common;
using AuthService.Application.Core.CreateUser;
using AuthService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace AuthService.Application.Configurations
{
    [Mapper]
    public partial class Mapper
    {
        public partial User MapToUser(CreateUserCommand source);
    }
}