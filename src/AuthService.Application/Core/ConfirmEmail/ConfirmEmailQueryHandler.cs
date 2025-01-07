using AuthService.Application.Abstractions.Common;
using AuthService.Domain.Entities;
using AuthService.Domain.Exceptions;

namespace AuthService.Application.Core.ConfirmEmail
{
    public class ConfirmEmailQueryHandler(ICacheService cacheService) : IRequestHandler<ConfirmEmailQuery, bool>
    {
        public async Task<bool> Handle(ConfirmEmailQuery request)
        {
            var codeObject = await cacheService.GetAsync<EmailVerificationCode>(request.Email);
            if (codeObject is null) throw new NotFoundException("Verification code not found");

            if (request.Code != codeObject.Code) throw new BadRequestException("Incorrect verification code");

            return true;
        }
    }
}