using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ProductApi.BLL.DTOs.External;

public class DiscountResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("discount")]
    public decimal Discount { get; set; }
}
