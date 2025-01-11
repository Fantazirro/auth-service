using MediatR;

namespace AuthService.Application.Abstractions.Messaging
{
    public interface IQuery : IRequest;
    public interface IQuery<out TResponse> : IRequest<TResponse>;
}