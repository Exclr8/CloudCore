using CloudCore.Core;
using CloudCore.Core.Caching;
using CloudCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudCore.Authorization
{
    [Serializable]
    public class UserPermission
    {
        private readonly Guid AdminModuleGuid = Guid.Parse("51AA1E97-1CC7-42E1-9F3A-6AF89E0CDD3B");

        public static DateTime UpdateMaker = DateTime.Now;

        [Serializable]
        public class PermissionSet
        {
            public List<Guid> Permissions = new List<Guid>();
            public DateTime UpdateMaker { get; set; }
        }

        private PermissionSet _permissionSet;

        private void RefreshPermissions()
        {
            CloudCoreDB db = new CloudCoreDB();

            _permissionSet = new PermissionSet();

            var permittedList = db.Cloudcore_VwPermittedSystemActions.Where(r => r.UserId == CloudCoreIdentity.UserId).Select(r => r.ActionGuid);

            if (CloudCoreIdentity.IsAdministrator)
            {
                var adminlist = (from sm in db.Cloudcore_SystemModule
                                 join sa in db.Cloudcore_SystemAction
                                   on sm.SystemModuleId equals sa.SystemModuleId
                                 where sm.SystemModuleGuid == AdminModuleGuid
                                 select new { sa.ActionGuid }).ToList();

                adminlist.RemoveAll(r => permittedList.Contains(r.ActionGuid));
                _permissionSet.Permissions.AddRange(adminlist.Select(r => r.ActionGuid));
            }

            _permissionSet.Permissions.AddRange(permittedList);
            _permissionSet.UpdateMaker = UserPermission.UpdateMaker;

            SessionInfo.Session["CC_ACL"] = this._permissionSet;
        }

        public UserPermission()
        {
            var acl = SessionInfo.Session["CC_ACL"] as PermissionSet;
            if (acl == null)
            {
                RefreshPermissions();
            }
            else
            {
                _permissionSet = acl;
                if (_permissionSet.UpdateMaker != UserPermission.UpdateMaker)
                {
                    RefreshPermissions();
                    MenuData.ForceRefresh();
                }
            }
        }

        public bool IsAccessGranted(Guid actionGuid)
        {
            return _permissionSet.Permissions.Contains(actionGuid);
        }

        public static void UpdateForChange()
        {
            UserPermission.UpdateMaker = DateTime.Now;
        }

        public static bool TestForAccess(Guid actionGuid)
        {
            var userPermission = new UserPermission();
            return userPermission.IsAccessGranted(actionGuid);
        }
    }
}
