using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;

namespace Architect.CustomCode.Helpers
{
    public class ImportHelper
    {
        public static SubProcess ProcessExists(string processGuid, string processFolder)
        {
            var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));

            if (Directory.Exists(processFolder))
            {
                foreach (string file in Directory.GetFiles(processFolder).Where(f => f.IndexOf(".subprocess") > -1).Select(f => f))
                {
                    StreamReader streamReader = File.OpenText(file);
                    var str = streamReader.ReadToEnd();
                    streamReader.Close();
                    
                    if (str.IndexOf(string.Format(@"visioId=""{0}""", processGuid)) > -1)
                    {
                        using (Transaction transaction = store.TransactionManager.BeginTransaction("load model and diagram"))
                        {
                            SubProcess btProcess = CloudCoreArchitectSubProcessSerializationHelper.Instance.LoadModelAndDiagram(store, file, file + ".diagram", null, null, null);                           

                            transaction.Commit();

                            return btProcess;
                        }                        
                    }
                }
            }
            return null;
        }

        public static SubProcessDiagram GetSubProcessDiagram(SubProcess btProcess)
        {
            return btProcess.Store.ElementDirectory.AllElements.OfType<SubProcessDiagram>().FirstOrDefault();
        }        

        public static bool MovePageCodeToBackup(string id, string file, string name, string backupFolder, _DTE dte)
        {
            string csfileName = string.Format("{0}.cs", file);
            string designerfileName = string.Format("{0}.designer.cs", file);
            string aspxfileNameBackup = string.Format(@"{0}BTPage_{1}_{2}.aspx", backupFolder, id.Replace("-", "_"), name);
            string csfileNameBackup = string.Format("{0}.cs", aspxfileNameBackup);
            string designerfileNameBackup = string.Format("{0}.designer.cs", aspxfileNameBackup);

            if (File.Exists(file))
            {
                if (File.Exists(aspxfileNameBackup))
                    File.Delete(aspxfileNameBackup);

                if (File.Exists(csfileNameBackup))
                    File.Delete(csfileNameBackup);

                if (File.Exists(designerfileNameBackup))
                    File.Delete(designerfileNameBackup);

                dte.Solution.FindProjectItem(file).Remove();

                File.Move(file, aspxfileNameBackup);
                File.Move(csfileName, csfileNameBackup);
                File.Move(designerfileName, designerfileNameBackup);

                return true;
            }

            return false;
        }

        public static void MoveCodeToBackup(string id, string file, string name, string backupFolder, _DTE dte)
        {

            string ruleFileNameBackup = string.Format(@"{0}BTRule_{1}_{2}.sql", backupFolder, id.Replace("-", "_"), name);

            if (File.Exists(ruleFileNameBackup))
                File.Delete(ruleFileNameBackup);

            File.Move(file, ruleFileNameBackup);

            dte.Solution.FindProjectItem(file).Remove();
        }

        //public static void AddAssembly(_DTE _dte, Project project, SubProcess process, List<StartPage> startPages)
        //{
        //    if (_dte == null) return;

        //    var pi = project.ProjectItems.Item("Properties").ProjectItems.Item("AssemblyInfo.cs");

        //    foreach (var startPage in startPages)
        //    {
        //        var fileNameSpace = string.Format("{0}.Processes.BTProcess_{1}.Pages.BTPage_{2}.aspx", project.Properties.Item("DefaultNamespace").Value, process.VisioId.ToString().Replace("-", "_"), startPage.VisioId.ToString().Replace("-", "_"));
        //        var assembly = string.Format(@"""{0}"", ""{1}"", ""{2}"", ""{3}"", ""{4}"", ""{5}""", fileNameSpace, startPage.Name, "Page", "Create", startPage.VisioId.ToString(), process.VisioId.ToString());

        //        var elements = pi.FileCodeModel.CodeElements;
        //        for (var index = 1; index <= elements.Count; index++)
        //        {
        //            var elemnt = elements.Item(index);

        //            if (elemnt.Kind != vsCMElement.vsCMElementAttribute) continue;
        //            if (elemnt.Name != "BTEmbeddedProcessUrl") continue;

        //            var u = (CodeAttribute)elemnt;
        //            if (u.Value == assembly)
        //            {
        //                u.Delete();
        //            }
        //        }

        //        pi.FileCodeModel.AddAttribute("BTEmbeddedProcessUrl", assembly);
        //    }
        //}
    }

}


