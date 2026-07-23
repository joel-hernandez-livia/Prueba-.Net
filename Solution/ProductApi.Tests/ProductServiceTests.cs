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
    private readonly Mock<IStatusCacheService> _statusCacheService;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _discountServiceMock = new Mock<IDiscountService>();
        _statusCacheService = new Mock<IStatusCacheService>();
        _productService = new ProductService(
            _productRepositoryMock.Object,
            _discountServiceMock.Object,
            _statusCacheService.Object);
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

    [Fact]
    public async Task UpdateAsync_Should_Return_True_When_Product_Is_Updated()
    {
        // Arrange
        int productId = 1;

        var request = new UpdateProductRequest
        {
            Name = "Laptop Lenovo Actualizada",
            Status = 1,
            Stock = 20,
            Description = "Laptop Core i7 16GB RAM",
            Price = 4200
        };

        _productRepositoryMock
            .Setup(x => x.UpdateAsync(It.IsAny<Product>()))
            .ReturnsAsync(true);

        // Act
        var result = await _productService.UpdateAsync(productId, request);

        // Assert
        result.Should().BeTrue();

        _productRepositoryMock.Verify(
            x => x.UpdateAsync(It.IsAny<Product>()),
            Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Product_When_Product_Exists()
    {
        // Arrange
        int productId = 1;

        var product = new Product
        {
            ProductId = productId,
            Name = "Laptop Lenovo",
            Status = 1,
            Stock = 10,
            Description = "Laptop Core i7",
            Price = 3500
        };

        _productRepositoryMock
            .Setup(x => x.GetByIdAsync(productId))
            .ReturnsAsync(product);

        _discountServiceMock
            .Setup(x => x.GetDiscountAsync(productId))
            .ReturnsAsync(10);

        // Act
        var result = await _productService.GetByIdAsync(productId);

        // Assert
        result.Should().NotBeNull();
        result!.ProductId.Should().Be(productId);
        result.Name.Should().Be(product.Name);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Calculate_FinalPrice_Correctly()
    {
        // Arrange
        int productId = 1;

        var product = new Product
        {
            ProductId = productId,
            Name = "Laptop Lenovo",
            Status = 1,
            Stock = 10,
            Description = "Laptop Core i7",
            Price = 3500m
        };

        _productRepositoryMock
            .Setup(x => x.GetByIdAsync(productId))
            .ReturnsAsync(product);

        _discountServiceMock
            .Setup(x => x.GetDiscountAsync(productId))
            .ReturnsAsync(10m);

        // Act
        var result = await _productService.GetByIdAsync(productId);

        // Assert
        result.Should().NotBeNull();
        result!.Price.Should().Be(3500m);
        result.Discount.Should().Be(10m);
        result.FinalPrice.Should().Be(3150m);
    }
}