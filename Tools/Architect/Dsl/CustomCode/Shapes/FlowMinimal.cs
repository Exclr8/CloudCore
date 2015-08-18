using EnvDTE;
using System;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class FlowMinimal
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (this.SourceActivity is FromProcessConnector)
                this.SourceActivity.Delete();

            if (this.TargetActivity is ToProcessConnector)
                this.TargetActivity.Delete();

        }
    }
}
