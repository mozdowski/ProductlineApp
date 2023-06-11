using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
where TCommand : ICommand
{
}
