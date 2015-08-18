using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Web.Core.BaseModels;

using System.Data.Linq.SqlClient;
using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class PagesSearchModel : BaseSearchModel<PagesSearchItemModel>
    {
        public string FilterOptionsActionType { get; set; }
        public string FilterOptionsActionTitle { get; set; }
        public string FilterOptionsArea { get; set; }
        public string FilterOptionsController { get; set; }
        public string FilterOptionsAction { get; set; }
        public string FilterOptionsSysModule { get; set; }

        [Display(Name = "Action Type")]
        public string ActionType { get; set; }

        [Display(Name = "Action Title")]
        public string ActionTitle { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "System Module")]
        public string SystemModule { get; set; }

        public override void Search()
        {
            var database = CloudCoreDB.Context;

            var result = (from actions in database.Cloudcore_SystemAction
                          join sys in database.Cloudcore_SystemModule on actions.SystemModuleId equals sys.SystemModuleId
                          where actions.ActionType != "Folder"
                          select new PagesSearchItemModel
                          {
                              ActionId = actions.ActionId,
                              ActionTitle = actions.ActionTitle,
                              Area = actions.Area,
                              Controller = actions.Controller,
                              Action = actions.Action,
                              ActionType = actions.ActionType,
                              SystemModule = sys.AssemblyName
                          });
            if (!string.IsNullOrEmpty(ActionTitle))
            {
                result = result.Where(r => SqlMethods.Like(r.ActionTitle, string.Format(FilterOptionsActionTitle, ActionTitle)));
            }
            if (!string.IsNullOrEmpty(Area))
            {
                result = result.Where(r => SqlMethods.Like(r.Area, string.Format(FilterOptionsArea, Area)));
            }
            if (!string.IsNullOrEmpty(Controller))
            {
                result = result.Where(r => SqlMethods.Like(r.Controller, string.Format(FilterOptionsController, Controller)));
            }
            if (!string.IsNullOrEmpty(Action))
            {
                result = result.Where(r => SqlMethods.Like(r.Action, string.Format(FilterOptionsAction, Action)));
            }
            if (!string.IsNullOrEmpty(ActionType))
            {
                result = result.Where(r => SqlMethods.Like(r.ActionType, string.Format(FilterOptionsActionType, ActionType)));
            }
            if (!string.IsNullOrEmpty(SystemModule))
            {
                result = result.Where(r => SqlMethods.Like(r.SystemModule, string.Format(FilterOptionsSysModule, SystemModule)));
            }

            SearchResults = result;
        }
    }
}