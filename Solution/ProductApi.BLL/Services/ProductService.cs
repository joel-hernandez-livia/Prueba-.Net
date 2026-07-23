using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductApi.BLL.DTOs;
using ProductApi.BLL.Interfaces;

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

    public Task<int> CreateAsync(CreateProductRequest request)
    {
        throw new NotImplementedException();
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