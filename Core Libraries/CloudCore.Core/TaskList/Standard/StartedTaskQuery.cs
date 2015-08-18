
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class StartedTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "Started Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all tasks started but not completed by the current user."; }
        }

        protected override IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist.Where(r => r.StatusTypeId == 1 && r.Delayed == false); }
        }
    }
}