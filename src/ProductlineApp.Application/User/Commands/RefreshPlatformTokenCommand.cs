using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.User.Queries;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.User.Commands;

public class RefreshPlatformTokenCommand
{
    public record Command(
        Guid UserId,
        Guid PlatformId,
        string AccessToken,
        string? RefreshToken,
        int ExpiresIn,
        int? RefreshTokenExpiresIn) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.PlatformId).NotEmpty();
            this.RuleFor(x => x.AccessToken).NotEmpty();
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

            var platformId = PlatformId.Create(request.PlatformId);

            user.RefreshAccessTokenForPlatform(platformId, request.AccessToken, request.ExpiresIn);

            await this._userRepository.UpdateUserAsync(user);

            return Unit.Value;
        }
    }
}
