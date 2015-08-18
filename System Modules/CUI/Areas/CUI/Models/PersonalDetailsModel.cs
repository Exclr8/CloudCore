using System.Web.Mvc;
using CloudCore.Core;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authentication;
using System.Collections.Generic;
using CloudCore.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using System;
using CloudCore.Web.Classes.CachedReusableObjects;

namespace CloudCore.Web.Models
{
    public class PersonalDetailsModel : BaseContextModel
    {
        public PersonalInfoCachedReusableObject ActiveUser = PersonalInfoCachedReusableObject.LoadFromCache();

        public long UserId
        {
            get { return CloudCoreIdentity.UserId; }
            set { Key = value; }
        }

        #region Public Properties

        [Required(ErrorMessage = "Please enter Login name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        [StringLength(320, ErrorMessage = "Login cannot be longer than 320 characters.")]
        public string Login { get { return ActiveUser.Login; } set { ActiveUser.Login = value; } }

        [Required(ErrorMessage = "Please enter Initials.")]
        [DataType(DataType.Text)]
        [Display(Name = "Initials")]
        [StringLength(15, ErrorMessage = "Initials cannot be longer than 15 characters.")]
        public string Initials { get { return ActiveUser.Initials; } set { ActiveUser.Initials = value; } }

        [Required(ErrorMessage = "Please enter Firstname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname(s)")]
        [StringLength(100, ErrorMessage = "Firstname cannot be longer than 100 characters.")]
        public string FirstName { get { return ActiveUser.FirstName; } set { ActiveUser.FirstName = value; } }

        [Required(ErrorMessage = "Please enter Surname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        [StringLength(30, ErrorMessage = "Surname cannot be longer than 30 characters.")]
        public string Surname { get { return ActiveUser.Surname; } set { ActiveUser.Surname = value; } }

        [Required(ErrorMessage = "Please enter Cell Number.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Number")]
        [StringLength(15, ErrorMessage = "Cell Number cannot be longer than 15 digits.")]
        [RegularExpression(@"^0[789][1-9][0-9]{7}", ErrorMessage = "Not a valid Cellphone Number")]
        public string CellNumber { get { return ActiveUser.CellNumber; } set { ActiveUser.CellNumber = value; } }

        [Required(ErrorMessage = "Please enter Email Address.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.([a-zA-Z]{2,4})$", ErrorMessage = "Not a valid email address.")]
        public string Email { get { return ActiveUser.Email; } set { ActiveUser.Email = value; } }

        [DataType(DataType.Text)]
        [Display(Name = "Image")]
        public byte[] Image 
        { 
            get 
            {
                return ActiveUser.Image != null
                ? ActiveUser.Image.ToArray()
                : null;
            } 
            set 
            { 
                ActiveUser.Image = value; 
            } 
        }
        #endregion


        public IEnumerable<AccessPoolModel> AccessPools
        {
            get
            {
                CloudCoreDB db = new CloudCoreDB();
                var query = (from vwap in db.Cloudcore_VwAccessPool
                             where vwap.UserId == CloudCoreIdentity.UserId
                             select new AccessPoolModel
                             {
                                 AccessPoolId = vwap.AccessPoolId,
                                 AccessPoolName = vwap.AccessPoolName,
                                 ManagerName = vwap.Fullname
                             });

                return query;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveUser, key);
            base.OnKeyChanged(ActiveUser.UserId);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, urlHelper, "Notifications", "Notifications", "Tools", new {});
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, urlHelper, "Access Pools", "ViewAccessPools", "Tools", new { });
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, urlHelper, "View Details", "PersonalDetails", "Tools", new { });
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, urlHelper, "Update Details", "UpdatePersonalDetails", "Tools", new { userId = UserId });
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, urlHelper, "Change Password", "ChangePassword", "Tools", new { userId = UserId });
        }


        public void UpdateImage(WebImage image)
        {
            if (image != null)
            {
                int? userId = (int)this.UserId;
                var mainImage = image.Resize(215, 275, preventEnlarge: true).GetBytes();
                this.Image = image.Resize(115, 175, preventEnlarge: true).GetBytes();
                CloudCoreDB.Context.Cloudcore_UpdateUserImage(mainImage, this.Image, userId);
            }
            ActiveUser.UpdateCache();
        }


        public void Update()
        {
            int? userId = (int)this.UserId;
            CloudCoreDB.Context.Cloudcore_UserModify(userId, this.Initials, this.FirstName, this.Surname, this.CellNumber, this.Email);
            ActiveUser.UpdateCache();
        }
    }
}