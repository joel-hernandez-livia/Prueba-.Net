using ProductApi.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.Interfaces
{

    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductRequest request);

        Task<bool> UpdateAsync(int productId, UpdateProductRequest request);

        Task<ProductResponse?> GetByIdAsync(int productId);
    }
}
