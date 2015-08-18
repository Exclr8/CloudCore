using CloudCore.Core.Menu;

namespace CloudCore.Core.Modules
{
    public interface IModuleConfiguration
    {
        void LoadModuleActions(MenuRoot configuration);
        string GetAreaName();
    }
}
