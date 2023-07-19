using AutoMapper;
using MediatR;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms.Allegro.ApiClient;
using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Listing.Commands;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;
using ProductlineApp.Shared.Models.Allegro;

namespace ProductlineApp.Application.Common.Platforms.Allegro.Services;

public class AllegroService : IAllegroService
{
    private readonly IAllegroApiClient _allegroApiClient;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;
    private readonly string? _accessToken;
    private readonly IProductRepository _productRepository;
    private readonly IListingRepository _listingRepository;

    public AllegroService(
        IAllegroApiClient allegroApiClient,
        IMapper mapper,
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformRepository platformRepository,
        IProductRepository productRepository,
        IListingRepository listingRepository)
    {
        this._allegroApiClient = allegroApiClient;
        this._mapper = mapper;
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._productRepository = productRepository;
        this._listingRepository = listingRepository;

        var platformId = platformRepository.GetIdByNameAsync(PlatformNames.ALLEGRO.ToString().ToLower()).GetAwaiter().GetResult();
        this.PlatformId = platformId;

        if (platformId is null ||
            currentUser.PlatformTokens is null ||
            !currentUser.PlatformTokens.TryGetValue(platformId, out var userToken)) return;

        this._accessToken = userToken.AccessToken;
    }

    public PlatformId? PlatformId { get; }

    public string GetAuthorizationUrl()
    {
        return this._allegroApiClient.GetAuthorizationUrl(this.PlatformId.Value.ToString());
    }

    public async Task GainAccessTokenAsync(string code)
    {
        var response = await this._allegroApiClient.GetAccessTokenAsync(code, this.PlatformId.Value.ToString());

        if (response is null)
            throw new NullReferenceException("Retrieved access token as null");

        if (!this._currentUser.UserId.HasValue || this.PlatformId is null)
            throw new NullReferenceException("User or platform is not defined");

        var command = new LinkPlatformCommand.Command(
            this._currentUser.UserId.Value,
            this.PlatformId.Value,
            response.AccessToken,
            response.RefreshToken,
            response.ExpiresIn,
            null);
        await this._mediator.Send(command);
    }

    public async Task RefreshAccessTokenAsync(UserId userId, string refreshToken)
    {
        var response = await this._allegroApiClient.GetRefreshTokenAsync(refreshToken, this.PlatformId.Value.ToString());

        if (response is null)
            throw new NullReferenceException("Retrieved accees token as null");

        if (!this._currentUser.UserId.HasValue || this.PlatformId is null)
            throw new NullReferenceException("User or platform is not defined");

        var command = new RefreshPlatformTokenCommand.Command(
            userId.Value,
            this.PlatformId.Value,
            response.AccessToken,
            response.RefreshToken,
            response.ExpiresIn,
            null);
        await this._mediator.Send(command);
    }

    public async Task<IEnumerable<OrderDtoResponse>> GetOrdersAsync()
    {
        this.CheckIfAuthorized();
        var response = await this._allegroApiClient.GetOrdersAsync(this._accessToken);
        return this._mapper.Map<IEnumerable<OrderDtoResponse>>(response.CheckoutForms);
    }

    public async Task<IEnumerable<ListingDtoResponse>> GetListingsAsync()
    {
        this.CheckIfAuthorized();
        var offers = await this._allegroApiClient.GetOffersAsync(this._accessToken);

        if (!offers.Any()) return new List<ListingDtoResponse>();

        var result = new List<ListingDtoResponse>();
        foreach (var offer in offers)
        {
            var mappedOffer = this._mapper.Map<ListingDtoResponse>(offer);

            if (mappedOffer.ProductId == Guid.Empty)
            {
                result.Add(mappedOffer);
                continue;
            }

            var product = await this._productRepository.GetByIdAsync(ProductId.Create(mappedOffer.ProductId));
            var listing = await this._listingRepository.GetByPlatformListingId(mappedOffer.PlatformListingId);

            if (product is null)
            {
                result.Add(mappedOffer);
                continue;
            }

            // mappedOffer.ProductName = product.Name;
            mappedOffer.ProductImageUrl = product.Image.Url.ToString();
            mappedOffer.Sku = product.Sku;
            mappedOffer.Brand = product.Brand.Name;
            mappedOffer.ListingId = listing.ListingId.Value;
            mappedOffer.ListingInstanceId = listing.Id.Value;

            result.Add(mappedOffer);
        }

        return result;
    }

