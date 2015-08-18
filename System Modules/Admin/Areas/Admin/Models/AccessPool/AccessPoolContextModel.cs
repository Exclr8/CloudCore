using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authorization;

using CloudCore.Data;
using System.Linq;
using System.Collections.Generic;

namespace CloudCore.Admin.Models
{
    public class AccessPoolContextModel : BaseContextModel
    {
        public AccessPoolCachedReusableObject ActiveAccessPool = AccessPoolCachedReusableObject.LoadFromCache();

        [Display(Name = "AccessPoolId")]
        public int AccessPoolId
        {
            get
            {
                return ActiveAccessPool.AccessPoolId;
            }
            set
            {
                Key = value;
            }
        }

        [Display(Name = "Access Pool Name")]
        [Required(ErrorMessage = "Please specify a Access Pool name")]
        [StringLength(49, ErrorMessage = "Maximum of 50 allowed")]
        public string AccessPoolName { get { return ActiveAccessPool.AccessPoolName; } set { ActiveAccessPool.AccessPoolName = value; } }

        [Display(Name = "Manager")]
        [Required(ErrorMessage = "Please select a manager")]
        public int ManagerUserId { get { return ActiveAccessPool.UserId; } set { ActiveAccessPool.UserId = value; } }

        [Required]
        [Display(Name = "Manager")]
        public string ManagerName { get { return ActiveAccessPool.FullName; } set { ActiveAccessPool.FullName = value; } }

        [Display(Name = "Email")]
        public string ManagerEmail { get { return ActiveAccessPool.Email; } set { ActiveAccessPool.Email = value; } }

        [Display(Name = "Login")]
        public string ManagerLogin { get { return ActiveAccessPool.Login; } set { ActiveAccessPool.Login = value; } }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveAccessPool, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "AccessPool", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "AccessPool", new { area = "Admin", AccessPoolId = ActiveAccessPool.AccessPoolId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Modify", urlHelper.Action("Modify", "AccessPool", new { area = "Admin", AccessPoolId = ActiveAccessPool.AccessPoolId }));
        }

        public void AddUserToPool(int userId)
        {
            CloudCoreDB.Context.Cloudcore_AccessPoolUserCreate(this.AccessPoolId, userId);
            UserPermission.UpdateForChange();
        }

        public void RemoveUserFromPool(int userId )
        {
            CloudCoreDB.Context.Cloudcore_AccessPoolUserRemove(this.AccessPoolId, userId);
            UserPermission.UpdateForChange();
        }

        public void Modify()
        {
            CloudCoreDB.Context.Cloudcore_AccessPoolUpdate(this.AccessPoolId, this.AccessPoolName, this.ManagerUserId);
            ActiveAccessPool.UpdateCache();
        }

        public void CreateNew()
        {
            this.ActiveAccessPool = new AccessPoolCachedReusableObject();
        }

        public void Insert()
        {
            int? accesspoolId = null;
            CloudCoreDB.Context.Cloudcore_AccessPoolCreate(ref accesspoolId, this.AccessPoolName, this.ManagerUserId);
            this.AccessPoolId = accesspoolId.Value;
        }


        public List<AccessPoolMember> Members
        {

            get
            {
                CloudCoreDB db = CloudCoreDB.Context;
                return (from pooluser in db.Cloudcore_AccessPoolUser
                        join user in db.Cloudcore_User
                         on pooluser.UserId equals user.UserId
                        where pooluser.AccessPoolId == this.AccessPoolId
                        select new AccessPoolMember
                        {
                            UserId = pooluser.UserId,
                            AccessPoolId = pooluser.AccessPoolId,
                            Fullname = user.Fullname,
                            Email = user.Email
                        }).ToList();
            }
        }
    }
}