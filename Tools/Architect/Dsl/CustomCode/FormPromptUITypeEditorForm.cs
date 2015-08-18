using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Integration;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Architect.CustomCode
{
    public partial class FormPromptUITypeEditorForm : Form
    {
        private List<Activity> activities;

        public FormPromptUITypeEditorForm()
        {
            InitializeComponent();
        }

        public object Value { get; set; }

        public IModelBus ModelBus { get; set; }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String file = dialog.FileName;

                txtProcessFile.Text = file;

                var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));

                using (Transaction transaction = store.TransactionManager.BeginTransaction("load model and diagram"))
                {
                    SubProcess btProcess = CloudCoreArchitectSubProcessSerializationHelper.Instance.LoadModelAndDiagram(store, file, file + ".diagram", null, null, null);

                    activities = new List<Activity>();
                    activities = btProcess.Activities.Where(a => a is CloudcoreUser).ToList();

                    lstActivities.Clear();

                    foreach (var item in activities)
                    {
                        ListViewItem lvItem = new ListViewItem { Text = item.Name, Tag = item };
                        lstActivities.Items.Add(lvItem);
                    }

                    transaction.Commit();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var toActivity = (Activity)lstActivities.SelectedItems[0].Tag;
            _DTE _dte = (_DTE)Package.GetGlobalService(typeof(_DTE));
            Project project = _dte.ActiveDocument.ProjectItem.ContainingProject;

            string projectPath = project.FullName.Substring(0, project.FullName.LastIndexOf("\\") + 1);
            string folderPath = string.Format(@"{0}processes\", projectPath);
            string filePath = string.Format("{0}{1}.subprocess", folderPath, toActivity.SubProcess.SubProcessName.ToString().Replace("-", "_"));

            ModelBusAdapterManager manager = ModelBus.GetAdapterManager("Architect.CloudCoreArchitectSubProcess");
            //ModelBusAdapterManager manager = ModelBus.FindAdapterManagers(filePath).First();
            ModelBusReference reference = manager.CreateReference(filePath);

            using (ModelBusAdapter adapter = ModelBus.CreateAdapter(reference))
            {
                this.Value = adapter.GetElementReference(toActivity);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }
    }
}
