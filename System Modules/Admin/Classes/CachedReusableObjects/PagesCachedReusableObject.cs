using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class PagesCachedReusableObject : BaseCachedReusableObject<PagesCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "Page Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Action Title", ActionTitle);
            content.AddHtmlContent("Area", Area);
            content.AddHtmlContent("Controller", Controller);
            content.AddHtmlContent("Action Type", ActionType);
            content.AddHtmlContent("Action", Action);
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;

            var result = (from sa in database.Cloudcore_SystemAction
                          join sys in database.Cloudcore_SystemModule on sa.SystemModuleId equals sys.SystemModuleId
                          where sa.ActionId == ActionId
                          select new
                          {
                              sa.ActionType,
                              sa.ActionTitle,
                              sa.Action,
                              sa.ActionId,
                              sa.Area,
                              sa.Controller,
                              sys.AssemblyName
                          }).SingleOrDefault();


            ActionType = result.ActionType;
            ActionTitle = result.ActionTitle;
            Area = result.Area;
            Controller = result.Controller;
            Action = result.Action;
            SystemModule = result.AssemblyName;
        }

        #region Properties

        public int ActionId { get { return Convert.ToInt32(Key); } }
        public string ActionType { get; set; }
        public string ActionTitle { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string SystemModule { get; set; }

        #endregion
    }
}