using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Application.Authentication.Queries;

public class GetUserPlatformTokensQuery
{
    public record Query(Guid UserId) : IQuery<UserTokensResult>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class Handler : IQueryHandler<Query, UserTokensResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(
            IUserRepository userRepository,
            IPlatformRepository platformRepository,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserTokensResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var platformConnections = await this._userRepository.GetUserPlatformConnectionsAsync(UserId.Create(request.UserId));
            return this._mapper.Map<UserTokensResult>(platformConnections);
        }
    }
}
