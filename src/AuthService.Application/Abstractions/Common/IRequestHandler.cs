namespace AuthService.Application.Abstractions.Common
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }
}