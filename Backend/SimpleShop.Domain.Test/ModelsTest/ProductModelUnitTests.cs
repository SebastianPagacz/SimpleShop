using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using SimpleShop.Domain.Models;
using Xunit.Abstractions;

namespace SimpleShop.Domain.Test;

public class ProdutcModelUnitTests()
{
    [Fact]
    public void CreateProduct_Returns_CorrectData()
    {
        // Arrange
        string name = "name";
        decimal price = 10.99m;
        int stock = 12;
        // Act
        var newProd = Product.Create(name, price, stock, null);
        // Assert
        Assert.Equal(name, newProd.Value.Name);
    }

    [Theory]
    [InlineData("", 10, 12)]
    [InlineData(" ", 10, 12)]
    public void ChangeNameFail_Returns_CorrectMessage(string name, decimal price, int stock)
    {
        // Arrange
        var prod = Product.Create("test", price, stock, null);
        // Act
        var result = prod.Value.ChangeName(name);
        // Assert
        Assert.Equal("Name can't be null, empty or exceed 255 characters.", result.Message);
    }

    [Theory]
    [InlineData("Long_Test_Name")]
    [InlineData("a")]
    public void ChangeNameSuccess_Returns_CorrectValue(string name)
    {
        // Arrange
        var prod = Product.Create("Test", 10, 10);
        // Act
        prod.Value.ChangeName(name);
        //Assert
        Assert.Equal(name, prod.Value.Name);
    }

    [Fact]
    public void ChangeNameTooLong_Returns_CorrectValue()
    {
        var prod = Product.Create("Test", 10, 10);
        var newName = new string('a', 256);

        var result = prod.Value.ChangeName(newName);

        Assert.False(result.IsSuccessful);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(0)]
    public void ChangePriceSuccess_Returns_CorrectValue(decimal price)
    {
        var prod = Product.Create("test", 19.99m, 10);

        var result = prod.Value.ChangePrice(price);

        Assert.False(result.IsSuccessful);
    }
}