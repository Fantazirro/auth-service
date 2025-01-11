using MediatR;

namespace AuthService.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest;
    public interface ICommand<out TResponse> : IRequest<TResponse>;
}