using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.User.Queries;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.User.Commands;

public class LinkPlatformCommand
{
    public record Command(
        Guid UserId,
        Guid PlatformId,
        string AccessToken,
        string RefreshToken,
        int ExpiresIn) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.PlatformId).NotEmpty();
            this.RuleFor(x => x.AccessToken).NotEmpty();
            this.RuleFor(x => x.RefreshToken).NotEmpty().NotEqual(x => x.AccessToken);
            this.RuleFor(x => x.ExpiresIn).GreaterThan(0);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public Handler(
            IUserRepository userRepository,
            IMediator mediator)
        {
            this._userRepository = userRepository;
            this._mediator = mediator;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery.Query(request.UserId);
            var user = await this._mediator.Send(query, cancellationToken);

            user.AddPlatformConnection(
                PlatformId.Create(request.PlatformId),
                request.AccessToken,
                request.RefreshToken,
                request.ExpiresIn);

            // await this._userRepository.UpdateUserAsync(user);
            await this._userRepository.UpdateUserAsync(user);

            return Unit.Value;
        }
    }
}
