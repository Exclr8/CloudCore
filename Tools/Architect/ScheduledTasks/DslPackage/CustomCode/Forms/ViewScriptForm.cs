using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architect.ScheduledTasks.CustomCode.Forms
{
    public partial class ViewScriptForm : Form
    {
        private string _script = string.Empty;
        public ViewScriptForm()
        {
            InitializeComponent();
        }

        public ViewScriptForm(string script)
        {
            _script = script;
            InitializeComponent();
        }

        private void ViewScriptForm_Load(object sender, EventArgs e)
        {
            txtScriptText.Text = _script;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtScriptText.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
