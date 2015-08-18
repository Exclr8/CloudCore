using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.ProcessOverview
{
    public partial class SubProcess
    {
        public static DeleteConnectorToTarget(SubProcess TargetSubProcess)
        {
               //get connector in process overview
            var connectors = ProcessOverview.SubProcessReferencesTargets.GetLinks(this, TargetSubProcess);

            if (connectors.Count > 0)
            {
                var connector = connectors.First();

                using (Transaction t = connector.Store.TransactionManager.BeginTransaction("Delete connectors in processoverview"))
                {
                    connector.Delete();
                    t.Commit();
                }
            }
        }
    }
}
