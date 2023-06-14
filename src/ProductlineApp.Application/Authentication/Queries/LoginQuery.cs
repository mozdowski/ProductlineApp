using FluentValidation;
using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.User.Repository;
using System.Security.Authentication;

namespace ProductlineApp.Application.Authentication.Queries;

public class LoginQuery
{
    public record Query(
        string Email,
        string Password) : IQuery<AuthenticationResult>;

    public class Validation : AbstractValidator<Query>
    {
        public Validation()
        {
            this.RuleFor(m => m.Email).NotEmpty().EmailAddress();
            this.RuleFor(x => x.Password).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, AuthenticationResult>
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

        public async Task<AuthenticationResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var (user, salt) = await this._userRepository.GetByEmailWithSaltAsync(request.Email);

            if (user is null)
            {
                throw new InvalidCredentialException("Invalid email or password");
            }

            if (salt is not null && !this._passwordHasher.VerifyPassword(request.Password, user.Password, salt))
            {
                throw new InvalidCredentialException($"Invalid email or password for userId: {user.Id}");
            }

            var token = this._tokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user.Id.Value,
                user.Username,
                user.Email,
                token);
        }
    }
}
