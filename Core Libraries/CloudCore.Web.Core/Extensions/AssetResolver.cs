using System;
using System.IO;
using System.Linq;
using CloudCore.Core.Hosting;
using CloudCore.Core.Hosting.VirtualFiles;
using System.Diagnostics;

namespace CloudCore.Web.Core.Extensions
{
    public static class AssetResolver
    {
        private static string GetReferenceSubPath(string reference)
        {
            reference = reference.Replace('/', '.').TrimStart('.');
            string extension = Path.GetExtension(reference).Replace("?","");
            switch (extension)
            {
                case ".css":
                    return string.Format(@"css.{0}", reference);
                case ".png":
                case ".gif":
                case ".ico":
                case ".jpg":
                case ".bmp":
                    return string.Format(@"images.{0}", reference);
                case ".js":
                    return string.Format(@"scripts.{0}", reference);
                case ".htm":
                    return string.Format(@"html.{0}", reference);
                case ".pdf":
                    return string.Format(@"documents.{0}", reference);
                case ".rdlc":
                case ".rdl":
                    return string.Format(@"reports.{0}", reference);
                case ".svg":
                case ".eot":
                case ".ttf":
                case ".woff":
                case ".woff2":
                case ".otf":
                    return string.Format(@"fonts.{0}", reference.Replace("?", ""));
                default:
                    return null;
            }
        }

        public static string GetVirtualCode(string reference, string area)
        {
            CloudCoreVirtualFile vFile = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(string.Format(".Areas.{0}.Assets.{1}", area, GetReferenceSubPath(reference)), StringComparison.InvariantCultureIgnoreCase));
            if (vFile != null)
                return vFile.ResourceHash;
            else
              throw new FileNotFoundException(string.Format("Could not find asset/resource: {0} for area: {1}", reference, area));
        }

        public static string GetEmbeddedPath(string reference, string area)
        {
            CloudCoreVirtualFile vFile = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(string.Format(".Areas.{0}.Assets.{1}", area, GetReferenceSubPath(reference)), StringComparison.InvariantCultureIgnoreCase));
            if (vFile != null)
                return vFile.ResourcePath;
            else
                throw new FileNotFoundException(string.Format("Could not find asset/resource: {0} for area: {1}", reference, area));
        }

        public static Stream GetEmbeddedResourceStream(string reference, string area)
        {
            CloudCoreVirtualFile vFile = VirtualFileBaseCollection.Files.FirstOrDefault(r => r.ResourcePath.EndsWith(string.Format(".Areas.{0}.Assets.{1}", area, GetReferenceSubPath(reference)), StringComparison.InvariantCultureIgnoreCase));
            if (vFile != null)
                return vFile.Open();
            else
                throw new FileNotFoundException(string.Format("Could not find asset/resource: {0} for area: {1}", reference, area));
        }

    }
}
