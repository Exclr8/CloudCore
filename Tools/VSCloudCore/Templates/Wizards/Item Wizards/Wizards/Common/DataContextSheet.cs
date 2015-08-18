using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using CloudCore.VSExtension.Classes.Helpers;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class DataContextSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {

        private DBTemplateData _dbTemplateData;
        private DBContextReferenceList _contextReferenceList;

        public DataContextSheet(DBTemplateData templateData) : base()
        {
            this._dbTemplateData = templateData;
            InitializeComponent();

        }

        public override void OnSetActive(CancelEventArgs e)
        {
            DataContextListbox.Items.Clear();
            _contextReferenceList = DataContextHelper.GetAllDBContexts();
            foreach (DBContextReference item in _contextReferenceList)
            {
                DataContextListbox.Items.Add(string.Format("{0} [{1}]", item.DBContextClass.Name, item.AssemblyReference.FullName));
            }
            DataContextListbox.SelectedIndex = _contextReferenceList.IndexOf(_dbTemplateData.ContextReference);

            txtConnectionString.Text = _dbTemplateData.ConnectionString;
            SetWizardButtons(WizardButtons.Next);
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            _dbTemplateData.SetContextReference(_contextReferenceList[DataContextListbox.SelectedIndex]);
            _dbTemplateData.ConnectionString = txtConnectionString.Text;
            base.OnWizardNext(e);
        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (DataContextHelper.ConnectionTest(_contextReferenceList[ DataContextListbox.SelectedIndex ], txtConnectionString.Text))
                {
                    MessageBox.Show("Successful connection.");
                }
                else
                {
                    MessageBox.Show("Connection failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataContextListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dbTemplateData.SetContextReference(_contextReferenceList[DataContextListbox.SelectedIndex]);
            txtConnectionString.Text = _dbTemplateData.ConnectionString;
        }

    }
}
