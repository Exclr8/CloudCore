using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Architect.ProcessOverview
{
    public partial class SubProcessConnector
    {
        public override void OnShapeInserted()
        {
            base.OnShapeInserted();

            this.ModelElement.SetLocks(Locks.Delete | Locks.Add | Locks.Move | Locks.Properties);
        }
    }
}
