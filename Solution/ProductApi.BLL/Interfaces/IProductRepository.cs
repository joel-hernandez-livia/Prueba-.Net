using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<Product?> GetByIdAsync(int productId);
    }
}
