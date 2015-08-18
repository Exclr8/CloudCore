using System;
using System.Globalization;
using System.Web.Hosting;
using CloudCore.Core.Modules;
using CloudCore.Core.Security;
using CloudCore.Domain.Security;

namespace CloudCore.Core.Hosting.VirtualFiles
{
    public abstract class CloudCoreVirtualFile : VirtualFile
    {
        public CloudCoreModule Module { get; private set; }

        public string ResourcePath { get; private set; }

        public string ResourceHash { get; private set; }

        protected CloudCoreVirtualFile(string virtualPath, CloudCoreModule module, string resourcePath)
            : base(virtualPath)
        {
            if (module == null)
            {
                throw new ArgumentNullException("module");
            }

            if (string.IsNullOrWhiteSpace(resourcePath))
            {
                throw new ArgumentException("resourcePath");
            }

            Module = module;
            ResourcePath = resourcePath;
            ResourceHash = Hash.Calculate(string.Format("{0}{1}", Encryption.Encrypt(module.LastWriteTime.ToBinary().ToString(CultureInfo.InvariantCulture)), resourcePath));
        }

        public void FlushToDisk(string rootFolderPath)
        {
            throw new NotImplementedException();
        }
    }
}