using System;
using CloudCore.Web.Core.Security.Authentication;
using Microsoft.ApplicationServer.Caching;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace CloudCore.Web.Core.Caching
{
    public enum CacheType
    {
        UserCache = 0,
        SessionCache = 1
    }

    public static class CloudCoreCache
    {
        private static DataCache _cache;

        private static DataCache AzureCache
        {
            get { return _cache ?? (_cache = GetCache()); }
        }

        private static DataCache GetCache()
        {
            var cacheConfig = new DataCacheFactoryConfiguration("default") {MaxConnectionsToServer = 6};

            DataCacheFactoryConfiguration.CreateNamedConfiguration("ConfigWithConnectionPooling", cacheConfig, true);

            var configWithPooling = new DataCacheFactoryConfiguration("ConfigWithConnectionPooling");
            var factory = new DataCacheFactory(configWithPooling);

            return factory.GetDefaultCache();
        }

        public static void Put(String keyName, Object cacheItem)
        {
            Put(keyName, cacheItem, new TimeSpan(1, 0, 0));
        }

        public static void Put(String keyName, Object cacheItem, TimeSpan expiry)
        {
            bool useSession = !RoleEnvironment.IsAvailable;

            if (!useSession)
            {
                try
                {
                    AzureCache.Put(keyName, cacheItem, expiry);
                }
                catch (DataCacheException ex)
                {
                    Logging.Logger.Warn(string.Format("Could not store item '{0}' to Azure Cache: {1}", keyName, ex.Message));
                    useSession = true;
                }
            }
            
            if (useSession)
                SessionInfo.Session[keyName] = cacheItem;
        }

        public static void Put(CacheType typeOfCache, Object cacheItem)
        {
            TimeSpan expiry;
            switch (typeOfCache) // handle the expiry according to the type of cache
            {
                default:
                    expiry = new TimeSpan(12, 0, 0);
                    break;
            }

            Put(KeyName(typeOfCache), cacheItem, expiry);
        }

        public static Object Get(String keyName)
        {
            object returnValue = null;

            bool useSession = !RoleEnvironment.IsAvailable;

            try
            {
                if (!useSession)
                    returnValue = AzureCache.Get(keyName);
            }
            catch (DataCacheException ex)
            {
                useSession = true;
                Logging.Logger.Warn(string.Format("Could not retrieve item '{0}' from Azure Cache: {1}", keyName, ex.Message));
            }

            if (useSession)
                returnValue = SessionInfo.Session[keyName];

            return returnValue;
        }

        public static string KeyName(CacheType ofCacheType)
        {
            switch (ofCacheType)
            {
                case CacheType.UserCache:
                    return string.Format(@"{0}.{1}", CloudCoreIdentity.UserId, Enum.GetName(typeof(CacheType), ofCacheType));
                case CacheType.SessionCache:
                    return string.Format(@"{0}.{1}", CloudCoreIdentity.LoginGuid, Enum.GetName(typeof(CacheType), ofCacheType));
                default:
                    return null;
            }
        }

        public static string KeyName(CacheType ofCacheType, string uniqueValue)
        {
            return string.Format(@"{0}.{1}", uniqueValue, KeyName(ofCacheType));
        }

    }
}

