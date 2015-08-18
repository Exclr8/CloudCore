
using System.Linq;
using CloudCore.Data.Buildbase;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class OfferedTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "Offered Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all offered tasks the current user can complete."; }
        }

        protected override IQueryable<Cloudcore_VwTasklist> DataSource
        {
            get { return Datacontext.Cloudcore_VwTasklist.Where(r => r.Delayed == false && r.StatusTypeId == 0); }
        }
    }
}