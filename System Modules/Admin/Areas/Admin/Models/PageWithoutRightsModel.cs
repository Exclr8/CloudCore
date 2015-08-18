using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class PageWithoutRightsModel : BaseSearchModel<PagesSearchItemModel>
    {
        public override void Search()
        {
            var database = CloudCoreDB.Context;

            var result = (from sa in database.Cloudcore_SystemAction
                          join sys in database.Cloudcore_SystemModule on sa.SystemModuleId equals sys.SystemModuleId
                          where sa.ActionType != "Folder" &&
                            !(from saa in database.Cloudcore_SystemActionAllocation
                              select saa.ActionId).Contains(sa.ActionId)
                          select new PagesSearchItemModel
                          {
                              ActionId = sa.ActionId,
                              ActionTitle = sa.ActionTitle,
                              Area = sa.Area,
                              Controller = sa.Controller,
                              Action = sa.Action,
                              ActionType = sa.ActionType,
                              SystemModule = sys.AssemblyName
                          });
            SearchResults = result;
        }
    }
}