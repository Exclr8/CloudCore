using System;
using System.Data.Linq;
using System.Linq;
using Architect.CustomCode.Helpers;
using Microsoft.VisualStudio.Modeling;
using System.Windows.Forms;

namespace Architect
{
    public partial class Flow
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (this.SourceActivity is FromProcessConnector)
                if (!((FromProcessConnector)SourceActivity).CanDelete)
                    throw new InvalidOperationException("This item cannot be deleted.");
        }

        internal sealed partial class OutcomePropertyHandler
        {
            protected override void OnValueChanged(Flow element, string oldValue, string newValue)
            {
                if (element.Store.InSerializationTransaction)
                    return;

                if (!(element.Store.TransactionManager.CurrentTransaction.Name == "Set Outcome"))
                    return;

                if (oldValue == newValue)
                    return;

                var x = FlowBase.GetLinksToTargetActs(element.SourceActivity);
                var count = x.Where(a => (a as Flow).Outcome == newValue && (a as Flow).VisioId != element.VisioId).Count();

                if (count > 0)
                {
                    element.Outcome = oldValue;

                    MessageBox.Show(string.Format("Flow with Outcome '{0}' already exists on {1}", newValue, element.SourceActivity.Name),
                                    "Invalid Outcome",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    base.OnValueChanged(element, oldValue, newValue);
                }
            }
        }
    }


}
