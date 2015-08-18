using System.Web.Mvc;
using CloudCore.Core.Logging;
using CloudCore.Logging;

namespace CloudCore.Web.Core.Configuration
{
    public static class ViewEngineConfig
    {
        public static void RegisterViewEngine()
        {
            Logger.Info("Initializing View Engine...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEngine());
        }
    }
}
