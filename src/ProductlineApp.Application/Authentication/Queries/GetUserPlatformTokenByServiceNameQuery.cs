using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Authentication.Queries;

public class GetUserPlatformTokenByServiceNameQuery
{
    public record Query(
        Guid UserId,
        PlatformNames PlatformName) : IQuery<string>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
            this.RuleFor(x => x.PlatformName).IsInEnum();
        }
    }

    public class Handler : IQueryHandler<Query, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public Handler(
            IUserRepository userRepository,
            IPlatformRepository platformRepository,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._platformRepository = platformRepository;
            this._mapper = mapper;
        }

        public async Task<string> Handle(Query request, CancellationToken cancellationToken)
        {
            var platform = await this._platformRepository.GetByNameAsync(request.PlatformName.ToString().ToLower());
            var platformAccessToken = await this._userRepository.GetUserPlatformToken(
                UserId.Create(request.UserId),
                platform.Id);

            return platformAccessToken;
        }
    }
}