    public Task<string> CreateListingAsync(Domain.Aggregates.Listing.Listing listing)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds)
    {
        throw new NotImplementedException();
    }

    public async Task WithdrawListingAsync(ListingId listingId, ListingInstanceId listingInstanceId)
    {
        var listing = await this._listingRepository.GetByIdAsync(listingId);
        var listingInstance = listing.GetListingInstance(listingInstanceId);

        var requestBody = new AllegroWithdrawOfferRequest
        {
            OfferCriteria = new List<AllegroWithdrawOfferRequest.WithdrawOfferCriteria>
            {
                new AllegroWithdrawOfferRequest.WithdrawOfferCriteria
                {
                    Offers = new List<AllegroWithdrawOfferRequest.Offer>
                    {
                        new AllegroWithdrawOfferRequest.Offer
                        {
                            Id = listingInstance.PlatformListingId,
                        },
                    },
                },
            },
            Publication = new AllegroWithdrawOfferRequest.WithdrawPublication(),
        };

        var commandId = Guid.NewGuid();
        await this._allegroApiClient.WithdrawOffer(this._accessToken, commandId.ToString(), requestBody);

        listing.MarkListingInstanceAsInactive(listingInstanceId);

        await this._listingRepository.UpdateAsync(listing);
    }

    public async Task PublishListingAsync(ListingId listingId, ListingInstanceId listingInstanceId)
    {
        var listing = await this._listingRepository.GetByIdAsync(listingId);
        var listingInstance = listing.GetListingInstance(listingInstanceId);

        var requestBody = new AllegroOfferRenewalRequest()
        {
            OfferCriteria = new List<AllegroOfferRenewalRequest.RenewalOfferCriteria>
            {
                new AllegroOfferRenewalRequest.RenewalOfferCriteria()
                {
                    Offers = new List<AllegroOfferRenewalRequest.Offer>
                    {
                        new AllegroOfferRenewalRequest.Offer
                        {
                            Id = listingInstance.PlatformListingId,
                        },
                    },
                },
            },
            Publication = new AllegroOfferRenewalRequest.RenewalPublication(),
        };

        var commandId = Guid.NewGuid();

        await this._allegroApiClient.OfferRenewal(this._accessToken, commandId.ToString(), requestBody);

        listing.MarkListingInstanceAsActive(listingInstanceId);

        await this._listingRepository.UpdateAsync(listing);
    }

    public async Task<AllegroProductListDto> GetProductList(string phrase)
    {
        this.CheckIfAuthorized();
        var response = await this._allegroApiClient.GetProductCatalogue(this._accessToken, phrase);
        return this._mapper.Map<AllegroProductListDto>(response);
    }

    public async Task CreateListingBasedOnAllegroProductAsync(AllegroCreateListingDtoRequest request)
    {
        this.CheckIfAuthorized();
        var allegroRequest = this._mapper.Map<AllegroCreateListingRequest>(request);
        var listingId = await this._allegroApiClient.CreateListingAsync(this._accessToken, allegroRequest);

        var command = new AddListingInstance.Command(
            this._currentUser.UserId.Value,
            request.ListingId,
            this.PlatformId.Value,
            listingId,
            null,
            null);
        await this._mediator.Send(command);
    }

    public async Task<string> GetProductParametersForCategory(string categoryId)
    {
        var response = await this._allegroApiClient.GetProductParametersForCategory(this._accessToken, categoryId);
        return response;
        // return this._mapper.Map<AllegroProductParametersDtoResponse>(response);
    }

    public async Task<AllegroCatalogueProductDetailsResponse> GetCatalogueProductDetails(string productId)
    {
        return await this._allegroApiClient.CatalogueProductDetails(this._accessToken, productId);
    }

    public async Task<ShippingRatesResponse> GetShippingRates()
    {
        return await this._allegroApiClient.GetShippingRates(this._accessToken);
    }

    public async Task<ReturnPoliciesResponse> GetReturnPolicies()
    {
        return await this._allegroApiClient.GetReturnPolicies(this._accessToken);
    }

    public async Task<ImpliedWarrantiesResponse> GetImpliedWarranties()
    {
        return await this._allegroApiClient.GetImpliedWarranties(this._accessToken);
    }

    public async Task<AllegroOfferProductDtoResponse> GetOfferProductDetails(string offerId)
    {
        var response = await this._allegroApiClient.GetOfferProductDetails(this._accessToken, offerId);
        return this._mapper.Map<AllegroOfferProductDtoResponse>(response);
    }

    public async Task UpdateListing(string offerId, AllegroUpdateListingDtoRequest request)
    {
        var requestBody = this._mapper.Map<AllegroUpdateOfferRequest>(request);
        await this._allegroApiClient.UpdateOffer(this._accessToken, offerId, requestBody);
    }

    public async Task WithdrawListing(string offerId)
    {
        var requestBody = new AllegroWithdrawOfferRequest
        {
            OfferCriteria = new List<AllegroWithdrawOfferRequest.WithdrawOfferCriteria>
            {
                new AllegroWithdrawOfferRequest.WithdrawOfferCriteria
                {
                    Offers = new List<AllegroWithdrawOfferRequest.Offer>
                    {
                        new AllegroWithdrawOfferRequest.Offer
                        {
                            Id = offerId,
                        },
                    },
                },
            },
            Publication = new AllegroWithdrawOfferRequest.WithdrawPublication(),
        };

        var commandId = Guid.NewGuid();

        await this._allegroApiClient.WithdrawOffer(this._accessToken, commandId.ToString(), requestBody);
    }

    public async Task ListingRenewal(string offerId)
    {
        var requestBody = new AllegroOfferRenewalRequest()
        {
            OfferCriteria = new List<AllegroOfferRenewalRequest.RenewalOfferCriteria>
            {
                new AllegroOfferRenewalRequest.RenewalOfferCriteria()
                {
                    Offers = new List<AllegroOfferRenewalRequest.Offer>
                    {
                        new AllegroOfferRenewalRequest.Offer
                        {
                            Id = offerId,
                        },
                    },
                },
            },
            Publication = new AllegroOfferRenewalRequest.RenewalPublication(),
        };

        var commandId = Guid.NewGuid();

        await this._allegroApiClient.OfferRenewal(this._accessToken, commandId.ToString(), requestBody);
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
