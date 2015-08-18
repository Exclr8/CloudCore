using CloudCore.Core.TaskList.Standard;
using CloudCore.Domain.Workflow;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Core.TaskList
{
    public static class TaskListQueryList
    {
        private static ITaskListQuery[] standardTaskList = new List<ITaskListQuery>().ToArray();
        public static ITaskListQuery[] StandardTaskList
        {
            get { return standardTaskList; }
            set { standardTaskList = value; }
        }

        private static IEnumerable<ITaskListQuery> customQueryList = new List<ITaskListQuery>();
        public static IEnumerable<ITaskListQuery> CustomQueryList
        {
            get { return customQueryList;  }
            set { customQueryList = value; }
        }

        public static List<TaskItem> GetStandardTasklist(int index, int referenceTypeId, string referenceValue, int userId, int applicationId)
        {
            return StandardTaskList[index].Execute(userId, referenceTypeId, referenceValue, applicationId).ToList();
        }

        public static List<TaskItem> GetCustomTasklist(int index, int referenceTypeId, string referenceValue, int userId, int applicationId)
        {
            return CustomQueryList.ToArray()[index].Execute(userId, referenceTypeId, referenceValue, applicationId).ToList();
        }
    }
}
