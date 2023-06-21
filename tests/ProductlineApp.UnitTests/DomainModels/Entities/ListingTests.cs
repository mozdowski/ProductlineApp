// using System;
// using NUnit.Framework;
// using ProductlineApp.Domain.Aggregates.Listing;
// using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
// using ProductlineApp.Domain.Aggregates.Products;
// using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
// using ProductlineApp.Domain.Aggregates.User.ValueObjects;
//
// namespace ProductlineApp.UnitTests.DomainModels.Entities;
//
// [TestFixture]
// public class ListingTests
// {
//     private Listing _listing;
//
//     [SetUp]
//     public void SetUp()
//     {
//         var title = "Test Listing";
//         var description = "This is a test listing.";
//         var productId = ProductId.CreateUnique();
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var price = 10.0m;
//         var quantity = 1;
//         var ownerId = UserId.CreateUnique();
//         this._listing = Listing.Create(title, description, productId, price, quantity, ownerId, platformConnectionId);
//     }
//
//     [Test]
//     public void Create_WithValidArguments_CreatesListing()
//     {
//         // Arrange
//         var title = "Test Listing";
//         var description = "This is a test listing.";
//         var productId = ProductId.CreateUnique();
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var price = 10.0m;
//         var quantity = 1;
//         var ownerId = UserId.CreateUnique();
//
//         // Act
//         var listing = Listing.Create(title, description, productId, price, quantity, ownerId, platformConnectionId);
//
//         // Assert
//         Assert.That(listing, Is.Not.Null);
//         Assert.That(listing.Title, Is.EqualTo(title));
//         Assert.That(listing.Description, Is.EqualTo(description));
//         Assert.That(listing.ProductId, Is.EqualTo(productId));
//         Assert.That(listing.Price, Is.EqualTo(price));
//         Assert.That(listing.Quantity, Is.EqualTo(quantity));
//         Assert.That(listing.Owner, Is.EqualTo(ownerId));
//         Assert.That(listing.Status, Is.EqualTo(ListingStatus.ACTIVE));
//     }
//
//     [Test]
//     public void Create_WithInvalidArguments_ThrowsArgumentException()
//     {
//         // Arrange
//         var title = "";
//         var description = "This is a test listing.";
//         var productId = ProductId.CreateUnique();
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var price = -10.0m;
//         var quantity = 0;
//         var ownerId = UserId.CreateUnique();
//
//         // Act + Assert
//         Assert.Throws<ArgumentException>(() => Listing.Create(title, description, productId, price, quantity, ownerId, platformConnectionId));
//     }
//
//     // [Test]
//     // public void CreateFromProduct_WithValidArguments_CreatesListing()
//     // {
//     //     // Arrange
//     //     var ownerId = UserId.CreateUnique();
//     //     var product = Product.Create(
//     //         "Test Product",
//     //         "Something",
//     //         10.0m,
//     //         1,
//     //         "https://example.com/image.jpg",
//     //         "Some brand",
//     //         "This is a test product.",
//     //         ownerId);
//     //
//     //     // Act
//     //     var listing = Listing.CreateFromProduct(product, ownerId);
//     //
//     //     // Assert
//     //     Assert.That(listing, Is.Not.Null);
//     //     Assert.That(listing.Title, Is.EqualTo(product.Name));
//     //     Assert.That(listing.Description, Is.EqualTo(product.Description));
//     //     Assert.That(listing.ProductId, Is.EqualTo(product.Id));
//     //     Assert.That(listing.Price, Is.EqualTo(product.Price));
//     //     Assert.That(listing.Quantity, Is.EqualTo(product.Quantity));
//     //     Assert.That(listing.Owner, Is.EqualTo(ownerId));
//     //     Assert.That(listing.Status, Is.EqualTo(ListingStatus.ACTIVE));
//     // }
//
//     [Test]
//     public void CreateFromProduct_WithInvalidArguments_ThrowsArgumentNullException()
//     {
//         // Arrange
//         Product product = null;
//         var ownerId = UserId.CreateUnique();
//
//         // Act + Assert
//         Assert.Throws<ArgumentNullException>(() => Listing.CreateFromProduct(product, ownerId));
//     }
//
//     // [Test]
//     // public void CreateFromProduct_WithMismatchedOwners_ThrowsInvalidCredentialException()
//     // {
//     //     // Arrange
//     //     var product = Product.Create(
//     //         "Test Product",
//     //         "Something",
//     //         10.0m,
//     //         1,
//     //         "https://example.com/image.jpg",
//     //         "Some brand",
//     //         "This is a test product.",
//     //         UserId.CreateUnique());
//     //
//     //     var ownerId = UserId.CreateUnique();
//     //
//     //     // Act + Assert
//     //     Assert.Throws<InvalidCredentialException>(() => Listing.CreateFromProduct(product, ownerId));
//     // }
//
//     [Test]
//     public void Deactivate_DeactivatesListing_Success()
//     {
//         // Act
//         this._listing.MarkAsInactive();
//
//         // Assert
//         Assert.That(this._listing.Status, Is.EqualTo(ListingStatus.INACTIVE));
//     }
//
//     [Test]
//     public void Deactivate_WithInvalidOwner_ThrowsInvalidCredentialException()
//     {
//         // Arrange
//         this._listing.MarkAsSold();
//
//         // Act + Assert
//         Assert.Throws<InvalidOperationException>(() => this._listing.MarkAsInactive());
//     }
//
//     [Test]
//     public void MarkAsSold_WithValidOwner_MarksListingAsSold()
//     {
//         // Arrange
//         // Act
//         this._listing.MarkAsSold();
//
//         // Assert
//         Assert.That(this._listing.Status, Is.EqualTo(ListingStatus.SOLD));
//     }
//
//     [Test]
//     public void AddInstance_NullInstance_ThrowsArgumentNullException()
//     {
//         // Arrange
//         var listing = this.CreateDefaultListing();
//
//         // Act & Assert
//         Assert.Throws<ArgumentNullException>(() => listing.AddInstance(null));
//     }
//
//     [Test]
//     public void RemoveInstance_NullInstance_ThrowsArgumentNullException()
//     {
//         // Arrange
//         var listing = this.CreateDefaultListing();
//
//         // Act & Assert
//         Assert.Throws<ArgumentNullException>(() => listing.RemoveInstance(null));
//     }
//
//     private Listing CreateDefaultListing()
//     {
//         return Listing.Create(
//             title: "Test Listing",
//             description: "This is a test listing.",
//             product: ProductId.CreateUnique(),
//             price: 10.99m,
//             quantity: 5,
//             ownerId: UserId.CreateUnique(),
//             platformConnection: PlatformConnectionId.CreateUnique());
//     }
// }
