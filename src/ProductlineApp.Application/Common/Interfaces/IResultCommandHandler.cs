using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface IResultCommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : IResultCommand<TResponse>
{
}
