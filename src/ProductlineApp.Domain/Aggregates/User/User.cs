using ProductlineApp.Domain.Aggregates.Marketplace.ValueObjects;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Aggregates.User;

public class User : Person<UserId>
{
    private readonly List<MarketplaceId> _registeredMarketplaceIds = new();
    private readonly List<ProductId> _productIds = new();

    public User(
        UserId userId,
        string firstName,
        string lastName,
        string nickname,
        string email,
        DateTime dateOfBirth)
    : base(userId, firstName, lastName, email, dateOfBirth)
    {
        this.Nickname = nickname;
        this.Status = SellerStatus.UNVERIFIED;
    }

    public string Nickname { get; private set; }

    public IReadOnlyList<ProductId> ProductIds => this._productIds.AsReadOnly();

    public IReadOnlyList<MarketplaceId> RegisteredMarketplaceIds => this._registeredMarketplaceIds.AsReadOnly();

    public SellerStatus Status { get; private set; }

    public void VerifySeller()
    {
        this.Status = SellerStatus.VERIFIED;
    }

    public void RegisterSellerOnMarketplace(MarketplaceId marketplaceId)
    {
        if (this.Status == SellerStatus.UNVERIFIED)
        {
            throw new InvalidOperationException("Unable to register marketplace. Seller is not verified.");
        }

        //// market registration here

        this.Status = SellerStatus.ON_MARKETPLACE;
    }
}
