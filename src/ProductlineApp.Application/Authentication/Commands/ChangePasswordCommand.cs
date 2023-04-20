using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using System.Security.Authentication;

namespace ProductlineApp.Application.Authentication.Commands;

public class ChangePasswordCommand
{
    public record Command(
        string Email,
        string OldPassword,
        string NewPassword) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
            this.RuleFor(x => x.NewPassword).NotEmpty();
            this.RuleFor(x => x.OldPassword).NotEmpty().NotEqual(x => x.NewPassword);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByEmailAsync(request.Email);

            if (user is null)
            {
                throw new InvalidCredentialException("Invalid email or password");
            }

            user.ChangePassword(
                request.OldPassword,
                request.NewPassword);

            await this._userRepository.UpdateUserAsync(user);

            return Unit.Value;
        }
    }
}
