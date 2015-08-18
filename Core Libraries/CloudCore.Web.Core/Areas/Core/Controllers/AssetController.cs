using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;
using CloudCore.Core.Dashboard;
using CloudCore.Core.Hosting;
using CloudCore.Core.Hosting.VirtualFiles;
using CloudCore.Web.Core.Caching;
using CloudCore.Web.Core.Extensions;
using CloudCore.Web.Core.Razor.Extensions;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Core;

namespace CloudCore.Web.Core.Areas.Core.Controllers
{
    public class AssetController : Controller
    {



        public ActionResult Index(string resourceName)
        {
            var contentType = GetContentType(resourceName);
            // TODO: Consider changing to select correct assembly in app domains...
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return File(resourceStream, contentType);
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult MenuData(string cacheguid)
        {
            var profile = new MenuData();
            var resourceStream = new MemoryStream(profile.JsonData());
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult SessionProtectionScript(string loginguid)
        {
            var antiForgeryToken = new SessionProtectionScript().GetScript();
            var resourceStream = new MemoryStream(Encoding.ASCII.GetBytes(antiForgeryToken));
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult LoginReference(string sessionId, int uid)
        {
            var resourceStream = new MemoryStream(Encoding.ASCII.GetBytes("var loginReference = " + CloudCoreIdentity.UserId));
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult UserProfile(string profileguid)
        {
            var profile = new UserProfile();
            var resourceStream = new MemoryStream(profile.JsonData());
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult UserState(string profileguid)
        {
            var profile = new UserState();
            var resourceStream = new MemoryStream(profile.JsonData());
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [HttpGet, PermanentCache]
        public FileResult Theme(string profileguid)
        {

            Stream fstream = null;

            CloudCoreVirtualFile customTheme = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(".Areas.CUI.Assets.css.theme.css", StringComparison.InvariantCultureIgnoreCase));
            CloudCoreVirtualFile coreTheme = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(".Areas.CUI.Assets.css.coretheme.css", StringComparison.InvariantCultureIgnoreCase));
            if (customTheme != null)
            {
                fstream = VirtualPathProvider.OpenFile(customTheme.VirtualPath);
            }
            else
            {
                if (coreTheme != null)
                {
                    fstream = VirtualPathProvider.OpenFile(coreTheme.VirtualPath);
                }
            }

            if (fstream != null)
            {
                fstream.Seek(0, SeekOrigin.Begin);
            }
            else
                throw new FileNotFoundException("Could not load theme from the VirtualPathProvider.");

            return new FileStreamResult(fstream, "text/css");
        }

        [HttpGet, PermanentCache]
        public FileResult Logo(string profileguid)
        {

            Stream fstream = null;
            CloudCoreVirtualFile customLogo = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(".Areas.CUI.Assets.images.logo_dv.png", StringComparison.InvariantCultureIgnoreCase));
            CloudCoreVirtualFile coreLogo = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(".Areas.CUI.Assets.images.corelogo.png", StringComparison.InvariantCultureIgnoreCase));
            if (customLogo != null)
            {
                fstream = VirtualPathProvider.OpenFile(customLogo.VirtualPath);
            }
            else
            {
                if (coreLogo != null)
                {
                    fstream = VirtualPathProvider.OpenFile(coreLogo.VirtualPath);
                }
            }

            if (fstream != null)
            {
                fstream.Seek(0, SeekOrigin.Begin);
            }
            else fstream = new MemoryStream();

            return new FileStreamResult(fstream, "image/png");
        }

        [Authorize]
        [HttpGet, PermanentCache]
        public FileResult ApplicationProfile(string profileguid)
        {
            var profile = new ApplicationProfile();
            var resourceStream = new MemoryStream(profile.JsonData());
            return new FileStreamResult(resourceStream, "text/javascript");
        }

        [HttpGet, PermanentCache]
        public FileResult ByHash(string id)
        {
            Stream fstream = null;
            string contentType = "text/html";

            CloudCoreVirtualFile vfile = VirtualFileBaseCollection.Files.SingleOrDefault(fr => fr.ResourceHash == id);

            if (vfile != null)
            {
                contentType = GetContentType(vfile.VirtualPath);
                fstream = VirtualPathProvider.OpenFile(vfile.VirtualPath);
            }

            if (fstream != null)
            {
                fstream.Seek(0, SeekOrigin.Begin);
            }
            else fstream = new MemoryStream();
            return new FileStreamResult(fstream, contentType);
        }

        [HttpGet]
        public FileResult Get(string file, string resourceArea = "CUI")
        {
            string id = AssetResolver.GetVirtualCode(file, resourceArea);
            if (string.IsNullOrWhiteSpace(id))
            {
                Response.StatusCode = 404;
                Response.StatusDescription = string.Format("Could not find asset/resource: {0} for area: {1}", file, resourceArea);
            }
            return ByHash(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public void UpdateUserDashboard(string dashboardGuid)
        {
            KpiDashboardNotification.UpdateDashboard(dashboardGuid );
        }

        private static string GetContentType(string resourceName)
        {
            var extention = resourceName.Substring(resourceName.LastIndexOf('.')).ToLower();
            switch (extention)
            {
                case ".ico":
                    return "image/x-icon";
                case ".gif":
                    return "image/gif";
                case ".png":
                    return "image/png";
                case ".jpg":
                    return "image/jpg";
                case ".js":
                    return "text/javascript";
                case ".css":
                    return "text/css";
                case ".pdf":
                    return "application/pdf";
                default:
                    return "text/html";
            }
        }
    }
}

