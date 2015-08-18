using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CloudCore.Admin.CRO;
using CloudCore.Domain;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemApplicationContext : BaseContextModel
    {
        public SystemApplicationCachedReusableObject SystemApplication = SystemApplicationCachedReusableObject.LoadFromCache();

        public int ApplicationId { get { return SystemApplication.ApplicationId; } set { this.Key = value; } }

        [Required]
        [Display(Name = "Application Name")]
        public string ApplicationName { get { return SystemApplication.ApplicationName; } set { SystemApplication.ApplicationName = value; } }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get { return SystemApplication.CompanyName; } set { SystemApplication.CompanyName = value; } }

        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get { return SystemApplication.ContactPerson; } set { SystemApplication.ContactPerson = value; } }

        [Required]
        [Display(Name = "Contact Number")]
        [RegularExpression("^(([0-9]|\\+)(\\d{9})|(\\d{11}))$", ErrorMessage = "Not a valid contact number.")]
        public string ContactNumber { get { return SystemApplication.ContactNumber; } set { SystemApplication.ContactNumber = value; } }

        [Display(Name = "Enabled")]
        public bool Enabled { get { return SystemApplication.Enabled; } set { SystemApplication.Enabled = value; } }


        protected override void OnKeyChanged(long key)
        {
            AddKeyed(SystemApplication, key);
            base.OnKeyChanged( key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("FindApplication", "SystemApplication", new { area = "Admin"}));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "SystemApplication", new { area = "Admin", applicationId = SystemApplication.ApplicationId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Modify", urlHelper.Action("ModifyApplication", "SystemApplication", new { area = "Admin", applicationId = SystemApplication.ApplicationId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Delete", urlHelper.Action("DeleteApplication", "SystemApplication", new { area = "Admin", applicationId = SystemApplication.ApplicationId }));
        }



        public void New()
        {
            this.SystemApplication = new SystemApplicationCachedReusableObject();
        }

        public void Create()
        {
            int? _applicationId = null;
            CloudCoreDB.Context.Cloudcore_SystemApplicationCreate(this.ApplicationName, this.CompanyName, this.ContactPerson, this.ContactNumber, ref _applicationId);
            this.ApplicationId = _applicationId.Value;
        }

        public void Update()
        {
            CloudCoreDB.Context.Cloudcore_SystemApplicationUpdate(this.ApplicationId, this.ApplicationName, this.CompanyName, this.ContactPerson, this.ContactNumber, this.Enabled);
            SystemApplication.UpdateCache();
        }

        public void Delete()
        {
            CloudCoreDB.Context.Cloudcore_SystemApplicationDelete(this.ApplicationId);
        }

    }
}