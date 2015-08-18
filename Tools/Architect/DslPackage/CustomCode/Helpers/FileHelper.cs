using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Modeling.Integration;
using Architect.ModelBusAdapters;
using System.IO;

namespace Architect.CustomCode.Helpers
{
    public class SubProcessFileHelper
    {
        public static SubProcess CreateNewSubProcess(string subProcessName, ProjectItem subProcessItem, ModelBusReference processReference)
        {
            var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));
            var partition = new Partition(store);
            var result = new SerializationResult();

            using (Transaction t = store.TransactionManager.BeginTransaction("create new model"))
            {
                try
                {
                    var subProcessDSLSerializationHelper = CloudCoreArchitectSubProcessSerializationHelper.Instance;
                    SubProcess subProcess = subProcessDSLSerializationHelper.CreateModelHelper(partition);

                    SetSubProcessSettings(subProcessName, subProcess, processReference);

                    CreateAndSaveSubProcessFile(partition, result, subProcessItem.FileNames[0], subProcessDSLSerializationHelper, subProcess);

                    ModelBusReference subProcessReference = GetSubProcessOverviewFileModelBusReference(subProcessItem.FileNames[0]);

                    ProcessOverview.ProcessOverviewDiagram diagram = ProcessOverview.CustomCode.Helpers.ProcessFileHelper.GetProcessOverviewDiagram(processReference);
                    ProcessOverview.Process process = diagram.ModelElement as ProcessOverview.Process;
                    Architect.ProcessOverview.SubProcessElement subProcessElement = null;

                    using (Transaction tB = diagram.Store.TransactionManager.BeginTransaction("create subprocess element"))
                    {
                        subProcessElement = ProcessOverview.CustomCode.Helpers.ProcessFileHelper.CreateSubProcessElement(subProcessName, process.Partition, process, subProcess, subProcessReference);
                        tB.Commit();
                    }

                    t.Commit();

                    ProcessOverview.CustomCode.Helpers.ProcessFileHelper.SetAddedSubProcessReference(subProcessReference, subProcessItem.Name, processReference, subProcessElement);

                    return subProcess;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return null;
            }

        }

        public static ModelBusReference GetSubProcessOverviewFileModelBusReference(string subProcessFile)
        {
            IModelBus modelBus = Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SModelBus)) as IModelBus;
            CloudCoreArchitectSubProcessAdapterManager manager = modelBus.GetAdapterManager(CloudCoreArchitectSubProcessAdapter.AdapterId) as CloudCoreArchitectSubProcessAdapterManager;
            var modelReference = manager.CreateReference(subProcessFile);
            return modelReference;
        }

        private static void CreateAndSaveSubProcessFile(Partition partition, SerializationResult result, string subProcessFile, CloudCoreArchitectSubProcessSerializationHelper subProcessDSLSerializationHelper, SubProcess subProcess)
        {
            var bDiagram = subProcessDSLSerializationHelper.CreateDiagramHelper(partition, subProcess);

            subProcessDSLSerializationHelper.SaveModelAndDiagram(result, subProcess, subProcessFile, bDiagram, subProcessFile + ".diagram", Encoding.UTF8, false);
        }

        private static void SetSubProcessSettings(string subProcessName, SubProcess subProcess, ModelBusReference processReference)
        {
            subProcess.ProcessRef = processReference;
            subProcess.SubProcessName = subProcessName;
            subProcess.VisioId = subProcess.Id.ToString().ToLower();
        }

    }
}
