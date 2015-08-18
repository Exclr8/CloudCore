using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Btomic;
using EnvDTE;
using EnvDTE80;
using Processes = Btomic.Processes;

namespace FrameworkOne.EditorExtentions.Classes
{
    class CallbackHandler
    {
        const string Extension = "btomic";
        private readonly DTE2 _applicationObject;

        public CallbackHandler(DTE2 applicationObject)
        {
            _applicationObject = applicationObject;
        }

        public void StartReverseEngineerWizard()
        {
            var connectionDialog = new Connection();
            connectionDialog.ShowDialog();

            if (connectionDialog.DialogResult != DialogResult.OK) return;

            //Check the version of the database
            var db = new BtomicDB();
            try
            {
                //if this table exists, it must be version 2, otherwise it must be version 1
                db.Model_BTProcessModel.Any();

                connectionDialog.DBVersion = "2";

            }
            catch (Exception)
            {
                connectionDialog.DBVersion = "1";
            }

            var processDialog = new Processes(connectionDialog.DBVersion);
            processDialog.ShowDialog();

            if (processDialog.DialogResult != DialogResult.OK) return;


            int? revisionID = null;

            if (connectionDialog.DBVersion != "1")
            {
                var revisionDialog = new Revision(processDialog.ProcessId);
                revisionDialog.ShowDialog();
                revisionID = revisionDialog.RevisionID;

                if (revisionDialog.DialogResult != DialogResult.OK) return;
            }

            var selectedItem = _applicationObject.SelectedItems.Item(1);
            var project = selectedItem.Project;

            var projectItem = selectedItem.ProjectItem;

            var diagramGenerator = new Diagram.DiagramGenerator(processDialog.ProcessId, revisionID, _applicationObject);

            if (project != null)
            {
                CreateInProject(project, Extension, diagramGenerator);
            }
            else if (projectItem != null)
            {
                CreateInFolder(projectItem, Extension, diagramGenerator);
            }
        }

        private static void CreateInFolder(ProjectItem projectItem, string extension, Diagram.DiagramGenerator generator)
        {


            var filepath = projectItem.FileNames[0];

            var itemPath = string.Format("{0}{1}.{2}", filepath, generator.GetName(), extension);

            if (File.Exists(itemPath))
                if (MessageBox.Show(@"A file with the name '" + generator.GetName() + @"." + Extension + @"' already exists. Do you want to replace it?", @"File Destination Exists", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            generator.GenerateDiagram(itemPath);

            var item = projectItem.ProjectItems.AddFromFile(itemPath);
            item.Properties.Item("CustomTool").Value = "BtomicFileCodeGenerator";
        }

        private static void CreateInProject(Project project, string extension, Diagram.DiagramGenerator generator)
        {

            var filepath = project.FullName.Substring(0, project.FullName.LastIndexOf("\\") + 1) + @"processes\";

            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);

            var itemPath = string.Format("{0}{1}.{2}", filepath, generator.GetName(), extension);

            if (File.Exists(itemPath))
                if (MessageBox.Show(@"A file with the name '" + generator.GetName() + @"." + Extension + @"' already exists. Do you want to replace it?", @"File Destination Exists", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            generator.GenerateDiagram(itemPath);
            var item = project.ProjectItems.AddFromFile(itemPath);
            item.Properties.Item("CustomTool").Value = "BtomicFileCodeGenerator";

        }
    }
}
