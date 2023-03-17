using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
