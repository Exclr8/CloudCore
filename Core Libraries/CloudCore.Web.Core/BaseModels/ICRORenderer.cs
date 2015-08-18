using System.Collections.Generic;
using System.Web.Mvc;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

namespace CloudCore.Web.Core.BaseModels
{
    public interface ICRORenderer
    {
        void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper);
        long Key { set;}
        List<CROContent> GetCROContent(UrlHelper url);
        bool CanDisplay();
    }
}
