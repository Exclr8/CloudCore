using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Architect.ProcessOverview.ModelBusAdapters;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;

namespace Architect.ProcessOverview.CustomCode.Helpers
{
    public class ProcessFileHelper
    {
        public static void CreateNewProcessOverview(string ProcessName, ProjectItem processFile, ProjectItem diagramFile)
        {
            var store = new Store(typeof(CloudCoreArchitectProcessOverviewDomainModel));
            var partition = new Partition(store);
            var result = new SerializationResult();

            using (Transaction t = store.TransactionManager.BeginTransaction("create new process overview model"))
            {
                try
                {
                    var processOverviewSerializationHelper = CloudCoreArchitectProcessOverviewSerializationHelper.Instance;
                    Architect.ProcessOverview.Process process = processOverviewSerializationHelper.CreateModelHelper(partition);

                    SetProcessOverviewProperties(ProcessName, process);

                    var diagram = processOverviewSerializationHelper.CreateDiagramHelper(partition, process);

                    processOverviewSerializationHelper.SaveModelAndDiagram(result, process, processFile.FileNames[0], diagram, diagramFile.FileNames[0]);

                    AddAssemblyReference(ProcessName, process);

                    t.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private static void AddAssemblyReference(string processName, Architect.ProcessOverview.Process process)
        {
            var dte = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(EnvDTE._DTE)) as EnvDTE._DTE;

            if (dte != null && dte.ActiveDocument != null)
            {
                var pr = dte.ActiveDocument.ProjectItem.ContainingProject;
                var pi = pr.ProjectItems.Item("Properties").ProjectItems.Item("AssemblyInfo.cs");

                var assembly = string.Format(@"""{0}"", ""{1}""", process.VisioId, processName);

                pi.FileCodeModel.AddAttribute("EmbeddedProcess", assembly);
            }
        }

        private static void SetProcessOverviewProperties(string processName, Architect.ProcessOverview.Process process)
        {
            process.ProcessName = processName;
            process.VisioId = process.Id.ToString().ToLower();
        }

        public static ProcessOverviewDiagram GetProcessOverviewDiagram(ModelBusReference processReference)
        {
            ProcessOverviewDiagram diagram = null;

            using (var adapter = processReference.ModelBus.CreateAdapter(processReference))
            {
                ModelBusView view = adapter.GetDefaultView();

                diagram = ((StandardVsModelingDiagramView)view).Diagram as ProcessOverviewDiagram;
            }

            return diagram;
        }

        public static ModelBusReference GetProcessOverviewFileModelBusReference(string processFile)
        {
            IModelBus modelBus = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SModelBus)) as IModelBus;
            CloudCoreArchitectProcessOverviewAdapterManager manager = modelBus.GetAdapterManager(CloudCoreArchitectProcessOverviewAdapter.AdapterId) as CloudCoreArchitectProcessOverviewAdapterManager;
            var modelReference = manager.CreateReference(processFile);

            return modelReference;
        }

        public static Process GetProcessOverviewModelByReference(ModelBusReference processReference)
        {
            Process process = null;

            using (var adapter = processReference.ModelBus.CreateAdapter(processReference))
            {
                process = adapter.ResolveElementReference(processReference) as Process;
            }

            return process;
        }

        public static void SetAddedSubProcessReference(ModelBusReference subProcessReference, string subProcessName, ModelBusReference processReference, SubProcessElement subProcessElement)
        {
            IModelBus parentModelBus = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SModelBus)) as IModelBus;
            ModelBusReference subProcessElementReference = null;

            using (CloudCoreArchitectProcessOverviewAdapter adapter = parentModelBus.CreateAdapter(processReference) as CloudCoreArchitectProcessOverviewAdapter)
            {
                subProcessElementReference = adapter.GetElementReference(subProcessElement);
            }

            IModelBus modelBus = subProcessReference.ModelBus;

            using (Architect.ModelBusAdapters.CloudCoreArchitectSubProcessAdapter adapter = modelBus.CreateAdapter(subProcessReference) as Architect.ModelBusAdapters.CloudCoreArchitectSubProcessAdapter)
            {
                var subProcess = ((adapter.GetDefaultView() as StandardVsModelingDiagramView).Diagram).ModelElement as SubProcess;

                using (Transaction t = subProcess.Store.TransactionManager.BeginTransaction("update subprocess reference to subprocess file"))
                {
                    subProcess.SetLocks(Locks.None);
                    subProcess.ProcessOverviewSubProcessRef = subProcessElementReference;
                    subProcess.SetLocks(Locks.Delete | Locks.Add | Locks.Move | Locks.Properties);

                    t.Commit();
                }
            }
        }

        public static SubProcessElement CreateSubProcessElement(string subProcessName, Partition partition, ProcessOverview.Process process, SubProcess subProcess, ModelBusReference subProcessReference)
        {
            var childReferenceProperty = new PropertyAssignment(SubProcessElement.SubProcessRefDomainPropertyId, null);
            var nameProperty = new PropertyAssignment(SubProcessElement.NameDomainPropertyId, subProcessName);
            var subProcessElement = new ProcessOverview.SubProcessElement(partition, nameProperty, childReferenceProperty);

            subProcessElement.VisioId = subProcess.VisioId.ToString().ToLower();
            subProcessElement.SubProcessRef = subProcessReference;
            process.BTSubProcess.Add(subProcessElement);

            return subProcessElement;
        }
    }
}
