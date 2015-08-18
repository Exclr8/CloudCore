using System;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Core.Modules;
using CloudCore.Web.Core.Caching.CachedReusableObjects;


namespace CloudCore.Web.Classes.CachedReusableObjects
{
    public class ModuleCachedReusableObject : BaseCachedReusableObject<ModuleCachedReusableObject>
    {
        public CloudCoreModule Module { get; private set; }

        public override string GetTitle()
        {
            return "Module Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Module Name", Module.Assembly.GetName().Name);
            content.AddHtmlContent("Default Namespace", Module.DefaultNamespace);
            content.AddHtmlContent("Module Type", Module.ModuleType.ToString());
        }

        protected override void GetPropertyValues()
        {
            Module = CloudCore.Core.Modules.Environment.LoadedModules[(int)Key];
        }

        public CloudCoreModule GetModule()
        {
            return CloudCore.Core.Modules.Environment.LoadedModules.SingleOrDefault(r => r.ModuleIndex == Key);
        }

        public int ModuleIndex { get { return Convert.ToInt32(Key); } }
        
    }
}