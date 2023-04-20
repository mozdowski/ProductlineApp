using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.User.Queries;

public class GetUserQuery
{
    public record Query(Guid UserId) : IQuery<Domain.Aggregates.User.User>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, Domain.Aggregates.User.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<Domain.Aggregates.User.User> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByIdAsync(UserId.Create(request.UserId));

            if (user is null)
            {
                throw new Exception($"User not found");
            }

            return user;
        }
    }
}
