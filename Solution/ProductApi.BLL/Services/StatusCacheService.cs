using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using ProductApi.BLL.Interfaces;

namespace ProductApi.BLL.Services
{
    public class StatusCacheService : IStatusCacheService
    {
        private readonly IMemoryCache _cache;

        private const string CACHE_KEY = "PRODUCT_STATUS";


        public StatusCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }


        public string GetStatusName(int status)
        {
            var statuses = _cache.GetOrCreate(
                CACHE_KEY,
                entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(5);


                    return new Dictionary<int, string>
                    {
                        {1, "Active"},
                        {0, "Inactive"}
                    };
                });


            return statuses!.TryGetValue(status, out var name)
                ? name
                : "Unknown";
        }
    }
}
