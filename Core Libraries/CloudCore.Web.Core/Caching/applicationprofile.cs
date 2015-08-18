using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using CloudCore.Web.Core.Workflow;

using CloudCore.Core.TaskList;
using CloudCore.Domain.Workflow;
using CloudCore.Data;

namespace CloudCore.Web.Core.Caching
{
    [Serializable]
    public class ApplicationProfile : LiteralCache<ApplicationProfile>
    {
        public string ApplicationName { get { return WebApplication.Configuration.WebSettings.SiteName; } }
        public string Version { get { return WebApplication.Configuration.WebSettings.SiteVersion; } }
        public string CoreVersion { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        //private readonly TaskQueryList standardTaskQuery;
        //public TaskQueryList StandardTaskQueries
        //{
        //    get { return standardTaskQuery; }
        //}

        //private readonly TaskQueryList customTaskQuery;
        //public TaskQueryList CustomTaskQueries
        //{
        //    get { return customTaskQuery; }
        //}

        private readonly ReferenceTypeList referenceTypes;
        public ReferenceTypeList ReferenceTypes
        {
            get { return referenceTypes; }
        }

        public ApplicationProfile()
        {
            //standardTaskQuery = new TaskQueryList();
            //customTaskQuery = new TaskQueryList();
            referenceTypes = new ReferenceTypeList();
        }

        protected override void Update()
        {
            //AddTaskQueryItems(standardTaskQuery, TaskListQueryList.StandardQueryList);
            //AddTaskQueryItems(customTaskQuery, TaskListQueryList.CustomQueryList);

            referenceTypes.Items.Clear();
            referenceTypes.Items.Add(new ReferenceType { Id = 0, TypeName = "KeyValue" });

            referenceTypes.Items.AddRange(CloudCoreDB.Context.Cloudcore_ReferenceType
                .Select(r => new ReferenceType
                {
                    Id = (int)r.ReferenceTypeId,
                    TypeName = r.ReferenceType
                }));
            base.Update();
        }

        //private void AddTaskQueryItems(TaskQueryList taskQueryList, IList<ITaskListQuery> items)
        //{
        //    taskQueryList.Items.Clear();
        //    for (var i = 0; i < items.Count; i++)
        //    {
        //        taskQueryList.Items.Add(new TaskQuery { Title = items[i].Title, ListId = i.ToString(CultureInfo.InvariantCulture) });
        //    }
        //}
    }
}
