using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CloudCore.Data;

namespace CloudCore.Web.Areas.CUI.Models.TaskList
{
    public class TaskListSearchReferencesModel
    {
        public List<SelectListItem> ReferenceTypes { get; set; }

        private TaskListSearchReferencesModel(List<SelectListItem> referenceTypes)
        {
            ReferenceTypes = referenceTypes;
        }

        public static TaskListSearchReferencesModel GetReferenceTypes()
        {
            var referenceTypes = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Key Value"
                }
            };

            var result = CloudCoreDB.Context.Cloudcore_ReferenceType.OrderBy(r => r.ReferenceType)
                .Select(r => new SelectListItem
                {

                    Value = r.ReferenceTypeId.ToString(),
                    Text = r.ReferenceType
                });

            referenceTypes.AddRange(result);

            return new TaskListSearchReferencesModel(referenceTypes);
        }
    }
}