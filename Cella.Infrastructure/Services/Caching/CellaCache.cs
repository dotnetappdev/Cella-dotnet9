using Cella.Infrastructure.Framework.Caching;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Services.Caching
{
    public class CellaCache
    {
        private IMemoryCache _cache;
        public CellaCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void CacheGetOrCreate(IMemoryCache memoryCache)
        {

            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>

            {
 
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return DateTime.Now;
            });

            _cache.Set(CacheKeys.Entry, cacheEntry, TimeSpan.FromDays(1));


        }
    }
}
