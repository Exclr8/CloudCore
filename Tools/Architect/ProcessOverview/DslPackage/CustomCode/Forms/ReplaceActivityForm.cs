using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architect.ProcessOverview.CustomCode.Forms
{
    public partial class ReplaceActivityForm : Form
    {
        private List<KeyValuePair<string, Guid>> _ReplaceActivityList = new List<KeyValuePair<string, Guid>>();
        private List<KeyValuePair<string, Guid>> _newActivities = new List<KeyValuePair<string, Guid>>();
        public List<KeyValuePair<Guid, Guid>> FinalMatchList = new List<KeyValuePair<Guid, Guid>>();

        public ReplaceActivityForm()
        {
            InitializeComponent();
        }

        public ReplaceActivityForm(List<KeyValuePair<string, Guid>> ReplaceActivityList, List<KeyValuePair<string, Guid>> newActivities)
        {
            _ReplaceActivityList.AddRange(ReplaceActivityList);
            _newActivities.AddRange(newActivities);

            InitializeComponent();
        }

        private void ReplaceActivityForm_Load(object sender, EventArgs e)
        {
            int yValue = 10, counter = 0;

            foreach (var item in _ReplaceActivityList)
            {
                counter++;

                Panel p = CreateNewPanel(counter, yValue);

                var oldBox = p.Controls.OfType<ComboBox>().Single(a => a.Name == string.Format("cmbOld{0}", counter)) as ComboBox;
                oldBox.Items.Add(item.Key);
                oldBox.SelectedIndex = 0;
                oldBox.Enabled = false;

                pnlForm.Controls.Add(p);

                yValue = yValue + 40;
            }

            this.Height = yValue + 95;
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);

            Button btn = new Button();
            btn.Click += btn_Click;
            btn.Text = "Finish";
            btn.Location = new Point(600, yValue + 15);
            pnlForm.Controls.Add(btn);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int counter = 0;

            foreach (var panel in pnlForm.Controls.OfType<Panel>())
            {
                counter++;

                var oldBox = panel.Controls.OfType<ComboBox>().Single(a => a.Name == string.Format("{0}{1}", "cmbOld", counter)) as ComboBox;
                var newBox = panel.Controls.OfType<ComboBox>().Single(a => a.Name == string.Format("{0}{1}", "cmbNew", counter)) as ComboBox;

                if (newBox.SelectedIndex == 0)
                {
                    MessageBox.Show(string.Format(@"Please Select Replacement Activity for ""{0}""", oldBox.SelectedItem), "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var oldGuid = _ReplaceActivityList.Where(a => a.Key == oldBox.SelectedItem.ToString()).Single();
                var newGuid = _newActivities.Where(a => a.Key == newBox.SelectedItem.ToString()).Single();

                FinalMatchList.Add(new KeyValuePair<Guid, Guid>(oldGuid.Value, newGuid.Value));
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private Panel CreateNewPanel(int Id, int yValue)
        {
            Panel masterPanel = new Panel();
            masterPanel.Location = new System.Drawing.Point(12, yValue);
            masterPanel.Name = string.Format("masterPanel{0}",Id);  
            masterPanel.Size = new System.Drawing.Size(673, 56);

            Label replace = new Label();
            replace.Location = new System.Drawing.Point(12, 21);
            replace.Name = string.Format("lblReplace{0}", Id);
            replace.Size = new System.Drawing.Size(47, 13);
            replace.Text = "Replace";

            Label with = new Label();
            with.Location = new System.Drawing.Point(349, 21);
            with.Name = string.Format("lblWith{0}", Id);
            with.Size = new System.Drawing.Size(26, 13);
            with.Text = "with";

            ComboBox cmbNew = new ComboBox();
            cmbNew.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNew.Items.AddRange(new object[] { "Please Select" });
            _newActivities.ForEach(a => cmbNew.Items.Add(a.Key));
            cmbNew.Location = new System.Drawing.Point(393, 18);
            cmbNew.Name = string.Format("cmbNew{0}", Id);
            cmbNew.Size = new System.Drawing.Size(269, 21);
            cmbNew.SelectedIndex = 0;

            ComboBox cmbOld = new ComboBox();
            cmbNew.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOld.Location = new System.Drawing.Point(65, 18);
            cmbOld.Name = string.Format("cmbOld{0}", Id);
            cmbOld.Size = new System.Drawing.Size(269, 21);

            masterPanel.Controls.Add(replace);
            masterPanel.Controls.Add(cmbOld);
            masterPanel.Controls.Add(with);
            masterPanel.Controls.Add(cmbNew);

            return masterPanel;
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
