using FluentValidation;
using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.User.Repository;

namespace ProductlineApp.Application.Authentication.Commands;

public class RegisterCommand
{
    public record Command(
        string Username,
        string Email,
        string Password) : IResultCommand<AuthenticationResult>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.Username).NotEmpty();
            this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
            this.RuleFor(x => x.Password).NotEmpty();
        }
    }

    public class Handler : IResultCommandHandler<Command, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public Handler(
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator,
            IPasswordHasher passwordHasher)
        {
            this._userRepository = userRepository;
            this._tokenGenerator = tokenGenerator;
            this._passwordHasher = passwordHasher;
        }

        public async Task<AuthenticationResult> Handle(Command request, CancellationToken cancellationToken)
        {
            if (await this._userRepository.IsUserExistingAsync(request.Email))
            {
                throw new Exception($"User {request.Email} already exists");
            }

            var (hashedPassword, salt) = this._passwordHasher.HashPassword(request.Password);

            var user = Domain.Aggregates.User.User.Create(
                request.Username,
                hashedPassword,
                salt,
                request.Email);

            await this._userRepository.AddAsync(user);

            var token = this._tokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
