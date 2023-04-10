namespace ProductlineApp.UnitTests.ValueObjects;

using System;
using NUnit.Framework;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.ValueObjects;

[TestFixture]
public class ValueObjectTests
{
    [Test]
    public void Address_CreateAddressWithValidArguments_DoesNotThrowException()
    {
        // Arrange
        string streetName = "1234 Main St";
        string streetNumber = "Apt 567";
        string zip = "12345";
        string city = "Anytown";
        string country = "USA";

        // Act and Assert
        Assert.DoesNotThrow(() => new Address(streetName, streetNumber, zip, city, country));
    }

    [Test]
    public void Address_CreateAddressWithInvalidArguments_ThrowsArgumentException()
    {
        // Arrange
        string streetName = " ";
        string streetNumber = "Apt 567";
        string zip = "12345";
        string city = "Anytown";
        string country = "USA";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Address(streetName, streetNumber, zip, city, country));
    }

    [Test]
    public void Image_CreateImageWithValidUrl_DoesNotThrowException()
    {
        // Arrange
        string url = "https://example.com/image.jpg";

        // Act and Assert
        Assert.DoesNotThrow(() => new Image(url));
    }

    [Test]
    public void Image_CreateImageWithInvalidUrl_ThrowsArgumentException()
    {
        // Arrange
        string url = "invalid_url";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Image(url));
    }

    [Test]
    public void Category_CreateCategoryWithValidName_DoesNotThrowException()
    {
        // Arrange
        string name = "Electronics";

        // Act and Assert
        Assert.DoesNotThrow(() => new Category(name));
    }

    [Test]
    public void Category_CreateCategoryWithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        string name = " ";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Category(name));
    }

    [Test]
    public void Brand_CreateBrandWithValidName_DoesNotThrowException()
    {
        // Arrange
        string name = "Samsung";

        // Act and Assert
        Assert.DoesNotThrow(() => new Brand(name));
    }

    [Test]
    public void Brand_CreateBrandWithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        string name = " ";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Brand(name));
    }
}