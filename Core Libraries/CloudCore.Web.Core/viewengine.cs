using System.Web.Mvc;

namespace CloudCore.Web.Core
{
    public class ViewEngine : RazorViewEngine
    {
        public ViewEngine()
        {
            VirtualPathProvider = WebApplication.VirtualPathProvider;
            SetViewLocationSearchPaths();
        }

        private void SetViewLocationSearchPaths()
        {
            AreaViewLocationFormats = new[]
            {
                "~/Core/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/{1}/{0}.cshtml",                
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            AreaMasterLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };

            AreaPartialViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.cshtml"                
            };

            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.aspx",
                "~/Views/Shared/{0}.aspx"
            };

            MasterLocationFormats = new[]
            {
                "~/Areas/CUI/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml"                             
            };

            PartialViewLocationFormats = new[]
            {
                "~/Areas/CUI/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml"                                
            };
        }
    }
}
