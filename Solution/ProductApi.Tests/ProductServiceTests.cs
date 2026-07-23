using FluentAssertions;
using Moq;
using ProductApi.BLL.DTOs;
using ProductApi.BLL.Interfaces;
using ProductApi.BLL.Services;
using ProductApi.Entities;
using Xunit;

namespace ProductApi.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IDiscountService> _discountServiceMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _discountServiceMock = new Mock<IDiscountService>();

        _productService = new ProductService(
            _productRepositoryMock.Object,
            _discountServiceMock.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_Return_ProductId_When_Product_Is_Created()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Laptop Lenovo",
            Status = 1,
            Stock = 10,
            Description = "Laptop Core i7",
            Price = 3500
        };

        _productRepositoryMock
            .Setup(x => x.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync(1);

        // Act
        var result = await _productService.CreateAsync(request);

        // Assert
        result.Should().Be(1);

        _productRepositoryMock.Verify(
            x => x.CreateAsync(It.IsAny<Product>()),
            Times.Once);
    }
}