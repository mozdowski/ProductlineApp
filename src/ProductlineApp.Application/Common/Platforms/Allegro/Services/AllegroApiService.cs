using AutoMapper;
using MediatR;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms.Allegro.ApiClient;
using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Common.Platforms.Allegro.Services;

public class AllegroApiService : IAllegroApiService
{
    private readonly IAllegroApiClient _allegroApiClient;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;
    private readonly string? _accessToken;
    private readonly IPlatformRepository _platformRepository;

    public AllegroApiService(
        IAllegroApiClient allegroApiClient,
        IMapper mapper,
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformRepository platformRepository)
    {
        this._allegroApiClient = allegroApiClient;
        this._mapper = mapper;
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._platformRepository = platformRepository;

        if (!currentUser.PlatformTokens.TryGetValue(PlatformNames.ALLEGRO, out var userToken)) return;
        this._accessToken = userToken.AccessToken;
    }

    public string GetAuthorizationUrl(string state)
    {
        return this._allegroApiClient.GetAuthorizationUrl();
    }

    public async Task<string> GetAccessTokenAsync(string code)
    {
        var response = await this._allegroApiClient.GetAccessTokenAsync(code);

        var platformId = await this._platformRepository.GetIdByNameAsync(PlatformNames.ALLEGRO.ToString().ToLower());

        var command = new LinkPlatformCommand.Command(
            this._currentUser.UserId,
            platformId.Value,
            response.AccessToken,
            response.RefreshToken,
            response.ExpiresIn);
        await this._mediator.Publish(command);

        return response.AccessToken;
    }

    public async Task<IEnumerable<Domain.Aggregates.Order.Order>> GetOrdersAsync()
    {
        this.CheckIfAuthorized();
        var response = await this._allegroApiClient.GetOrdersAsync(this._accessToken);
        return this._mapper.Map<IEnumerable<Domain.Aggregates.Order.Order>>(response);
    }

    public async Task<IEnumerable<Listing>> GetListingsAsync()
    {
        this.CheckIfAuthorized();
        var response = await this._allegroApiClient.GetOffersAsync(this._accessToken);
        return this._mapper.Map<IEnumerable<Listing>>(response);
    }

    public Task<string> CreateListingAsync(Listing listing)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds)
    {
        throw new NotImplementedException();
    }

    public Task WithdrawListingAsync(string listingId)
    {
        throw new NotImplementedException();
    }

    public Task PublishListingAsync(string listingId)
    {
        throw new NotImplementedException();
    }

    public async Task<AllegroProductListDto> GetProductList(string phrase)
    {
        this.CheckIfAuthorized();
        var response = await this._allegroApiClient.GetProductCatalogue(this._accessToken, phrase);
        return this._mapper.Map<AllegroProductListDto>(response);
    }

    public async Task<string> CreateListingBasedOnAllegroProductAsync()
    {
        throw new NotImplementedException();
    }

    private void CheckIfAuthorized()
    {
        if (this._accessToken == null)
        {
            throw new UnauthorizedAccessException(
                $"User {this._currentUser.UserId} is unauthorized to use Allegro API");
        }
    }
}
