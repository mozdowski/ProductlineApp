// using System;
// using NUnit.Framework;
// using ProductlineApp.Domain.Aggregates.Listing.Entities;
// using ProductlineApp.Domain.Aggregates.User.ValueObjects;
//
// namespace ProductlineApp.UnitTests.DomainModels.Entities;
//
// [TestFixture]
// public class ListingInstanceTests
// {
//     [Test]
//     public void Create_ValidInput_CreatesListingInstance()
//     {
//         // Arrange
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var platformListingId = "12345";
//         var listingUrl = "https://example.com/listing";
//         var withdrawUrl = "https://example.com/withdraw";
//         var publishUrl = "https://example.com/publish";
//
//         // Act
//         var listingInstance = ListingInstance.Create(platformConnectionId, platformListingId, listingUrl, withdrawUrl, publishUrl);
//
//         // Assert
//         Assert.IsNotNull(listingInstance);
//         Assert.IsInstanceOf<ListingInstance>(listingInstance);
//         Assert.IsNotNull(listingInstance.Id);
//         Assert.AreEqual(platformConnectionId, listingInstance.PlatformConnectionId);
//         Assert.AreEqual(platformListingId, listingInstance.PlatformListingId);
//         Assert.AreEqual(new Uri(listingUrl), listingInstance.ListingUrl);
//         Assert.AreEqual(new Uri(withdrawUrl), listingInstance.WithdrawUrl);
//         Assert.AreEqual(new Uri(publishUrl), listingInstance.PublishUrl);
//     }
//
//     [Test]
//     public void Create_NullPlatformConnectionId_ThrowsArgumentNullException()
//     {
//         // Arrange
//         var platformListingId = "12345";
//         var listingUrl = "https://example.com/listing";
//         var withdrawUrl = "https://example.com/withdraw";
//         var publishUrl = "https://example.com/publish";
//
//         // Act & Assert
//         Assert.Throws<ArgumentNullException>(() => ListingInstance.Create(null, platformListingId, listingUrl, withdrawUrl, publishUrl));
//     }
//
//     [Test]
//     public void Create_NullPlatformListingId_ThrowsArgumentException()
//     {
//         // Arrange
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var listingUrl = "https://example.com/listing";
//         var withdrawUrl = "https://example.com/withdraw";
//         var publishUrl = "https://example.com/publish";
//
//         // Act & Assert
//         Assert.Throws<ArgumentException>(() => ListingInstance.Create(platformConnectionId, null, listingUrl, withdrawUrl, publishUrl));
//     }
//
//     [Test]
//     public void Create_NullListingUrl_ThrowsArgumentException()
//     {
//         // Arrange
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var platformListingId = "12345";
//         var withdrawUrl = "https://example.com/withdraw";
//         var publishUrl = "https://example.com/publish";
//
//         // Act & Assert
//         Assert.Throws<ArgumentException>(() => ListingInstance.Create(platformConnectionId, platformListingId, null, withdrawUrl, publishUrl));
//     }
//
//     [Test]
//     public void Create_NullWithdrawUrl_ThrowsArgumentException()
//     {
//         // Arrange
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var platformListingId = "12345";
//         var listingUrl = "https://example.com/listing";
//         var publishUrl = "https://example.com/publish";
//
//         // Act & Assert
//         Assert.Throws<ArgumentException>(() => ListingInstance.Create(platformConnectionId, platformListingId, listingUrl, null, publishUrl));
//     }
//
//     [Test]
//     public void Create_NullPublishUrl_ThrowsArgumentException()
//     {
//         // Arrange
//         var platformConnectionId = PlatformConnectionId.CreateUnique();
//         var platformListingId = "12345";
//         var listingUrl = "https://example.com/listing";
//         var withdrawUrl = "https://example.com/withdraw";
//
//         // Act & Assert
//         Assert.Throws<ArgumentException>(() => ListingInstance.Create(platformConnectionId, platformListingId, listingUrl, withdrawUrl, null));
//     }
// }
