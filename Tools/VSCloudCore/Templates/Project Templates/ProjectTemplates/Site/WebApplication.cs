using CloudCore.Core.Modules;

namespace $safeprojectname$.Site
{
    public class $safeprojectname$WebApplication : CloudCore.Web.Core.Application
    {
        protected override void RegisterWebModules()
        {
            CoreCUIModule.Register();
            CoreAdminModule.Register();
            throw new NotImplementedException();
        }
    }
}
