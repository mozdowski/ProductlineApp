using AutoMapper;
using MediatR;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Services;

public class EbayService : IEbayService
{
    private readonly IEbayApiClient _ebayApiClient;
    private readonly ICurrentUserContext _currentUser;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly string? _accessToken;
    private readonly IProductRepository _productRepository;

    public EbayService(
        IEbayApiClient ebayApiClient,
        IMapper mapper,
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformRepository platformRepository,
        IProductRepository productRepository)
    {
        this._ebayApiClient = ebayApiClient;
        this._mapper = mapper;
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._productRepository = productRepository;

        var platformId = platformRepository.GetIdByNameAsync(PlatformNames.EBAY.ToString().ToLower()).GetAwaiter().GetResult();
        this.PlatformId = platformId;

        if (platformId is null ||
            currentUser.PlatformTokens is null ||
            !currentUser.PlatformTokens.TryGetValue(platformId, out var userToken)) return;

        this._accessToken = userToken.AccessToken;
    }

    public PlatformId? PlatformId { get; }

    public string GetAuthorizationUrl()
    {
        return this._ebayApiClient.GetAuthorizationUrl();
    }

    public async Task GainAccessTokenAsync(string code)
    {
        var response = await this._ebayApiClient.GetAccessTokenAsync(code);

        if (response is null)
            throw new NullReferenceException("Retrieved accees token as null");

        if (!this._currentUser.UserId.HasValue || this.PlatformId is null)
            throw new NullReferenceException("User or platform is not defined");

        var command = new LinkPlatformCommand.Command(
            this._currentUser.UserId.Value,
            this.PlatformId.Value,
            response.AccessToken,
            response.RefreshToken,
            response.ExpiresIn);
        await this._mediator.Send(command);
    }

    public async Task<IEnumerable<Domain.Aggregates.Order.Order>> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Listing>> GetListingsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateListingAsync(Listing listing)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds)
    {
        throw new NotImplementedException();
    }

    public async Task WithdrawListingAsync(string listingId)
    {
        throw new NotImplementedException();
    }

    public async Task PublishListingAsync(string listingId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateOrReplaceInventoryItem(Product product)
    {
        var requestBody = this._mapper.Map<EbayCreateOrReplaceInventoryRequest>(product);

        if (this._accessToken is null) throw new NullReferenceException("No access token provided");

        await this._ebayApiClient.CreateOrReplaceInventoryItem(this._accessToken, product.Sku, requestBody);

        await this._productRepository.AddAsync(product);
    }
}
