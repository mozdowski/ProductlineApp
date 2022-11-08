using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Domain.Exceptions
{
    public class MarketplaceContainsAuctionException : Exception
    {
        private const string ErrorMessage = " already constains an auction with id ";

        public MarketplaceContainsAuctionException(Marketplace marketplace, Auction auction)
            : base(marketplace.Name + ErrorMessage + auction.Id)
        {
        }
    }
}
