using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CloudCore.Core;
using CloudCore.Web.Core.Caching.CachedReusableObjects;


namespace CloudCore.Web.Core.BaseModels
{
    public abstract class BaseContextModel : BaseModel, ICRORenderer, IDisposable
    {
        private List<CachedReusableObject> croList;

        protected BaseContextModel()
        {
            croList = new List<CachedReusableObject>();
        }

        public void AddKeyed(CachedReusableObject cachedObject, long key)
        {
            cachedObject.UpdateKey(key);
            croList.Insert(0,cachedObject);
        }

        public virtual void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper) { }

        public long Key
        {
            set
            {
                croList.Clear();
                OnKeyChanged(value);
                RefreshContext();
            }
        }

        protected virtual void OnKeyChanged(long key) {}
        public virtual void RefreshContext() { }

        public bool CanDisplay()
        {
            return croList.Count > 0;
        }

        public List<CROContent> GetCROContent(UrlHelper url)
        {
            var croContentList = new List<CROContent>();
            foreach (var cro in croList)
            {
                var croContent = new CROContent { CROTitle = cro.GetTitle() };
                cro.AddContent(croContent, url);
                croContentList.Add(croContent);
            }
            return croContentList;
        }

        public void Dispose()
        {
            croList.Clear();
            croList = null;
        }
    }
}
