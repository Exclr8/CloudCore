using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudCore.Web.Core.Security.Authorization;


// ReSharper disable once CheckNamespace
namespace CloudCore.Web.Core
{
    public enum SidebarObjectType
    {
        ViewDisplay = 0,
        ManageConfigure = 1,
        ReportDocument = 2
    }

    [Serializable]
    public class SidebarObject
    {
        public string Title { get; set; }

        public string Link { get; set; }
    }

    [Serializable]
    public class SidebarObjectList
    {
        public string Title { get; internal set; }

        public List<SidebarObject> Items { get; internal set; }

        public SidebarObjectList()
        {
            Items = new List<SidebarObject>();
        }
    }

    public abstract class SidebarBase : List<SidebarObjectList>
    {
        public virtual string SidebarListItemPartialViewName()
        {
            return "~/Areas/CUI/Views/Shared/Sidebar/_DetailPageSidebarItem.cshtml";
        }

        protected void AddMenuCategory(string title)
        {
            Add(new SidebarObjectList { Title = title });
        }

        protected void AddSidebarMenuItem(int categoryIndex, string title, string link)
        {
            this[categoryIndex].Items.Add(new SidebarObject
            {
                Title = title,
                Link = link
            });
        }

        protected void AddSidebarMenuItem(int categoryIndex, SidebarObject sidebarObject)
        {
            this[categoryIndex].Items.Add(sidebarObject);
        }
    }

    public class Sidebar : SidebarBase
    {
        public bool CanDisplay
        {
            get
            {
                return this.Any(r => r.Items.Any());
            }
        }

        public Sidebar()
        {
            AddMenuCategory("View & Display");
            AddMenuCategory("Manage & Configure");
            AddMenuCategory("Report & Documents");
        }

        public void AddSidebarItem(SidebarObjectType type, string title, string link)
        {
            this[(int)type].Items.Add(new SidebarObject { Title = title, Link = link });
        }
      
        
        public void AddSidebarItem(SidebarObjectType type, UrlHelper urlHelper, string title, string action, string controllerName, object routeValues)
        {
            var area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
            var moduleAction = CloudCore.Core.Modules.Environment.LoadedModuleActions.FindAction(area, controllerName, action);
            if (moduleAction == null || UserPermission.TestForAccess(moduleAction.ActionGuid))
            {
                AddSidebarMenuItem((int) type, title, urlHelper.Action(action, controllerName, routeValues));
            }
        }
    }
}
