using System;
using System.Runtime.Caching;

namespace VideoBlock.Utilidades
{
    /// <summary>
    /// Funciones que se utilizan en toda la aplicación
    /// </summary>
    public static class GeneralFunctions
    {
        public static string GetMemoryCache(string key)
        {
            //log.Debug("ralfs_hora GetMemoryCache DateTimeNow: " + DateTime.Now.ToString());

            //If the data exists in cache, pull it from there, otherwise make a call to database to get the data
            ObjectCache cache = MemoryCache.Default;

            return cache.Get(key) as string;
        }

        public static string UpdateMemoryCache(string key, string value, int TimeDuration)
        {
            string r = "ok";

            //If the data exists in cache, pull it from there, otherwise make a call to database to get the data
            ObjectCache cache = MemoryCache.Default;

            string oldValue = GetMemoryCache(key) as string;

            if (!string.IsNullOrEmpty(oldValue))
            {
                //log.Debug("ralfs_hora UpdateMemoryCache DateTimeNow: " + DateTime.Now.ToString());

                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(TimeDuration) };
                cache.Set(key, value, policy);
            }
            else
                r = "bad";

            return r;
        }

    }
}
