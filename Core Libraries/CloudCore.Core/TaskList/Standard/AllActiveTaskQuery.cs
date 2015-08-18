
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class AllActiveTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "All Active Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all active tasks available to the current user."; }
        }

        protected override IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist.Where(r => r.Delayed == false); }
        }
    }
}