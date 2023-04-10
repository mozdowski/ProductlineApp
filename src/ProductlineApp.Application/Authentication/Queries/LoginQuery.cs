using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using System.Security.Authentication;
using ProductlineApp.Application.Authentication.DTO;

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

        public Handler(
            IUserRepository userRepository,
            IJwtTokenGenerator tokenGenerator)
        {
            this._userRepository = userRepository;
            this._tokenGenerator = tokenGenerator;
        }

        public async Task<AuthenticationResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByEmailAsync(request.Email);

            if (user is null)
            {
                throw new InvalidCredentialException("Invalid email or password");
            }

            if (user.Password != request.Password)
            {
                throw new InvalidCredentialException("Invalid email or password");
            }

            var token = this._tokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
