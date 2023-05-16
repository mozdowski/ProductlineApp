using AutoMapper;
using MediatR;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Platforms.Ebay.Mappings;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Listing.Commands;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Enums;
using ProductlineApp.Shared.Models.Common;
using ProductlineApp.Shared.Models.Ebay;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Services;

public class EbayService : IEbayService
{
    private readonly IEbayApiClient _ebayApiClient;
    private readonly ICurrentUserContext _currentUser;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly string? _accessToken;
    private readonly IProductRepository _productRepository;
    private readonly IUploadFileService _uploadFileService;
    private readonly IListingRepository _listingRepository;

    public EbayService(
        IEbayApiClient ebayApiClient,
        IMapper mapper,
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformRepository platformRepository,
        IProductRepository productRepository,
        IUploadFileService uploadFileService,
        IListingRepository listingRepository)
    {
        this._ebayApiClient = ebayApiClient;
        this._mapper = mapper;
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._productRepository = productRepository;
        this._uploadFileService = uploadFileService;
        this._listingRepository = listingRepository;

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
            response.ExpiresIn,
            response.RefreshTokenExpiresIn);
        await this._mediator.Send(command);
    }

    public async Task RefreshAccessTokenAsync(UserId userId, string refreshToken)
    {
        var response = await this._ebayApiClient.GetRefreshTokenAsync(refreshToken);

        if (response is null)
            throw new NullReferenceException("Retrieved access token as null");

        if (!this._currentUser.UserId.HasValue || this.PlatformId is null)
            throw new NullReferenceException("User or platform is not defined");

        var command = new RefreshPlatformTokenCommand.Command(
            userId.Value,
            this.PlatformId.Value,
            response.AccessToken,
            null,
            response.ExpiresIn,
            null);
        await this._mediator.Send(command);
    }

    public async Task<IEnumerable<Domain.Aggregates.Order.Order>> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    // pierwsza wersja zaklada pobieranie ofert stworzonych tylko na naszym portalu
    public async Task<IEnumerable<ListingDtoResponse>> GetListingsAsync()
    {
        // nowy wersja pobierania listy ofert:
        // 1. pobieramy z ebay api liste produktow dla danego uzytkownika
        // 2. dla kazdego produktu pobieramy jego oferty z ebay api na podstawie SKU
        // 3. jezeli produkt istnieje w naszej bazie, to zwracamy wartosci z bazy
        // 4. jesli produkt nie istnieje w bazie, to zwracane sa informacje z produktu pobranego z ebay api
        // var userListings = await this._listingRepository.GetAllByUserIdAsync(UserId.Create(this._currentUser.UserId.Value));
        var ebayOfferIds = await this._listingRepository.GetUsersPlatformListingsIds(UserId.Create(this._currentUser.UserId.Value), this.PlatformId);
        // var ebayProducts =
        //     await this._productRepository.GetUserProductsByIds(ebayProductIds, UserId.Create(this._currentUser.UserId.Value));

        if (!ebayOfferIds.Any()) return new List<ListingDtoResponse>();

        var offers = await this._ebayApiClient.GetOffers(this._accessToken, ebayOfferIds);

        if (!offers.Any()) return new List<ListingDtoResponse>();

        var result = new List<ListingDtoResponse>();
        foreach (var offer in offers)
        {
            var mappedOffer = this._mapper.Map<ListingDtoResponse>(offer);
            var product = await this._productRepository.GetProductBySku(offer.Sku);

            if (product is null) continue;

            mappedOffer.ProductId = product.Id.Value;
            mappedOffer.ProductName = product.Name;
            mappedOffer.ProductImage = product.Image;

            result.Add(mappedOffer);
        }

        return result;
    }

    public async Task CreateListingAsync(EbayListingDtoRequest request)
    {
        var listing = await this._listingRepository.GetByIdAsync(ListingId.Create(request.ListingId));
        if (listing is null) throw new Exception($"Listing with ID: {request.ListingId} not found");

        var inventoryItemSku = await this.CreateOrReplaceInventoryItem(listing.ProductId, request.Aspects);

        var requestBody = this._mapper.Map<EbayCreateOfferRequest>(
        new EbayCreateOfferMapperInput()
                {
                    EbayItemSku = inventoryItemSku,
                    OfferDetails = request.OfferDetails,
                });

        var ebayOfferId = await this._ebayApiClient.CreateOffer(this._accessToken, requestBody);
        // await this._ebayApiClient.PublishOffer(this._accessToken, ebayOfferId);

        var command = new AddListingInstance.Command(
            this._currentUser.UserId.Value,
            request.ListingId,
            this.PlatformId.Value,
            ebayOfferId,
            null,
            null);
        await this._mediator.Send(command);
    }

    public async Task<PlatformCategoriesListDto> GetCategoriesByPhrase(string phrase)
    {
        var categories = await this._ebayApiClient.GetCategories(this._accessToken, phrase);
        return this._mapper.Map<PlatformCategoriesListDto>(categories);
    }

    public async Task<PlatformAspectsDtoResponse> GetAspectsForCategory(string categoryId)
    {
        var aspects = await this._ebayApiClient.GetAspectsForCategory(this._accessToken, categoryId);
        return this._mapper.Map<PlatformAspectsDtoResponse>(aspects);
    }

    public async Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds)
    {
        throw new NotImplementedException();
    }

    public async Task WithdrawListingAsync(ListingId listingId, ListingInstanceId listingInstanceId)
    {
        var listing = await this._listingRepository.GetByIdAsync(listingId);
        var listingInstance = listing.GetListingInstance(listingInstanceId);

        await this._ebayApiClient.WithdrawOffer(this._accessToken, listingInstance.PlatformListingId);

        listing.MarkListingInstanceAsInactive(listingInstanceId);

        await this._listingRepository.UpdateAsync(listing);
    }

    public async Task PublishListingAsync(ListingId listingId, ListingInstanceId listingInstanceId)
    {
        var listing = await this._listingRepository.GetByIdAsync(listingId);
        var listingInstance = listing.GetListingInstance(listingInstanceId);

        await this._ebayApiClient.PublishOffer(this._accessToken, listingInstance.PlatformListingId);

        listing.MarkListingInstanceAsActive(listingInstanceId);

        await this._listingRepository.UpdateAsync(listing);
    }

    public async Task<EbayCategoryTreeDto> GetCategories()
    {
        var categoryTree = await this._ebayApiClient.GetCategories(this._accessToken);
        return this._mapper.Map<EbayCategoryTreeDto>(categoryTree);
    }

    private async Task CreateOrReplaceInventoryItem(EbayProductDtoRequest product)
    {
        var image = await this._uploadFileService.UploadFileAsync(product.Image, FileType.IMAGE);

        IEnumerable<Image>? gallery = null;
        if (product.Images.Any())
        {
            var res = await this._uploadFileService.UploadMultiFileAsync(product.Images.Select(x =>
                new FileUploadModel(x, FileType.IMAGE)));
            gallery = res.Select(x => (Image)x);
        }

        if (image is null || (product.Images is null && gallery is null))
        {
            throw new Exception("Failed to upload image(s)");
        }

        var domainProduct = Product.Create(
            product.Sku,
            product.Name,
            product.CategoryName,
            product.Price,
            product.Quantity,
            (Image)image,
            product.BrandName,
            product.Description,
            product.Condition,
            UserId.Create(this._currentUser.UserId.Value),
            gallery);

        var requestBody = this._mapper.Map<EbayCreateOrReplaceInventoryRequest>(domainProduct);

        if (this._accessToken is null) throw new NullReferenceException("No access token provided");

        await this._ebayApiClient.CreateOrReplaceInventoryItem(this._accessToken, domainProduct.Sku, requestBody);

        await this._productRepository.AddAsync(domainProduct);
    }

    private async Task<string> CreateOrReplaceInventoryItem(ProductId productId, IDictionary<string, IEnumerable<string>> aspects)
    {
        var product = await this._productRepository.GetByIdAsync(productId);
        if (product is null) throw new Exception($"Product with ID: {productId} not found");

        var requestBody = this._mapper.Map<EbayCreateOrReplaceInventoryRequest>(product);

        if (aspects.Any())
        {
            requestBody.Product.Aspects = aspects;
        }

        if (this._accessToken is null) throw new NullReferenceException("No access token provided");

        await this._ebayApiClient.CreateOrReplaceInventoryItem(this._accessToken, product.Sku, requestBody);

        return product.Sku;
    }
}
