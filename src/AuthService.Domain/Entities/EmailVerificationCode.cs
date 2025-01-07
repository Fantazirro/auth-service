namespace AuthService.Domain.Entities
{
    public class EmailVerificationCode
    {
        public string Email { get; set; } = null!;
        public int Code { get; set; }
    }
}