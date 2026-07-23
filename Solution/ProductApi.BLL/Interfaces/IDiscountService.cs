using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.Interfaces
{
    public interface IDiscountService
    {
        Task<decimal> GetDiscountAsync(int productId);
    }
}
