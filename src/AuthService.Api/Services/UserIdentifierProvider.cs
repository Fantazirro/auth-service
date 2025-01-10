using AuthService.Application.Abstractions.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthService.Api.Services
{
    public class UserIdentifierProvider : IUserIdentifierProvider
    {
        public Guid UserId { get; }

        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                ?? throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));

            UserId = new Guid(userIdClaim.Value);
        }
    }
}