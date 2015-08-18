using System.Collections.Generic;
using System.Linq;
using CloudCore.Core.Modules;
using CloudCore.Web.Core.Security.Authorization;


namespace CloudCore.Web.Core.Menu
{
    public static class MenuStructure
    {

        public static List<ModuleActionAndParent> GetCompleteMenuStructure()
        {
            var menuStructure = (from citem in Environment.LoadedModuleActions.Actions.Values.Where(r => r.IsMenuItem)
                                 let parentFolderGuid = citem.ParentFolderGuid
                                 where parentFolderGuid != null
                                 join pitem in Environment.LoadedModuleActions.Actions.Values.Where(r => r.IsFolder)
                                   on parentFolderGuid.Value equals pitem.ActionGuid
                                 select new ModuleActionAndParent
                                 {
                                     Action = citem,
                                     Parent = pitem
                                 }).ToList();
            return menuStructure;
        }

        public static List<ModuleActionAndParent> GetPermittedMenuStructure()
        {
            var userPermissions = new UserPermission();
            var menustructure = GetCompleteMenuStructure().Where(p => p.Action.IsFolder || userPermissions.IsAccessGranted(p.Action.ActionGuid)).ToList();
            return menustructure;
        }

        public static IEnumerable<MenuItem> PermittedMenuItems()
        {
            var permitted = GetPermittedMenuStructure();
            permitted.RemoveAll(r => r.Action.IsFolder && !permitted.Select(o => o.Parent.ActionGuid).Contains(r.Action.ActionGuid));
            return permitted.Select(r => r.TransformAsMenuItem()).OrderByDescending(r => r.isFolder).ThenBy(r => r.Title);
        }

    }
}
