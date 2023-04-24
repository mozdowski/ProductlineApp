using NUnit.Framework;

namespace ProductlineApp.UnitTests.DomainModels.Entities;

[TestFixture]
public class PlatformConnectionTests
{
    // private User _testUser;
    // private Platform _testPlatform;
    //
    // [SetUp]
    // public void Setup()
    // {
    //     // Create a test user and platform
    //     this._testUser = User.Create("Test user", "password", "test@email.com");
    //     this._testPlatform = Platform.Create("Test Platform");
    // }

    // [Test]
    // public void Create_ValidParameters_ReturnsNewPlatformConnection()
    // {
    //     // Arrange
    //     string accessToken = "test_access_token";
    //     DateTime expirationDate = DateTime.UtcNow.AddHours(1);
    //
    //     // Act
    //     PlatformConnection connection = PlatformConnection.Create(this._testUser, this._testPlatform.Id, accessToken, expirationDate);
    //
    //     // Assert
    //     Assert.IsNotNull(connection);
    //     Assert.AreEqual(this._testUser.Id, connection.UserId);
    //     Assert.AreEqual(this._testPlatform.Id, connection.PlatformId);
    //     Assert.AreEqual(accessToken, connection.AccessToken);
    //     Assert.AreEqual(expirationDate, connection.ExpirationDate);
    // }
    //
    // [Test]
    // public void Create_NullOrEmptyAccessToken_ThrowsArgumentException()
    // {
    //     // Arrange
    //     string nullAccessToken = null;
    //     string emptyAccessToken = "";
    //
    //     // Act & Assert
    //     Assert.Throws<ArgumentException>(() => PlatformConnection.Create(this._testUser, this._testPlatform.Id, nullAccessToken, DateTime.UtcNow.AddHours(1)));
    //     Assert.Throws<ArgumentException>(() => PlatformConnection.Create(this._testUser, this._testPlatform.Id, emptyAccessToken, DateTime.UtcNow.AddHours(1)));
    // }
    //
    // [Test]
    // public void Create_ExpiredExpirationDate_ThrowsArgumentException()
    // {
    //     // Arrange
    //     DateTime expiredDate = DateTime.UtcNow.AddHours(-1);
    //
    //     // Act & Assert
    //     Assert.Throws<ArgumentException>(() => PlatformConnection.Create(this._testUser, this._testPlatform.Id, "test_access_token", expiredDate));
    // }

    // [Test]
    // public void Create_UserHasConnectionToPlatform_ThrowsInvalidOperationException()
    // {
    //     // Arrange
    //     string accessToken = "test_access_token";
    //     DateTime expirationDate = DateTime.UtcNow.AddHours(1);
    //     PlatformConnection existingConnection = PlatformConnection.Create(this._testUser, this._testPlatform.Id, accessToken, expirationDate);
    //
    //     // Act & Assert
    //     Assert.Throws<InvalidOperationException>(() => PlatformConnection.Create(this._testUser, this._testPlatform.Id, accessToken, expirationDate));
    // }

    // [Test]
    // public void RefreshAccessToken_ValidParameters_UpdatesAccessTokenAndExpirationDate()
    // {
    //     // Arrange
    //     string initialAccessToken = "test_access_token";
    //     DateTime initialExpirationDate = DateTime.UtcNow.AddHours(1);
    //     PlatformConnection connection = PlatformConnection.Create(this._testUser, this._testPlatform.Id, initialAccessToken, initialExpirationDate);
    //
    //     string newAccessToken = "new_access_token";
    //     DateTime newExpirationDate = DateTime.UtcNow.AddHours(2);
    //
    //     // Act
    //     connection.RefreshAccessToken(newAccessToken, newExpirationDate);
    //
    //     // Assert
    //     Assert.AreEqual(newAccessToken, connection.AccessToken);
    //     Assert.AreEqual(newExpirationDate, connection.ExpirationDate);
    // }
    //
    // [Test]
    // public void RefreshAccessToken_ExpiredExpirationDate_ThrowsArgumentException()
    // {
    //     // Arrange
    //     string initialAccessToken = "test_access_token";
    //     DateTime initialExpirationDate = DateTime.UtcNow.AddHours(1);
    //     PlatformConnection connection = PlatformConnection.Create(this._testUser, this._testPlatform.Id, initialAccessToken, initialExpirationDate);
    //
    //     string newAccessToken = "new_access_token";
    //     DateTime expiredDate = DateTime.UtcNow.AddHours(-1);
    //
    //     // Act & Assert
    //     Assert.Throws<ArgumentException>(() => connection.RefreshAccessToken(newAccessToken, expiredDate));
    // }
}
