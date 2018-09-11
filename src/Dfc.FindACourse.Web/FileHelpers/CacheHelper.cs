using Microsoft.Extensions.Caching.Memory;
using System;

namespace Dfc.FindACourse.Web
{
    public static class CacheHelper
    {
        public static void CacheFile<TItem>(IMemoryCache cache, TItem file, string fileKey)
        {
            TItem data = cache.GetOrCreate(fileKey, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(23);
                return file;
            });
        }
        private static TItem GetOrCreate<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, TItem> factory)
        {
            object obj;
            if (!cache.TryGetValue(key, out obj))
            {
                ICacheEntry entry = cache.CreateEntry(key);
                obj = (object)factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
            }
            return (TItem)obj;
        }
    }

}
