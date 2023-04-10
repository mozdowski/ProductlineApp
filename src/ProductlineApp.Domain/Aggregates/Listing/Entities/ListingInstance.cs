using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Listing.Entities
{
    public class ListingInstance : Entity<ListingInstanceId>
    {
        private ListingInstance(
            ListingInstanceId id,
            PlatformConnectionId platformConnectionId,
            string platformListingId,
            Uri listingUrl,
            Uri withdrawUrl,
            Uri publishUrl)
            : base(id)
        {
            this.PlatformConnectionId = platformConnectionId ?? throw new ArgumentNullException(nameof(platformConnectionId));
            this.PlatformListingId = platformListingId ?? throw new ArgumentNullException(nameof(platformListingId));
            this.ListingUrl = listingUrl ?? throw new ArgumentNullException(nameof(listingUrl));
            this.WithdrawUrl = withdrawUrl ?? throw new ArgumentNullException(nameof(withdrawUrl));
            this.PublishUrl = publishUrl ?? throw new ArgumentNullException(nameof(publishUrl));
        }

        public PlatformConnectionId PlatformConnectionId { get; private set; }

        public string PlatformListingId { get; private set; }

        public Uri ListingUrl { get; private set; }

        public Uri WithdrawUrl { get; private set; }

        public Uri PublishUrl { get; private set; }

        public static ListingInstance Create(
            PlatformConnectionId platformConnectionId,
            string platformListingId,
            string listingUrl,
            string withdrawUrl,
            string publishUrl)
        {
            if (string.IsNullOrWhiteSpace(platformListingId))
                throw new ArgumentException("PlatformListingId cannot be empty.", nameof(platformListingId));

            if (string.IsNullOrWhiteSpace(listingUrl))
                throw new ArgumentException("Url cannot be empty.", nameof(listingUrl));

            if (string.IsNullOrWhiteSpace(withdrawUrl))
                throw new ArgumentException("Url cannot be empty.", nameof(withdrawUrl));

            if (string.IsNullOrWhiteSpace(publishUrl))
                throw new ArgumentException("Url cannot be empty.", nameof(publishUrl));

            return new ListingInstance(
                ListingInstanceId.CreateUnique(),
                platformConnectionId,
                platformListingId,
                new Uri(listingUrl),
                new Uri(withdrawUrl),
                new Uri(publishUrl));
        }
    }
}
