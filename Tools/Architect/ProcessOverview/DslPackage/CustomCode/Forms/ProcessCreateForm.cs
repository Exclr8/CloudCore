using System;
using System.Windows.Forms;

namespace Architect.CustomCode.Forms
{
    public partial class ProcessCreateForm : Form
    {
        public ProcessCreateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtProcessName.Text == String.Empty)
            {
                MessageBox.Show("Please enter a 'Process' name.");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
