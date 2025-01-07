namespace AuthService.Application.Core.ConfirmEmail
{
    public record ConfirmEmailQuery(string Email, int Code);
}