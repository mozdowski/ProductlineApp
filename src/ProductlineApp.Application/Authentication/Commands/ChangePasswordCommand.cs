using FluentValidation;
using MediatR;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using System.Security.Authentication;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Authentication.Commands;

public class ChangePasswordCommand
{
    public record Command(
        Guid UserId,
        string OldPassword,
        string NewPassword) : ICommand;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
            this.RuleFor(x => x.NewPassword).NotEmpty();
            this.RuleFor(x => x.OldPassword).NotEmpty().NotEqual(x => x.NewPassword);
        }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public Handler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            this._userRepository = userRepository;
            this._passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(request.UserId);
            var (user, oldSalt) = await this._userRepository.GetByIdWithSaltAsync(userId);

            if (user is null)
            {
                throw new InvalidCredentialException("Invalid user");
            }

            if (!this._passwordHasher.VerifyPassword(request.OldPassword, user.Password, oldSalt))
            {
                throw new InvalidCredentialException("Incorrect password");
            }

            var (hashedNewPassword, newSalt) = this._passwordHasher.HashPassword(request.NewPassword);

            user.ChangePassword(
                hashedNewPassword,
                newSalt);

            await this._userRepository.UpdateUserAsync(user);

            return Unit.Value;
        }
    }
}
