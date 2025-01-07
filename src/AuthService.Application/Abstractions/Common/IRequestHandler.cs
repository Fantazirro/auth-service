namespace AuthService.Application.Abstractions.Common
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}