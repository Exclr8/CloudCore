using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architect.CustomCode.Forms
{
    public partial class SubProcessForm : Form
    {
        public SubProcessForm()
        {
            InitializeComponent();
        }

        private void btnFindProcess_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            txtProcess.Text = openFileDialog1.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSubProcessName.Text == String.Empty)
            {
                MessageBox.Show("Please enter a 'Sub-Process' name.");
                return;
            }

            if (txtProcess.Text == String.Empty)
            {
                MessageBox.Show("Please select a 'Process' name.");
                return;
            }

            if (!(File.Exists(txtProcess.Text)))
            {
                MessageBox.Show("Please select a valid 'Process' file.");
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
