using CloudCore.Core.Modules;

namespace CloudCore.Core.Hosting.VirtualFiles
{
    public class EmbeddedResourceVirtualFile : CloudCoreVirtualFile
    {
        public EmbeddedResourceVirtualFile(string virtualPath, CloudCoreModule module, string resourcePath)
            : base(virtualPath, module, resourcePath)
        {
        }

        public override System.IO.Stream Open()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return Module.Assembly.GetManifestResourceStream(ResourcePath);
        }
    }
}
