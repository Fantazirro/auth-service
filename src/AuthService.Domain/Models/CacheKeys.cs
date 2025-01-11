namespace AuthService.Domain.Models
{
    public static class CacheKeys
    {
        private const string AccessTokenBlacklistTemplate = "access:{0}";
        private const string EmailVerificationCodeTemplate = "emailVerification:{0}";
        private const string ResetPasswordTokenTemplate = "reset:{0}";

        public static string AccessTokenBlacklist(string tokenHash) => string.Format(AccessTokenBlacklistTemplate, tokenHash);
        public static string EmailVerificationCode(string email) => string.Format(EmailVerificationCodeTemplate, email);
        public static string ResetPasswordToken(Guid token) => string.Format(ResetPasswordTokenTemplate, token);
    }
}