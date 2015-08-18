using System.Collections.Generic;
using CloudCore.Core.Modules;

namespace CloudCore.Web.Models
{
    public class InstalledSystemModulesModel
    {
        public List<CloudCoreModule> InstalledSystemModules
        {
            get
            {
                return Environment.LoadedModules;
            }
        }

    }
}