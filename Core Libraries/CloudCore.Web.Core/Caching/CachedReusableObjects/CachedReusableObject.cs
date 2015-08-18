using CloudCore.Core;

using System;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{


    [Serializable()]
    public abstract class CachedReusableObject
    {
        private long croKey  = -999999;

        public long Key { get { return croKey; } set { UpdateKey(value); } }


        public virtual void AddContent(CROContent content, UrlHelper urlHelper) { }

        public abstract string GetTitle();

        protected abstract void GetPropertyValues();

        public abstract void UpdateCache();


        public virtual void ForceRefresh()
        {
            GetPropertyValues();
            UpdateCache();
        }

        internal void UpdateKey(long key)
        {
            if (croKey != key)
            {
                croKey = key;
                ForceRefresh();
            }
        }
    }
}
