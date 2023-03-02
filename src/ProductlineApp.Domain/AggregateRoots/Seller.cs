using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Entities;

public class Seller : Person
{
    public Seller(
        Guid id,
        string firstName,
        string lastName,
        string nickname,
        string email,
        DateTime dateOfBirth)
    : base(id, firstName, lastName, email, dateOfBirth)
    {
        this.Nickname = nickname;
        this.Products = new List<Product>();
        this.RegisteredMarketplaces = new List<Marketplace>();
        this.Status = SellerStatus.UNVERIFIED;
    }

    public string Nickname { get; private set; }

    public IEnumerable<Product> Products { get; private set; }

    public IEnumerable<Marketplace> RegisteredMarketplaces { get; private set; }

    public SellerStatus Status { get; private set; }

    public void VerifySeller()
    {
        this.Status = SellerStatus.VERIFIED;
    }

    public void RegisterSellerOnMarketplace(Marketplace marketplace)
    {
        if (this.Status == SellerStatus.UNVERIFIED)
        {
            throw new InvalidOperationException("Unable to register marketplace. Seller is not verified.");
        }

        //// market registration here

        this.Status = SellerStatus.ON_MARKETPLACE;
    }
}
