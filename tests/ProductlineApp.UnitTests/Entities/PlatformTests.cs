namespace ProductlineApp.UnitTests.Entities;

using System;
using NUnit.Framework;
using ProductlineApp.Domain.Aggregates.User.Entities;

[TestFixture]
public class PlatformTests
{
    private Platform _platform;

    [SetUp]
    public void Setup()
    {
        // Arrange
        this._platform = Platform.Create("Test Platform", "https://example.com");
    }

    [Test]
    public void Create_ValidParameters_ReturnsPlatformWithExpectedProperties()
    {
        // Assert
        Assert.IsNotNull(this._platform.Id);
        Assert.AreEqual("Test Platform", this._platform.Name);
        Assert.AreEqual(new Uri("https://example.com"), this._platform.Url);
    }

    [Test]
    public void Create_NullName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform(null, "https://example.com"));
    }

    [Test]
    public void Create_EmptyName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform("", "https://example.com"));
    }

    [Test]
    public void Create_WhiteSpaceName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform("  ", "https://example.com"));
    }

    [Test]
    public void Create_InvalidUrl_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform("Test Platform", "not-a-valid-url"));
    }

    private Platform CreatePlatform(string name, string url)
    {
        return Platform.Create(name, url);
    }
}