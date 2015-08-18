using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CloudCore.Admin.CRO;
using CloudCore.Domain;
using CloudCore.Web.Core;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemValueContext : SystemValueCategoryContext
    {
        public SystemValueCachedReusableObject SystemValue = SystemValueCachedReusableObject.LoadFromCache();

        public int ValueId
        {
            get
            {
                return SystemValue.ValueId;
            }
            set
            {
                Key = value;
            }
        }

        [Display(Name = "Name")]
        [Required]
        [StringLength(50, ErrorMessage = "A Maximum of 50 Characters is allowed for System Value Name.")]
        public string ValueName { get { return SystemValue.ValueName; } set { SystemValue.ValueName = value; } }

        [Display(Name = "Value Data")]
        [Required]
        [StringLength(8000, ErrorMessage = "A Maximum of 8000 Characters is allowed for System Value Name.")]
        public string ValueData { get { return SystemValue.ValueData; } set { SystemValue.ValueData = value; } }

        [Display(Name = "Description")]
        [Required]
        [StringLength(8000, ErrorMessage = "A Maximum of 8000 Characters is allowed for System Description.")]
        public string ValueDescription { get { return SystemValue.ValueDescription; } set { SystemValue.ValueDescription = value; } }


        protected override void OnKeyChanged(long key)
        {
            AddKeyed(SystemValue, key);
            base.OnKeyChanged(SystemValue.CategoryId);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "SystemValues", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "SystemValues", new { area = "Admin", CategoryId = SystemValue.CategoryId }));
        }

        public void Update()
        {
            CloudCoreDB.Context.Cloudcore_SystemValueUpdate(CategoryId, ValueName, ValueData,
                   ValueDescription);
           
            SystemValue.UpdateCache();
        }

    }
}