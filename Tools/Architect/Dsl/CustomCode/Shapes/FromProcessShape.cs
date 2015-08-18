using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling;

namespace Architect
{
    public partial class FromProcessConnectorShape
    {
        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusReference reference = ((FromProcessConnector)this.ModelElement).FromProcessConnectorRef;
            ModelBusAdapter adapter = modelBus.CreateAdapter(reference);
            ModelBusView view = adapter.GetDefaultView();

            if (view != null)
            {
                view.Open();
                view.SetSelection(reference);
                view.Show();
            }

            adapter.Dispose();
        }
    }

    public partial class FromProcessConnector
    {
        protected override void OnDeleting()
        {
            DeleteReferencedActivityAndProcessOverviewConnector();

            base.OnDeleting();
        }

        public dynamic InitiatingToProcessConnector()
        {
               if (this.FromProcessConnectorRef == null)
                return null;

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;

            using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(this.FromProcessConnectorRef))
            {
                if (adapterExternalRef == null)
                    return null;

                var toProcessConnector = adapterExternalRef.ResolveElementReference(this.FromProcessConnectorRef) as ToProcessConnector;

                return toProcessConnector;
            }
        }

        public void DeleteReferencedActivityAndProcessOverviewConnector()
        {
            //get the toprocessconnector
            var toProcessConnector = this.InitiatingToProcessConnector() as ToProcessConnector;

            if (toProcessConnector == null)
                return;

            //get activity target of toprocessconnector
            var activity = toProcessConnector.SourceActivities.FirstOrDefault();

            if (activity == null)
                activity = toProcessConnector.SourceActs.FirstOrDefault();

            if (activity == null)
                activity = toProcessConnector.SActivity.FirstOrDefault();

            using (Transaction t = activity.Store.TransactionManager.BeginTransaction("Delete from activity"))
            {
                var endSubProcess = Store.ElementDirectory.AllElements.OfType<SubProcess>().FirstOrDefault() as SubProcess;

                if (endSubProcess != null)
                    ToProcessConnector.DeleteProcessOverviewConnector(activity.SubProcess, endSubProcess);

                toProcessConnector.Reset();
                t.Commit();
            }
        }
    }
}
