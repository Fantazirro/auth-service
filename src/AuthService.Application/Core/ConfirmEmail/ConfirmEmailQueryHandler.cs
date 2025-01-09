﻿using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Exceptions;
using AuthService.Domain.Models;

namespace AuthService.Application.Core.ConfirmEmail
{
    public class ConfirmEmailQueryHandler(ICacheService cacheService) : IQueryHandler<ConfirmEmailQuery>
    {
        public async Task Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var codeObject = await cacheService.GetAsync<NotificationCode>(request.Email);
            if (codeObject is null) throw new NotFoundException("Verification code not found");

            if (request.Code != codeObject.Code) throw new BadRequestException("Incorrect verification code");
        }
    }
}