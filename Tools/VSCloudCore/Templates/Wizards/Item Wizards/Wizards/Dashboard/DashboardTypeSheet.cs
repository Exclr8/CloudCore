using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class DashboardTypeSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public DashboardTypeSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            cmbDashboardType.Items.Clear();
            cmbDashboardType.Items.Add(DashboardTypeEnum.BarChart);
            cmbDashboardType.Items.Add(DashboardTypeEnum.ColumnChart);
            cmbDashboardType.Items.Add(DashboardTypeEnum.LineChart);
            cmbDashboardType.Items.Add(DashboardTypeEnum.PieChart);

            SetWizardButtons(WizardButtons.Finish);
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            T4DashboardWizard.TemplateData.DashboardTitle = txtTitle.Text;
            T4DashboardWizard.TemplateData.DashboardSubTitle = txtSubTitle.Text;
            T4DashboardWizard.TemplateData.Type = (DashboardTypeEnum)cmbDashboardType.SelectedItem;

            if (T4DashboardWizard.TemplateData.ContextName == string.Empty)
            T4DashboardWizard.TemplateData.ContextName = txtTitle.Text.Replace(" ", "");
            base.OnWizardFinish(e);
        }

    }
}
