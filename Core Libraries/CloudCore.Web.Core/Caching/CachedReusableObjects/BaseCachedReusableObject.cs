using System;
using CloudCore.Core;


namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{
    [Serializable]
    abstract public class BaseCachedReusableObject<T> : CachedReusableObject where T : BaseCachedReusableObject<T>, new()
    {        
        public virtual bool IsVisible() { return true; }


        public override void UpdateCache()
        {
            string keyName = CloudCoreCache.KeyName(CacheType.SessionCache, this.GetType().Name.ToLower());
            CloudCoreCache.Put(keyName, this, TimeSpan.FromMinutes(30));
        }

        protected static T DeserializeFromCache()
        {
            string keyName = CloudCoreCache.KeyName(CacheType.SessionCache, typeof(T).Name.ToLower());

            var cachedClass = CloudCoreCache.Get(keyName) as T ?? new T();

            return cachedClass;
        }

        public static T LoadFromCache()
        {
            return DeserializeFromCache();
        }




    }
}
