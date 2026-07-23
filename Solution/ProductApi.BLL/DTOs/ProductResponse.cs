using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.DTOs
{

    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string StatusName { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
