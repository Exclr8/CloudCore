using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Architect
{
    public partial class ToProcessConnectorShape
    {
        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusReference reference = ((ToProcessConnector)this.ModelElement).ToProcessConnectorRef;
            using (ModelBusAdapter adapter = modelBus.CreateAdapter(reference))
            {
                ModelBusView view = adapter.GetDefaultView();

                if (view != null)
                {
                    view.Open();
                    view.SetSelection(reference);
                    view.Show();
                }
            }
        }
    }

    public partial class ToProcessConnector
    {
        public void Reset()
        {
            this.ExternalActivityRef = null;
            this.ToProcessConnectorRef = null;
            this.ToProcessConnectorName = string.Empty;
        }

        public dynamic ToExternalFromProcessConnector()
        {
            if (this.ExternalActivityRef == null)
                return null;

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;

            using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(this.ExternalActivityRef))
            {
                if (adapterExternalRef == null)
                    return null;

                dynamic toProcessConnector = adapterExternalRef.ResolveElementReference(this.ExternalActivityRef);

                return toProcessConnector;
            }
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            DeleteReferencedActivityAndProcessOverviewConnector(this);

            return;
        }

        public static void DeleteReferencedActivityAndProcessOverviewConnector(ToProcessConnector startActivity)
        {
            //get the end activity
            try
            {
                var endActivity = startActivity.ToExternalFromProcessConnector();

                if (endActivity == null)
                    return;

                UpdateStartActivityProperties(startActivity);

                //get start sub process
                var startSubProcess = startActivity.SubProcess;

                //get end activity subprocess
                var endSubProcess = endActivity.SubProcess;

                DeleteActivity(endActivity);

                //remove connector in process overview
                DeleteProcessOverviewConnector(startSubProcess, endSubProcess);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (ModelingAdapterReferenceFormatException)
            {
                return;
            }
        }

        private static void UpdateStartActivityProperties(ToProcessConnector startActivity)
        {
            startActivity.ToProcessConnectorName = string.Empty;
            startActivity.ToProcessConnectorRef = null;
            startActivity.ExternalActivityRef = null;
        }

        private static void DeleteActivity(FromProcessConnector endActivity)
        {
            using (Transaction t = endActivity.Store.TransactionManager.BeginTransaction("Delete from activity"))
            {
                //delete the end activity
                endActivity.Delete();
                t.Commit();
            }
        }

        public static void DeleteProcessOverviewConnector(SubProcess startSubProcess, SubProcess endSubProcess) 
        {
            //get start sub process in process overview
            var processOverviewStartSubProcess = startSubProcess.SubProcessInProcessOverview();

            //get end sub process in process overview
            var processOverviewEndSubProcess = endSubProcess.SubProcessInProcessOverview();

            //Delete connector
            DeleteOverviewConnectorIfExistsBetween(processOverviewStartSubProcess, processOverviewEndSubProcess);
        }

        private static void DeleteOverviewConnectorIfExistsBetween(ProcessOverview.SubProcessElement processOverviewStartSubProcess, ProcessOverview.SubProcessElement processOverviewEndSubProcess)
        {
            //get connector in process overview
            var connectors = ProcessOverview.SubProcessElementReferencesTargets.GetLinks(processOverviewStartSubProcess, processOverviewEndSubProcess);

            DeleteFristSubProcessConnectorInProcessOverview(connectors);
        }

        private static void DeleteFristSubProcessConnectorInProcessOverview(System.Collections.ObjectModel.ReadOnlyCollection<ProcessOverview.SubProcessElementReferencesTargets> connectors)
        {
            if (connectors.Count > 0)
            {
                var connector = connectors.First();

                using (Transaction t = connector.Store.TransactionManager.BeginTransaction("Delete connectors in processoverview"))
                {
                    connector.SetLocks(Locks.None);
                    connector.Delete();
                    t.Commit();
                }
            }
        }

        public static ModelBusReference AddNewExternalActivityAndReturnReference(IModelBus modelBus, ToProcessConnector element, ModelBusReference newReference, Diagram targetDiagram, ref FromProcessConnector activity)
        {
            if (element.SubProcess.SubProcessName == string.Empty)
            {
                throw new Exception("Please Specify Sub-Process Name First!");
            }

            ModelBusReference retModelBusReference;

            using (Transaction t = targetDiagram.Store.TransactionManager.BeginTransaction("Create New Item"))
            {
                //Create new ExternalModelbusActivity
                activity = new FromProcessConnector(targetDiagram.Partition);

                activity.FromProcessConnectorRef = newReference;

                var fromProcessConnectorCount = (element.SubProcess.Activities.OfType<FromProcessConnector>().Count() + 1).ToString();

                activity.Name = "FromProcessConnector" + fromProcessConnectorCount;

                if ((element as Stop).SActivity.Count > 0)
                {
                    activity.FromProcessConnectorName = string.Format("{0}.{1}", element.SubProcess.SubProcessName, (element as Stop).SActivity[0].Name);
                }
                else
                {
                    activity.FromProcessConnectorName = string.Format("{0}.{1}", element.SubProcess.SubProcessName, (element as Stop).Name);
                }

                //Get reference to subprocessactivity element
                var fRef = GetReferenceToFile(element, modelBus);

                using (ModelBusAdapter adapter = modelBus.CreateAdapter(fRef))
                {
                    activity.FromProcessConnectorRef = adapter.GetElementReference(element);
                }

                //get reference for new activity
                using (ModelBusAdapter adapterNewFromRef = modelBus.CreateAdapter(newReference))
                {
                    retModelBusReference = adapterNewFromRef.GetElementReference(activity);
                    activity.SubProcess = ((Activity)adapterNewFromRef.ResolveElementReference(newReference)).SubProcess;
                }

                //create shape for from process
                var shape = CreateFromActivityShape(targetDiagram, activity);

                //add to diagram
                AddFromActivityShapeToDiagram(targetDiagram, shape);

                t.Commit();
            }

            return retModelBusReference;
        }

        private static void AddFromActivityShapeToDiagram(Diagram targetDiagram, FromProcessConnectorShape shape)
        {
            shape.AbsoluteBounds = new Microsoft.VisualStudio.Modeling.Diagrams.RectangleD(new PointD(2, 2), new SizeD(0.71125, 0.5));
            targetDiagram.NestedChildShapes.Add(shape);
        }

        private static FromProcessConnectorShape CreateFromActivityShape(Diagram targetDiagram, FromProcessConnector activity)
        {
            var shape = new FromProcessConnectorShape(targetDiagram.Partition);
            shape.ModelElement = activity;
            return shape;
        }

        public static void CreateFlowBetweenExternalAndActivity(FromProcessConnector externalActivity, Activity selectedActivity, Diagram diagram) 
        {
            using (Transaction t = externalActivity.Store.TransactionManager.BeginTransaction("Create flow"))
            {
                FlowMinimal flow = new FlowMinimal(externalActivity, selectedActivity);
                FlowMinimalConnector connector = new FlowMinimalConnector(diagram.Partition);
                connector.Associate(flow);

                diagram.NestedChildShapes.Add(connector);
                t.Commit();
            }
        }

        public static void AddRefActivity(ModelBusReference reference, ToProcessConnector element)
        {
            IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;

            using (ModelBusAdapter adapterNewRef = modelBus.CreateAdapter(reference))
            {
                if (adapterNewRef != null)
                {
                    ModelBusView view = adapterNewRef.GetDefaultView();
                    Diagram targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;
                    FromProcessConnector externalActivity = null;
                    ModelBusReference externalActivityReference =  AddNewExternalActivityAndReturnReference(modelBus, element, reference, targetDiagram, ref externalActivity);

                    //delete any old external activity linked to this subprocessactivity
                    DeleteReferencedActivityAndProcessOverviewConnector(element);

                    //set to new external activity
                    element.ExternalActivityRef = externalActivityReference;

                    var newActivity = (Activity)adapterNewRef.ResolveElementReference(reference);

                    //TODO: for the new to & from activities guids
                    var nGuid = new Guid(newActivity.VisioId);

                    element.ToActivityGuid = nGuid;

                    element.ToProcessConnectorName = string.Format("{0}.{1}", newActivity.SubProcess.SubProcessName, newActivity.Name);

                    CreateFlowBetweenExternalAndActivity(externalActivity, newActivity, targetDiagram);
                }
            }
        }

        private static void AddProcessConnector(ToProcessConnector element, ModelBusReference oldValue, ModelBusReference newValue)
        {
            if (newValue == null)
                return;

            var endActivity = element.ToExternalFromProcessConnector();

            //get end activity subprocess
            var endSubProcess = endActivity.SubProcess;

            //get start sub process
            var startSubProcess = element.SubProcess;
            //TODO: look into removing it
            Diagram processDiagram;

           IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;

            using (ModelBusAdapter adapt = modelBus.CreateAdapter(newValue))
            {
                ModelBusView processView = adapt.GetDefaultView();
                processDiagram = ((StandardVsModelingDiagramView)processView).Diagram;
            }

            using (Transaction t = startSubProcess.SubProcessInProcessOverview().Store.TransactionManager.BeginTransaction("Add Process Connector"))
            {
                ProcessOverview.SubProcessElementReferencesTargetsBuilder.Connect(startSubProcess.SubProcessInProcessOverview(), endSubProcess.SubProcessInProcessOverview());
                t.Commit();
            }
        }

        private static ModelBusReference GetReferenceToFile(Activity element, IModelBus modelBus)
        {
            ModelBusReference fromProcessActivitRef = null;

            //Get current element reference
            string fileName = Utilities.GetFileNameForStore(element.Store);

            if (fileName == "")
                return null;

            ModelBusAdapterManager manager = modelBus.FindAdapterManagers(fileName).First();
            ModelBusReference reference = manager.CreateReference(fileName);

            using (ModelBusAdapter adapter = modelBus.CreateAdapter(reference))
            {
                fromProcessActivitRef = adapter.GetElementReference(element);
            }

            return fromProcessActivitRef;
        }

        internal sealed partial class ToProcessConnectorRefPropertyHandler
        {
            protected override void OnValueChanging(ToProcessConnector element, ModelBusReference oldValue, ModelBusReference newValue)
            {
                base.OnValueChanging(element, oldValue, newValue);

                if (element.Store.InSerializationTransaction)
                    return;

                if (element.Store.TransactionManager.CurrentTransaction.Name == "Update Sub Process Reference")
                    return;

                if (oldValue != newValue)
                {
                    if (newValue != null)
                    {
                        AddRefActivity(newValue, element);
                        AddProcessConnector(element, oldValue, newValue);
                    }
                }
            }
        }
    }
}
