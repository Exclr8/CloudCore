using System.Collections.Generic;
using CloudCore.Admin;
using CloudCore.Core.Modules;
using CloudCore.Web;
using CloudCore.Web.Core;

namespace CloudCore.Site
{
    public class BasicWebApplication : WebApplication
    {
        protected override IEnumerable<CloudCoreModule> RegisterWebModules()
        {
            return new List<CloudCoreModule>
            {
                new CoreCuiModule(),
                new CoreAdminModule()
            };

        }
    }
}
