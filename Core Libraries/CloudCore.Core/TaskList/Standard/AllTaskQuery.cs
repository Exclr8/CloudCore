using CloudCore.Domain.Workflow;

namespace CloudCore.Core.TaskList.Standard
{
    public sealed class AllTaskQuery : StandardTaskListQuery
    {
        public override string Title
        {
            get { return "All Tasks"; }
        }

        public override string Description
        {
            get { return "Returns a list of all tasks available to the current user."; }
        }
    }
}