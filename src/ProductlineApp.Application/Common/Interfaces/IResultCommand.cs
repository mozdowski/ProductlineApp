using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface IResultCommand<out TResponse> : IRequest<TResponse>
{
}
