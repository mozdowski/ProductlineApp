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
        this._platform = Platform.Create("Test Platform");
    }

    [Test]
    public void Create_ValidParameters_ReturnsPlatformWithExpectedProperties()
    {
        // Assert
        Assert.IsNotNull(this._platform.Id);
        Assert.AreEqual("Test Platform", this._platform.Name);
    }

    [Test]
    public void Create_NullName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform(null));
    }

    [Test]
    public void Create_EmptyName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform(""));
    }

    [Test]
    public void Create_WhiteSpaceName_ThrowsArgumentException()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => this.CreatePlatform("  "));
    }

    private Platform CreatePlatform(string name)
    {
        return Platform.Create(name);
    }
}
