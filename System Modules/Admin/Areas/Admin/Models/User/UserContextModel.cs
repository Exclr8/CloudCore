using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;
using System.Data.Linq;
using System.Linq;
using System.Web.Helpers;
using System.Collections.Generic;
using System;
using CloudCore.Web.Core.Security.Authorization;

namespace CloudCore.Admin.Models
{
    public class UserContextModel : BaseContextModel
    {
        public UserCachedReusableObject ActiveUser = UserCachedReusableObject.LoadFromCache();

        public int UserId
        {
            get
            {
                return ActiveUser.UserId;
            }
            set
            {
                Key = value;
            }
        }

        [Required(ErrorMessage = "Please enter Login Name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string Login { get { return ActiveUser.Login; } set { ActiveUser.Login = value; } }

        [Required(ErrorMessage = "Please enter Initials.")]
        [DataType(DataType.Text)]
        [Display(Name = "Initials")]
        public string Initials { get { return ActiveUser.Initials; } set { ActiveUser.Initials = value; } }

        [Required(ErrorMessage = "Please enter Firstname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname(s)")]
        public string FirstName { get { return ActiveUser.FirstName; } set { ActiveUser.FirstName = value; } }

        [Required(ErrorMessage = "Please enter Surname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string Surname { get { return ActiveUser.Surname; } set { ActiveUser.Surname = value; } }


        public string FullName { get { return ActiveUser.FullName; } }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Number")]
        [RegularExpression(@"^0[789][1-9][0-9]{7}", ErrorMessage = "Not a valid Cellphone Number")]
        public string CellNumber { get { return ActiveUser.CellNumber; } set { ActiveUser.CellNumber = value; } }

        [Required(ErrorMessage = "Please enter Email address.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Not a valid email address")]
        public string Email { get { return ActiveUser.Email; } set { ActiveUser.Email = value; } }

        [DataType(DataType.Text)]
        [Display(Name = "Image")]
        public byte[] Image { get { return ActiveUser.Image; } set { ActiveUser.Image = value; } }

        [Display(Name = "Internal Access")]
        public bool InternalAccess { get { return ActiveUser.InternalAccess; } set { ActiveUser.InternalAccess = value; } }

        [Display(Name = "External Access")]
        public bool ExternalAccess { get { return ActiveUser.ExternalAccess; } set { ActiveUser.ExternalAccess = value; } }

        [Display(Name = "Is System Administrator")]
        public bool IsAdministrator { get { return ActiveUser.IsAdministrator; } set { ActiveUser.IsAdministrator = value; } }

        public IEnumerable<AccessPoolItem> AccessPools
        {
            get
            {
                var db = CloudCoreDB.Context;
                return (from apu in db.Cloudcore_AccessPoolUser
                        join ap in db.Cloudcore_AccessPool on apu.AccessPoolId equals ap.AccessPoolId
                        join u in db.Cloudcore_User on ap.ManagerId equals u.UserId
                        where apu.UserId == ActiveUser.UserId
                        select new AccessPoolItem
                        {
                            AccessPoolId = ap.AccessPoolId,
                            AccessPoolName = ap.AccessPoolName,
                            ManagerId = u.UserId,
                            ManagerName = u.Fullname
                        });
            }
        }


        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveUser, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search",  urlHelper.Action("Search", "User", new { area = "Admin", UserId = ActiveUser.UserId }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "User", new { area = "Admin", UserId = ActiveUser.UserId }));

            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Modify", urlHelper.Action("Update", "User", new { area = "Admin", UserId = ActiveUser.UserId }));
            if (this.UserId != CloudCoreIdentity.UserId)
            {
                sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "System Access", urlHelper.Action("UserAccessStatus", "User", new { userId = ActiveUser.UserId }));
                sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Reset Password", urlHelper.Action("UserResetPassword", "User", new { userId = ActiveUser.UserId }));
            }
            base.InitializeSidebar(sidebar, urlHelper);
        }


        public void CreateNew()
        {
            ActiveUser = new UserCachedReusableObject();
        }

        public void Insert()
        {
            int? userId = null;
            CloudCoreDB.Context.Cloudcore_UserCreate(Login, Email, Initials, FirstName, Surname, CellNumber, true, false, ref userId);
            this.UserId = userId.Value;
            ActiveUser.ForceRefresh();
        }


        public void Update()
        {
            CloudCoreDB.Context.Cloudcore_UserModify(this.UserId, this.Initials, this.FirstName, this.Surname, this.CellNumber, this.Email);
            ActiveUser.UpdateCache();
        }

        public void UpdateUserAccess()
        {
            CloudCoreDB.Context.Cloudcore_UserUpdateAccess(this.UserId, this.InternalAccess, this.ExternalAccess, this.IsAdministrator);
            ActiveUser.UpdateCache();
        }

        public void UpdateImage(WebImage image)
        {
            if (image != null)
            {
                var mainImage = image.Resize(215, 275, preventEnlarge: true).GetBytes();
                this.Image = image.Resize(115, 175, preventEnlarge: true).GetBytes();
                CloudCoreDB.Context.Cloudcore_UpdateUserImage(mainImage, this.Image, this.UserId);
            }
            ActiveUser.UpdateCache();
        }

        public void RemoveUserFromAccessPool(int accessPoolId) //See AccessPoolContextModel.RemoveUserFromPool(int userId )
        {
            CloudCoreDB.Context.Cloudcore_AccessPoolUserRemove(accessPoolId, this.UserId);
            UserPermission.UpdateForChange();
        }

        public void AddUserToAccessGroup(int accessPoolId) //See AccessPoolContextModel.AddUserToPool(int userId)
        {
            CloudCoreDB.Context.Cloudcore_AccessPoolUserCreate(accessPoolId, this.UserId);
            UserPermission.UpdateForChange();
        }

        public Guid GetPasswordResetGuid()
        {
            Guid? passwordResetReferenceGuid = null;
            CloudCoreDB.Context.Cloudcore_UserResetPasswordRequest(this.Email, ref passwordResetReferenceGuid);
            return passwordResetReferenceGuid.Value;
        }

    }

  

}