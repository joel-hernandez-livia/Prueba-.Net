using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ProductApi.BLL.DTOs.External;
using ProductApi.BLL.Interfaces;

namespace ProductApi.BLL.Services;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetDiscountAsync(int productId)
    {
        var response = await _httpClient.GetAsync($"discounts");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var discounts = JsonSerializer.Deserialize<List<DiscountResponse>>
        (
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        var discount = discounts?
            .FirstOrDefault(x => x.ProductId == productId);

        return discount?.Discount ?? 0;
    }
}