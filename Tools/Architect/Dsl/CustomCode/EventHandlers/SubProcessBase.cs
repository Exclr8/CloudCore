using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Architect
{
    public partial class SubProcessBase
    {
        internal sealed partial class SubProcessNamePropertyHandler
        {
            protected override void OnValueChanging(SubProcessBase element, string oldValue, string newValue)
            {
                base.OnValueChanging(element, oldValue, newValue);

                if (element.Store.InSerializationTransaction)
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "create new model")
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Update Sub Process Reference")
                    return;

                if (oldValue == newValue)
                    return;

                UpdateSubProcessInProcessOverview(element, oldValue, newValue);

                RenameAllConnectedFromProcessConnectors(element, oldValue, newValue);
                RenameAllConnectedToProcessConnectors(element, oldValue, newValue);
            }

            private void RenameAllConnectedToProcessConnectors(SubProcessBase element, string oldValue, string newValue)
            {
                foreach (var item in element.Activities.OfType<FromProcessConnector>())
                {
                    var toProcessConnector = item.InitiatingToProcessConnector() as ToProcessConnector;
                    var newVal = toProcessConnector.ToProcessConnectorName.Replace(oldValue, newValue);

                    using (Transaction t = toProcessConnector.Store.TransactionManager.BeginTransaction("Change Sub Process Name"))
                    {
                        toProcessConnector.ToProcessConnectorName = newVal;
                        t.Commit();
                    }
                }
            }

            private void RenameAllConnectedFromProcessConnectors(SubProcessBase element, string oldValue, string newValue)
            {
                foreach (var item in element.Activities.OfType<ToProcessConnector>())
                {
                    var fromProcessConnector = item.ToExternalFromProcessConnector() as FromProcessConnector;
                    var newVal = fromProcessConnector.FromProcessConnectorName.Replace(oldValue, newValue);

                    using (Transaction t = fromProcessConnector.Store.TransactionManager.BeginTransaction("Change Sub Process Name"))
                    {
                        fromProcessConnector.FromProcessConnectorName = newVal;
                        t.Commit();
                    }
                }
            }

            private static void UpdateSubProcessInProcessOverview(SubProcessBase element, string oldValue, string newValue)
            {
                if (element.ProcessOverviewSubProcessRef == null)
                    return;

                IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;

                using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(element.ProcessOverviewSubProcessRef))
                {
                    if (adapterExternalRef == null)
                        return;

                    var targetSubProcess = (ProcessOverview.SubProcessElement)adapterExternalRef.ResolveElementReference(element.ProcessOverviewSubProcessRef);

                    if (targetSubProcess == null)
                        return;

                    targetSubProcess.SetLocks(Locks.None);

                    using (Transaction t = targetSubProcess.Store.TransactionManager.BeginTransaction("Change Sub Process Name"))
                    {
                        targetSubProcess.Name = newValue;
                        targetSubProcess.VisioId = element.VisioId;
                        t.Commit();
                    }

                    targetSubProcess.SetLocks(Locks.Delete | Locks.Add | Locks.Move | Locks.Properties);
                }
            }
        }

        internal sealed partial class ProcessRefPropertyHandler
        {
            protected override void OnValueChanging(SubProcessBase element, ModelBusReference oldValue, ModelBusReference newValue)
            {
                base.OnValueChanging(element, oldValue, newValue);

                if (element.Store.InSerializationTransaction)
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "create new model")
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Update Sub Process Reference")
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Change SubProcessRef")
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Init Items")
                    return;

                AddSubProcessToOverView(element, oldValue, newValue);
                AddReferencedSubProcesses(element, newValue);

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Update Linked Sub Process Reference")
                    return;

                AddConnectors(element, newValue);
            }
        }
    }
}
