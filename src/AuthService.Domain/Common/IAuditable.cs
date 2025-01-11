namespace AuthService.Domain.Common
{
    public interface IAuditable
    {
        string? CreatedBy { get; set; }
        DateTimeOffset CreatedOnUtc { get; set; }
        string? LastModifiedBy { get; set; }
        DateTimeOffset LastModifiedOnUtc { get; set; }
    }
}