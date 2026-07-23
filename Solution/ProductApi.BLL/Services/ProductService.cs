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

    public ProductService(
        IProductRepository productRepository,
        IDiscountService discountService)
    {
        _productRepository = productRepository;
        _discountService = discountService;
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

    public Task<bool> UpdateAsync(int productId, UpdateProductRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse?> GetByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}