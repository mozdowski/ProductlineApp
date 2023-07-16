using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.User.Commands;

public class DisconnectPlatformCommand
{
    public record Command(
        Guid PlatformId,
        Guid UserId) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.PlatformId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IUserRepository _userRepository;

        public Handler(
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(request.UserId);
            var platformId = PlatformId.Create(request.PlatformId);

            var user = await this._userRepository.GetUserByIdAsync(userId);

            if (user is null)
            {
                throw new Exception($"User with ID: {userId.Value} not found!");
            }

            user.RemovePlatformConnection(platformId);

            await this._userRepository.UpdateUserAsync(user);

            return Unit.Value;
        }
    }
}
