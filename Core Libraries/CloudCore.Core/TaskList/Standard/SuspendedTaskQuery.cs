
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class SuspendedTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "Suspended Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all tasks currently suspended and allocated to the current user."; }
        }

        protected override IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist.Where(r => r.Delayed == true); }
        }
    }
}