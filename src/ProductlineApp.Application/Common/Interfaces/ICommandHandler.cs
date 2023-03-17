using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}
