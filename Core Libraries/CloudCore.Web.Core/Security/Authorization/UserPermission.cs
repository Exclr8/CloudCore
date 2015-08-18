using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Core.Security.Authorization
{
    [Serializable]
    public class PermissionSet
    {
        public List<Guid> Permissions = new List<Guid>();
        public DateTime LastUpdated { get; set; }
    }

    [Serializable]
    public class UserPermission
    {
        private readonly Guid adminModuleGuid = Guid.Parse("51AA1E97-1CC7-42E1-9F3A-6AF89E0CDD3B");
        private PermissionSet permissionSet;

        public static DateTime LastUpdated
        {
            get
            {
                if (SessionInfo.Session["CC_ACL_LastUpdated"] == null)
                    SessionInfo.Session["CC_ACL_LastUpdated"] = DateTime.Now;

                return Convert.ToDateTime(SessionInfo.Session["CC_ACL_LastUpdated"]);

            }
            set
            {
                SessionInfo.Session["CC_ACL_LastUpdated"] = value;
            }
        }

        private void RefreshPermissions()
        {
            permissionSet = new PermissionSet();

            var permittedList = CloudCoreDB.Context.Cloudcore_VwPermittedSystemActions.Where(psa => psa.UserId == CloudCoreIdentity.UserId)
                .Select(r => r.ActionGuid).ToList();

            permissionSet.Permissions.AddRange(permittedList);

            AddAdminPermissions();

            permissionSet.LastUpdated = LastUpdated;

            SessionInfo.Session["CC_ACL"] = permissionSet;
        }

        private void AddAdminPermissions()
        {
            if (CloudCoreIdentity.IsAdministrator)
            {
                var dbContext = CloudCoreDB.Context;

                var adminlist = (from sm in dbContext.Cloudcore_SystemModule
                                 join sa in dbContext.Cloudcore_SystemAction
                                   on sm.SystemModuleId equals sa.SystemModuleId
                                 where sm.SystemModuleGuid == adminModuleGuid
                                 select new { sa.ActionGuid }).ToList();

                adminlist.RemoveAll(r => permissionSet.Permissions.Contains(r.ActionGuid));
                permissionSet.Permissions.AddRange(adminlist.Select(r => r.ActionGuid));
            }
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
                permissionSet = acl;

                if (permissionSet.LastUpdated == LastUpdated)
                    return;

                RefreshPermissions();
                MenuData.ForceRefresh();
            }
        }

        public bool IsAccessGranted(Guid actionGuid)
        {
            return permissionSet.Permissions.Contains(actionGuid);
        }

        public static void UpdateForChange()
        {
            LastUpdated = DateTime.Now;
        }

        public static bool TestForAccess(Guid actionGuid)
        {
            var userPermission = new UserPermission();
            return userPermission.IsAccessGranted(actionGuid);
        }
    }
}
