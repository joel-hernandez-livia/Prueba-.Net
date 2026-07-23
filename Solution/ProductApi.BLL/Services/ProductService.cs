using ProductApi.BLL.DTOs;
using ProductApi.BLL.Interfaces;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IDiscountService _discountService;
    private readonly IStatusCacheService _statusCacheService;

    public ProductService(
        IProductRepository productRepository,
        IDiscountService discountService,
        IStatusCacheService statusCacheService)
    {
        _productRepository = productRepository;
        _discountService = discountService;
        _statusCacheService = statusCacheService;
    }

    public async Task<int> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Status = request.Status,
            Stock = request.Stock,
            Description = request.Description,
            Price = request.Price
        };

        return await _productRepository.CreateAsync(product);
    }

    public async Task<bool> UpdateAsync(int productId, UpdateProductRequest request)
    {
        var product = new Product
        {
            ProductId = productId,
            Name = request.Name,
            Status = request.Status,
            Stock = request.Stock,
            Description = request.Description,
            Price = request.Price
        };

        return await _productRepository.UpdateAsync(product);
    }
    public async Task<ProductResponse?> GetByIdAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if (product == null)
            return null;

        var discount = await _discountService.GetDiscountAsync(productId);

        return new ProductResponse
        {
            ProductId = product.ProductId,
            Name = product.Name,
            //StatusName = product.Status == 1 ? "Active" : "Inactive",
            StatusName = _statusCacheService.GetStatusName(product.Status),
            Stock = product.Stock,
            Description = product.Description,
            Price = product.Price,
            Discount = discount,
            FinalPrice = product.Price * (100 - discount) / 100
        };
    }
}