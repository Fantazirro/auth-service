namespace AuthService.Domain.Common
{
    public class BaseEntity : IAuditable
    {
        public Guid Id { get; set; }
        public string? CreatedBy {  get; set; }
        public DateTimeOffset CreatedOnUtc { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset LastModifiedOnUtc { get; set; }
    }
}