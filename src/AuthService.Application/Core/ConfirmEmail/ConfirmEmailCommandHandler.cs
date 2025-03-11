using AuthService.Application.Abstractions.Common;
using AuthService.Application.Abstractions.Messaging;
using AuthService.Domain.Exceptions;
using AuthService.Domain.Models;

namespace AuthService.Application.Core.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(ICacheService cacheService) : ICommandHandler<ConfirmEmailCommand>
    {
        public async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var isKeyExists = await cacheService.ContainsKey(CacheKeys.EmailVerificationCode(request.Email));
            if (!isKeyExists) throw new NotFoundException("Verification code not found");

            var codeObject = await cacheService.GetAsync<NotificationCode>(CacheKeys.EmailVerificationCode(request.Email));

            if (request.Code != codeObject.Code) throw new BadRequestException("Incorrect verification code");

            await cacheService.RemoveAsync(CacheKeys.EmailVerificationCode(request.Email));
        }
    }
}