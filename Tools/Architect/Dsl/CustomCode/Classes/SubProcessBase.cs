using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    public partial class SubProcessBase
    {
        public dynamic SubProcessInProcessOverview()
        {
            if (this.ProcessOverviewSubProcessRef == null)
                return null;

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;

            using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(this.ProcessOverviewSubProcessRef))
            {
                if (adapterExternalRef == null)
                    return null;

                var subProcess = adapterExternalRef.ResolveElementReference(this.ProcessOverviewSubProcessRef) as ProcessOverview.SubProcessElement;

                return subProcess;
            }

        }

        public static void AddSubProcessToOverView(SubProcessBase element, ModelBusReference oldValue, ModelBusReference newValue)
        {
            string fileName = Utilities.GetFileNameForStore(element.Store);

            if (fileName == "")
                return;

            //get modelbus, adapters and create reference based on from activity in sub-process diagram
            IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusAdapterManager manager = modelBus.FindAdapterManagers(fileName).First();

            //reference to Sub-Process Diagram
            ModelBusReference referenceToSubProcessDiagram = manager.CreateReference(fileName);

            //reference to Activity initiating the
            ModelBusReference fromSubProcessActivityRef;

            using (ModelBusAdapter adapter = modelBus.CreateAdapter(referenceToSubProcessDiagram))
                fromSubProcessActivityRef = adapter.GetElementReference(element);

            ProcessOverview.Process targetOverviewProc = null;
            ProcessOverview.SubProcessElement targetOverviewSubProc = null;
            ProcessOverview.Process oldOverviewProc = null;
            //ProcessOverview.SubProcess oldSubProc = null;

            if (oldValue != null)
            {
                using (ModelBusAdapter adapterRef = modelBus.CreateAdapter(oldValue))
                {
                    if (adapterRef != null)
                    {
                        ModelBusView viewOld = adapterRef.GetDefaultView();
                        Diagram targetOldDiagram = ((StandardVsModelingDiagramView)viewOld).Diagram;

                        //Delete old Subprocess Shape & element
                        if (targetOldDiagram.ModelElement != null)
                        {
                            oldOverviewProc = (ProcessOverview.Process)targetOldDiagram.ModelElement;

                            if (element.ProcessOverviewSubProcessRef != null)
                            {
                                //oldSubProc = (ProcessOverview.SubProcess)adapterRef.ResolveElementReference(element.SubProcessRef);

                                using (Transaction t = targetOldDiagram.Store.TransactionManager.BeginTransaction("Delete Old Item"))
                                {
                                    //if (oldSubProc != null)
                                    //{
                                    IEnumerable<ProcessOverview.SubProcessShape> subProcShapes = targetOldDiagram.NestedChildShapes.Where(s => s is ProcessOverview.SubProcessShape
                                                                                    && ((ProcessOverview.SubProcessElement)s.ModelElement).VisioId == element.VisioId).Cast<ProcessOverview.SubProcessShape>();

                                    for (int x = 0; x < subProcShapes.Count(); x++)
                                    {
                                        if (newValue == null || newValue != oldValue)
                                        {
                                            subProcShapes.ElementAt(x).Delete();
                                        }
                                        else
                                        {
                                            //targetSubProc = oldSubProc;
                                            targetOverviewProc = oldOverviewProc;
                                        }
                                    }

                                    t.Commit();
                                    //}
                                }

                                using (Transaction t = element.Store.TransactionManager.BeginTransaction("Init Items"))
                                {
                                    element.ProcessOverviewSubProcessRef = null;
                                    element.ProcessRef = null;

                                    t.Commit();
                                }
                            }
                        }
                    }
                }
            }

            if (newValue != null)
            {
                using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(newValue))
                {
                    if (adapterExternalRef != null)
                    {
                        ModelBusView view = adapterExternalRef.GetDefaultView();
                        Diagram targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;

                        //Get Process overview diagram based on target diagram
                        targetOverviewProc = (ProcessOverview.Process)targetDiagram.ModelElement;

                        using (Transaction t = targetDiagram.Store.TransactionManager.BeginTransaction("Create New Item"))
                        {
                            if (newValue != null && newValue != oldValue)
                            {
                                //Instantiate Process Overview Sub-Process Model based on sub-process diagram file details
                                targetOverviewSubProc = new ProcessOverview.SubProcessElement(targetDiagram.Partition)
                                {
                                    SubProcessRef = fromSubProcessActivityRef,
                                    Name = element.SubProcessName,
                                    VisioId = string.IsNullOrEmpty(element.VisioId) ? element.Id.ToString() : element.VisioId
                                };

                                //set the visioid of the targetOverviewSubProc to it's id
                                //targetOverviewSubProc.VisioId = targetOverviewSubProc.Id.ToString();

                                ModelBusAdapter adapterForSubProcessDiagram = modelBus.CreateAdapter(referenceToSubProcessDiagram);

                                //TODO: check this
                                //checking whether the  sub-process activity already exists in the process overview
                                //if (targetOverviewProc.BTSubProcess.Where(p => p.SubProcessRef == adapterForSubProcessDiagram.GetElementReference(element)).Count() > 0)
                                //need to figure out what must happen
                                //right now assuming that if a shape and model exists, do nothing

                                if (targetOverviewProc.BTSubProcess.Where(p => p.SubProcessRef == adapterForSubProcessDiagram.GetElementReference(element)).Count() == 0)
                                {
                                    //add sub process instantiation to sub process collection in process overview
                                    targetOverviewProc.BTSubProcess.Add(targetOverviewSubProc);

                                    //create shape to add to process overview diagram
                                    var shape = new ProcessOverview.SubProcessShape(targetDiagram.Partition);
                                    //link sub-process model instantiation to the shape
                                    shape.ModelElement = targetOverviewSubProc;

                                    //Todo: Get location of linked activity and do placement
                                    shape.AbsoluteBounds = new Microsoft.VisualStudio.Modeling.Diagrams.RectangleD(new PointD(2, 2), new SizeD(2, 0.75));

                                    //Add shape to the process overview diagram
                                    if (targetDiagram.NestedChildShapes.Where(s => s == shape).Count() == 0)
                                        targetDiagram.NestedChildShapes.Add(shape);
                                }
                            }
                            else
                            {
                                targetOverviewSubProc.Name = element.SubProcessName;
                                targetOverviewSubProc.VisioId = string.IsNullOrEmpty(element.VisioId) ? element.Id.ToString() : element.VisioId;
                            }

                            t.Commit();
                        }

                        using (Transaction t = element.Store.TransactionManager.BeginTransaction("Update Sub Process Reference"))
                        {
                            element.ProcessOverviewSubProcessRef = adapterExternalRef.GetElementReference(targetOverviewSubProc);
                            element.ProcessRef = newValue;

                            t.Commit();
                        }
                    }
                }
            }
        }

        public static void AddReferencedSubProcesses(SubProcessBase element, ModelBusReference newValue)
        {
            string fileName = Utilities.GetFileNameForStore(element.Store);

            if (fileName == "")
                return;

            ProcessOverview.Process targetProc = null;
            ProcessOverview.SubProcessElement targetSubProc = null;
            ModelBusReference fromSubProcessActRef = null;
            SubProcess fromSubProcess = null;
            ModelBusReference mbr = null;

            IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusAdapterManager manager = modelBus.FindAdapterManagers(fileName).First();
            ModelBusReference reference = manager.CreateReference(fileName);

            List<Activity> subProcActs = new List<Activity>();

            //Get List of sub process activities in this diagram that reference another sub process
            subProcActs.AddRange(element.Activities.Where(a => a is ToProcessConnector || a is FromProcessConnector));

            foreach (var item in subProcActs)
            {
                if (item is ToProcessConnector)
                    mbr = ((ToProcessConnector)item).ToProcessConnectorRef;
                else
                    mbr = ((FromProcessConnector)item).FromProcessConnectorRef;

                using (ModelBusAdapter adapter = modelBus.CreateAdapter(mbr))
                {
                    ModelBusView view = adapter.GetDefaultView();
                    Diagram targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;

                    fromSubProcess = (SubProcess)targetDiagram.ModelElement;
                    fromSubProcessActRef = adapter.GetElementReference(fromSubProcess);
                }

                using (Transaction tt = fromSubProcess.Store.TransactionManager.BeginTransaction("Update Linked Sub Process Reference"))
                {
                    string fileNameItem = Utilities.GetFileNameForStore(item.Store);
                    IModelBus modelBusItem = item.Store.GetService(typeof(SModelBus)) as IModelBus;
                    ModelBusAdapterManager managerItem = modelBusItem.FindAdapterManagers(fileNameItem).First();
                    ModelBusReference referenceItem = managerItem.CreateReference(fileNameItem);

                    using (ModelBusAdapter adapterItem = modelBus.CreateAdapter(referenceItem))
                    {
                        ModelBusReference oldProcRef = fromSubProcess.ProcessRef;

                        if (oldProcRef != null)
                        {
                            using (ModelBusAdapter oldItemAdapter = modelBus.CreateAdapter(oldProcRef))
                            {
                                ModelBusView oldView = oldItemAdapter.GetDefaultView();
                                Diagram oldDiagram = ((StandardVsModelingDiagramView)oldView).Diagram;

                                if (oldDiagram.ModelElement != null)
                                {
                                    using (Transaction ttt = oldDiagram.Store.TransactionManager.BeginTransaction("Delete Old Item"))
                                    {
                                        ProcessOverview.Process oldProc = (ProcessOverview.Process)oldDiagram.ModelElement;

                                        //Delete old items in old diagram
                                        IEnumerable<ProcessOverview.SubProcessElement> listOldSubProc = oldProc.BTSubProcess.Where(s => s.VisioId == fromSubProcess.VisioId || s.VisioId == item.VisioId);

                                        for (int x = 0; x < listOldSubProc.Count(); x++)
                                        {
                                            listOldSubProc.ElementAt(x).Delete();
                                        }

                                        ttt.Commit();
                                    }
                                }
                            }
                        }

                        fromSubProcess.ProcessOverviewSubProcessRef = adapterItem.GetElementReference(item.SubProcess);
                        fromSubProcess.ProcessRef = item.SubProcess.ProcessRef;
                    }

                    tt.Commit();
                }

                if (newValue != null)
                {
                    Diagram targetDiagram;

                    using (ModelBusAdapter targetAdapter = modelBus.CreateAdapter(newValue))
                    {
                        ModelBusView view = targetAdapter.GetDefaultView();
                        targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;
                    }

                    targetProc = (ProcessOverview.Process)targetDiagram.ModelElement;

                    using (Transaction t = targetDiagram.Store.TransactionManager.BeginTransaction("Create New Item"))
                    {
                        using (ModelBusAdapter adapter2 = modelBus.CreateAdapter(reference))
                        {
                            //Delete old items in new diagram if exist
                            IEnumerable<ProcessOverview.SubProcessElement> listTargetSubProc = targetProc.BTSubProcess.Where(s => s.VisioId == fromSubProcess.VisioId);

                            for (int x = 0; x < listTargetSubProc.Count(); x++)
                            {
                                listTargetSubProc.ElementAt(x).Delete();
                            }

                            targetSubProc = new ProcessOverview.SubProcessElement(targetDiagram.Partition)
                            {
                                SubProcessRef = fromSubProcessActRef,
                                Name = fromSubProcess.SubProcessName,
                                VisioId = fromSubProcess.VisioId
                            };

                            if (targetProc.BTSubProcess.Where(s => s.VisioId == targetProc.VisioId).Count() == 0)
                            {
                                targetProc.BTSubProcess.Add(targetSubProc);

                                var shape = new ProcessOverview.SubProcessShape(targetDiagram.Partition);
                                shape.ModelElement = targetSubProc;

                                //Todo: Get location of linked activity and do placement
                                shape.AbsoluteBounds = new Microsoft.VisualStudio.Modeling.Diagrams.RectangleD(new PointD(2, 2), new SizeD(2, 0.75));
                                targetDiagram.NestedChildShapes.Add(shape);
                            }
                        }

                        t.Commit();
                    }
                }
            }
        }

        public static void AddConnectors(SubProcessBase element, ModelBusReference newValue)
        {
            string fileName = Utilities.GetFileNameForStore(element.Store);

            if (fileName == "")
                return;

            if (newValue == null)
                return;

            ProcessOverview.Process targetProc = null;

            IModelBus modelBus = element.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusAdapterManager manager = modelBus.FindAdapterManagers(fileName).First();
            ModelBusReference reference = manager.CreateReference(fileName);

            List<ProcessOverview.SubProcessElement> subProcList = new List<ProcessOverview.SubProcessElement>();

            Diagram targetDiagram;

            using (ModelBusAdapter targetAdapter = modelBus.CreateAdapter(newValue))
            {
                ModelBusView view = targetAdapter.GetDefaultView();
                targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;
            }

            targetProc = (ProcessOverview.Process)targetDiagram.ModelElement;
            subProcList.AddRange(targetProc.BTSubProcess);

            foreach (var item in subProcList)
            {
                using (ModelBusAdapter adapter = modelBus.CreateAdapter(item.SubProcessRef))
                {
                    SubProcessBase subProcessBase = (SubProcessBase)adapter.ResolveElementReference(item.SubProcessRef);

                    List<Activity> toSubProcActs = new List<Activity>();

                    toSubProcActs.AddRange(subProcessBase.Activities.Where(a => a is ToProcessConnector));

                    foreach (var toProcAct in toSubProcActs)
                    {
                        try
                        {
                            using (Transaction t = item.Store.TransactionManager.BeginTransaction("Add Connector"))
                            {
                                List<ProcessOverview.SubProcessElement> toSub = new List<ProcessOverview.SubProcessElement>();

                                ModelBusReference mbr = ((ToProcessConnector)toProcAct).ExternalActivityRef;

                                if (mbr == null)
                                    continue;

                                using (ModelBusAdapter mba = modelBus.CreateAdapter(mbr))
                                {
                                    FromProcessConnector fpa = (FromProcessConnector)mba.ResolveElementReference(mbr);

                                    ModelBusReference subProcessRef = mba.GetElementReference(fpa.SubProcess);

                                    IEnumerable<ProcessOverview.SubProcessElement> toSubProcess = subProcList.Where(p => p.SubProcessRef == subProcessRef);

                                    foreach (var i in toSubProcess)
                                    {
                                        ProcessOverview.SubProcessElementReferencesTargets refTargets = new ProcessOverview.SubProcessElementReferencesTargets(item, i);
                                        ProcessOverview.SubProcessConnector connector = new ProcessOverview.SubProcessConnector(targetDiagram.Partition);

                                        connector.Associate(refTargets);

                                        if (targetDiagram.NestedChildShapes.Where(s => s == connector).Count() == 0)
                                            targetDiagram.NestedChildShapes.Add(connector);
                                    }
                                }

                                t.Commit();
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public static void AddLinkedSubProcess(IModelBus modelBus, SubProcessBase subProcess, ModelBusReference toReference)
        {
            List<Activity> subProcessActList = new List<Activity>();
            subProcessActList.AddRange(subProcess.Activities.Where(a => a is ToProcessConnector));
            subProcessActList.AddRange(subProcess.Activities.Where(a => a is FromProcessConnector));

            foreach (var item in subProcessActList)
            {
                ModelBusAdapter adapter;

                if (item is ToProcessConnector)
                {
                    adapter = modelBus.CreateAdapter(((ToProcessConnector)item).ToProcessConnectorRef);
                    var toSubProcessActivity = (FromProcessConnector)adapter.ResolveElementReference(((ToProcessConnector)item).ExternalActivityRef);

                    ModelBusReference toSubProcessRef = adapter.GetElementReference(toSubProcessActivity.SubProcess);

                    if (toSubProcessActivity.SubProcess.ProcessRef != null)
                        DeleteRefSubProcess(toSubProcessActivity.SubProcess, modelBus);

                    string fileName = Utilities.GetFileNameForStore(item.Store);

                    if (fileName == "")
                        return;

                    IModelBus modelBusSubProcess = item.Store.GetService(typeof(SModelBus)) as IModelBus;
                    ModelBusAdapterManager manager = modelBusSubProcess.FindAdapterManagers(fileName).First();
                    ModelBusReference reference = manager.CreateReference(fileName);
                    ModelBusAdapter adapterSubProcess = modelBus.CreateAdapter(reference);

                    //AddRefSubProcess(modelBus, toReference, adapter.GetElementReference(toSubProcessActivity.SubProcess), toSubProcessActivity.SubProcess);
                    AddLinkedSubProcess(modelBus, toSubProcessActivity.SubProcess, toReference);
                }
                else
                {
                    adapter = modelBus.CreateAdapter(((FromProcessConnector)item).FromProcessConnectorRef);
                    var fromSubProcessActivity = (ToProcessConnector)adapter.ResolveElementReference(((FromProcessConnector)item).FromProcessConnectorRef);

                    ModelBusReference fromSubProcessRef = adapter.GetElementReference(fromSubProcessActivity.SubProcess);

                    if (fromSubProcessActivity.SubProcess.ProcessRef != null)
                        DeleteRefSubProcess(fromSubProcessActivity.SubProcess, modelBus);

                    string fileName = Utilities.GetFileNameForStore(item.Store);

                    if (fileName == "")
                        return;

                    IModelBus modelBusSubProcess = item.Store.GetService(typeof(SModelBus)) as IModelBus;
                    ModelBusAdapterManager manager = modelBusSubProcess.FindAdapterManagers(fileName).First();
                    ModelBusReference reference = manager.CreateReference(fileName);
                    ModelBusAdapter adapterSubProcess = modelBus.CreateAdapter(reference);

                    //AddRefSubProcess(modelBus, toReference, adapter.GetElementReference(fromSubProcessActivity.SubProcess), fromSubProcessActivity.SubProcess);
                    AddLinkedSubProcess(modelBus, fromSubProcessActivity.SubProcess, toReference);
                }
            }
        }

        public static ModelBusReference DeleteRefSubProcess(SubProcessBase element, IModelBus modelBus)
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

            if (element.ProcessOverviewSubProcessRef != null)
            {
                using (ModelBusAdapter adapterExternalRef = modelBus.CreateAdapter(element.ProcessOverviewSubProcessRef))
                {
                    if (adapterExternalRef != null)
                    {
                        ModelBusView view = adapterExternalRef.GetDefaultView();
                        view.SetSelection(element.ProcessOverviewSubProcessRef);

                        Diagram targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;

                        using (Transaction t = targetDiagram.Store.TransactionManager.BeginTransaction("Delete Old Item"))
                        {
                            //Delete old ExternalModelbusActivity
                            var targetAct = (ProcessOverview.SubProcessElement)adapterExternalRef.ResolveElementReference(element.ProcessOverviewSubProcessRef);

                            if (targetAct != null)
                            {
                                if (targetDiagram.FindShape(targetAct) != null)
                                {
                                    ((ProcessOverview.SubProcessShape)targetDiagram.FindShape(targetAct)).Delete();
                                }
                            }

                            t.Commit();
                        }
                    }
                }
            }

            return fromProcessActivitRef;
        }

        public static void AddSubProcessConnector(IModelBus modelBus, ModelBusReference processOverview)
        {
            ModelBusAdapter adapter = modelBus.CreateAdapter(processOverview);

            if (adapter != null)
            {
                ModelBusView view = adapter.GetDefaultView();

                Diagram targetDiagram = ((StandardVsModelingDiagramView)view).Diagram;

                var process = (ProcessOverview.Process)targetDiagram.ModelElement;

                foreach (var item in process.BTSubProcess)
                {
                    ModelBusReference fromSubProcRef = adapter.GetElementReference(item);
                    ModelBusAdapter toSubProcAdapter = modelBus.CreateAdapter(item.SubProcessRef);
                    var toSubProc = (SubProcess)toSubProcAdapter.ResolveElementReference(item.SubProcessRef);

                    List<Activity> subProcActs = new List<Activity>();
                    subProcActs.AddRange(toSubProc.Activities.Where(a => a is ToProcessConnector));

                    foreach (var act in subProcActs)
                    {
                        string fileName = Utilities.GetFileNameForStore(act.Store);

                        if (fileName == "")
                            return;

                        ModelBusReference mbr = ((ToProcessConnector)act).ToProcessConnectorRef;

                        IModelBus modelBusAct = act.Store.GetService(typeof(SModelBus)) as IModelBus;
                        ModelBusAdapterManager manager = modelBusAct.FindAdapterManagers(((ModelingAdapterReference)mbr.AdapterReference).AbsoluteTargetPath).First();
                        ModelBusReference reference = manager.CreateReference(((ModelingAdapterReference)mbr.AdapterReference).AbsoluteTargetPath);
                        ModelBusAdapter adapterAct = modelBus.CreateAdapter(reference);

                        var subProcAct = (Activity)adapterAct.ResolveElementReference(mbr);

                        ModelBusReference toSubProcRef = subProcAct.SubProcess.ProcessOverviewSubProcessRef;

                        //AddConnector(processOverview, fromSubProcRef, toSubProcRef);
                    }

                    subProcActs = new List<Activity>();
                    subProcActs.AddRange(toSubProc.Activities.Where(a => a is FromProcessConnector));

                    foreach (var act in subProcActs)
                    {
                        string fileName = Utilities.GetFileNameForStore(act.Store);

                        if (fileName == "")
                            return;

                        ModelBusReference mbr = ((FromProcessConnector)act).FromProcessConnectorRef;

                        IModelBus modelBusAct = act.Store.GetService(typeof(SModelBus)) as IModelBus;
                        ModelBusAdapterManager manager = modelBusAct.FindAdapterManagers(((ModelingAdapterReference)mbr.AdapterReference).AbsoluteTargetPath).First();
                        ModelBusReference reference = manager.CreateReference(((ModelingAdapterReference)mbr.AdapterReference).AbsoluteTargetPath);
                        ModelBusAdapter adapterAct = modelBus.CreateAdapter(reference);

                        var subProcAct = (Activity)adapterAct.ResolveElementReference(mbr);

                        ModelBusReference toSubProcRef = subProcAct.SubProcess.ProcessOverviewSubProcessRef;

                        //AddConnector(processOverview, toSubProcRef, fromSubProcRef);
                    }
                }
            }
        }

        private static void AddConnector(ModelBusReference processOverview, ProcessOverview.SubProcessElement fromSubProcess, ProcessOverview.SubProcessElement toSubProcess)
        {
            IModelBus modelbus = processOverview.ModelBus;
            ModelBusAdapter adapter = modelbus.CreateAdapter(processOverview);
            Diagram diagram = ((StandardVsModelingDiagramView)adapter.GetDefaultView()).Diagram;

            using (Transaction t = fromSubProcess.Store.TransactionManager.BeginTransaction("Add Connector"))
            {
                //Connector must be added when BTSubProcessActivity is added
                ProcessOverview.SubProcessElementReferencesTargets refTargets = new ProcessOverview.SubProcessElementReferencesTargets(fromSubProcess, toSubProcess);
                ProcessOverview.SubProcessConnector connector = new ProcessOverview.SubProcessConnector(diagram.Partition);

                connector.Associate(refTargets);
                diagram.NestedChildShapes.Add(connector);

                t.Commit();
            }
        }
    }
}
