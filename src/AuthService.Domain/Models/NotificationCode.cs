namespace AuthService.Domain.Models
{
    public class NotificationCode
    {
        public string Email { get; set; } = null!;
        public int Code { get; set; }
    }
}