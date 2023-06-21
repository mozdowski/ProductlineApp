using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Models.Common;

namespace ProductlineApp.Application.Common.Services.Interfaces;

public interface IPlatformService
{
    PlatformId? PlatformId { get; }

    string GetAuthorizationUrl();

    Task GainAccessTokenAsync(string code);

    Task RefreshAccessTokenAsync(UserId userId, string refreshToken);

    Task<IEnumerable<OrderDtoResponse>> GetOrdersAsync();

    Task<IEnumerable<ListingDtoResponse>> GetListingsAsync();

    // Task<string> CreateListingAsync(ListingDtoRequest listing);

    Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds);

    Task WithdrawListingAsync(ListingId listingId, ListingInstanceId listingInstanceId);

    Task PublishListingAsync(ListingId listingId, ListingInstanceId listingInstanceId);
}
