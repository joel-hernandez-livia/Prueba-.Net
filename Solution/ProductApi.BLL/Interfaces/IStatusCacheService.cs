using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.BLL.Interfaces
{
    public interface IStatusCacheService
    {
        string GetStatusName(int status);
    }
}
