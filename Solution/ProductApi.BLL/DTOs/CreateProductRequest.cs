using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.DTOs
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;

        public int Status { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
