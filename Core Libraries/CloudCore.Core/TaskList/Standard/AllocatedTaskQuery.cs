using System.Data.Linq;
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class AllocatedTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "Allocated Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all tasks allocated to the current user."; }
        }

        protected override IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist.Where(r => r.StatusTypeId == 3 && r.Delayed == false); }
        }
    }
}