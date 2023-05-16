using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Listing.Entities
{
    public class ListingInstance : Entity<ListingInstanceId>
    {
        private ListingInstance(
            ListingInstanceId id,
            ListingId listingId,
            PlatformId platformId,
            string platformListingId,
            Uri? listingUrl,
            ListingStatus status,
            int? expiresIn)
            : base(id)
        {
            this.PlatformId = platformId ?? throw new ArgumentNullException(nameof(platformId));
            this.ListingId = listingId ?? throw new ArgumentNullException(nameof(listingId));

            this.PlatformListingId = platformListingId ?? throw new ArgumentNullException(nameof(platformListingId));
            this.ListingUrl = listingUrl;
            this.Status = status;
            this.ExpiresIn = expiresIn;
        }

        private ListingInstance()
        {
        }

        public ListingId ListingId { get; private set; }

        public PlatformId PlatformId { get; private set; }

        public string PlatformListingId { get; private set; }

        public Uri? ListingUrl { get; private set; }

        public ListingStatus Status { get; private set; }

        public int? ExpiresIn { get; private set; }

        private static ListingInstance Create(
            ListingId listingId,
            PlatformId platformId,
            string platformListingId,
            string? listingUrl,
            ListingStatus status,
            int? expiresIn)
        {
            if (string.IsNullOrWhiteSpace(platformListingId))
                throw new ArgumentException("PlatformListingId cannot be empty.", nameof(platformListingId));

            Uri uri = null;
            if (listingUrl is not null)
            {
                uri = new Uri(listingUrl);
            }

            return new ListingInstance(
                ListingInstanceId.CreateUnique(),
                listingId,
                platformId,
                platformListingId,
                uri,
                status,
                expiresIn);
        }

        public static ListingInstance CreateAndPublish(
            ListingId listingId,
            PlatformId platformId,
            string platformListingId,
            string? listingUrl,
            int? expiresIn)
        {
            return Create(
                listingId,
                platformId,
                platformListingId,
                listingUrl,
                ListingStatus.ACTIVE,
                expiresIn);
        }

        public static ListingInstance CreateNoPublish(
            ListingId listingId,
            PlatformId platformId,
            string platformListingId,
            string? listingUrl)
        {
            return Create(
                listingId,
                platformId,
                platformListingId,
                listingUrl,
                ListingStatus.INACTIVE,
                null);
        }

        public void MarkAsInactive()
        {
            if (this.Status != ListingStatus.ACTIVE)
                throw new InvalidOperationException("Listing is not active.");

            this.Status = ListingStatus.INACTIVE;
        }

        public void MarkAsSold()
        {
            if (this.Status != ListingStatus.ACTIVE)
                throw new InvalidOperationException("Listing is not active.");

            this.Status = ListingStatus.SOLD;
        }

        public void MarkAsActive()
        {
            this.Status = ListingStatus.ACTIVE;
        }
    }
}
