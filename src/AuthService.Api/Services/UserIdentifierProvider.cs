﻿using AuthService.Application.Abstractions.Auth;
using System.IdentityModel.Tokens.Jwt;

namespace AuthService.Api.Services
{
    public class UserIdentifierProvider : IUserIdentifierProvider
    {
        public Guid UserId { get; }

        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)
                ?? throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));

            UserId = new Guid(userIdClaim.Value);
        }
    }
}