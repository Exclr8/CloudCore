using System;


namespace CloudCore.Web.Core.Workflow.Models
{
    public interface IWorkItemModel
    {
        void Cancel();
        void Delay( DateTime reactivateAt);
        void Navigate();
        void Release();
    }
}
