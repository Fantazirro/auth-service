namespace AuthService.Domain.Exceptions
{
    public abstract class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}