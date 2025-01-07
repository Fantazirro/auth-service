namespace AuthService.Application.Models
{
    public class EmailMessage
    {
        public string ReceiverEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}