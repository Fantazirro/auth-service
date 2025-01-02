﻿using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.SignIn
{
    public class SignInQueryHandler(
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher) : IRequestHandler<SignInQuery, Task<User>>
    {
        public async Task<User> Handle(SignInQuery request)
        {
            var user = await userRepository.GetByEmail(request.Email);
            if (user is null) throw new NotFoundException($"User with email {request.Email} doesn't exists");

            if (!passwordHasher.Verify(request.Password, user.PasswordHash)) throw new BadRequestException("Incorrect password");

            return user;
        }
    }
}