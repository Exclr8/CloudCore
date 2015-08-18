using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Btomic
{
    public partial class Processes : Form
    {
        public int ProcessId { get; set; }
        private readonly string _dbVersion;

        public Processes(string dbVersion)
        {
            InitializeComponent();
            _dbVersion = dbVersion;

            if (dbVersion == "1")
                btnOK.Text = "Finish";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbProcesses.SelectedItem == null)
            {
                DialogResult = DialogResult.None;
                return;
            }

            ProcessId = ((ProcessListItem)lbProcesses.SelectedItem).ProcessID;
            DialogResult = DialogResult.OK;
            return;
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            List<ProcessListItem> processes;

            if (_dbVersion == "1")
            {
                var db = FrameworkOne.EditorExtentions.Data.Version1.BtomicDB.Context;

                processes = (from p in db.BTProcess
                             join ent in db.BTEntity on p.EntityID equals ent.EntityID
                             where p.ProcessID != 0
                             select new ProcessListItem
                                        {
                                            ProcessName = p.ProcessName,
                                            ProcessID = p.ProcessID,
                                            ProcessTable = ent.TableName,
                                            ProcessKey = ent.KeyField
                                        }).ToList();
            }
            else
            {

                processes = (from p in BtomicDB.Context.Model_BTProcessModel
                             where p.ProcessModelId != 0
                             select new ProcessListItem
                                        {
                                            ProcessName = p.ProcessName,
                                            ProcessID = p.ProcessModelId,
                                            ProcessTable = p.TableName,
                                            ProcessKey = p.KeyField
                                        }).ToList();
            }

            var selected = false;
            foreach (var process in processes)
            {
                lbProcesses.Items.Add(process);
                if (selected) continue;
                lbProcesses.SelectedItem = process;
                selected = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public class ProcessListItem
    {
        public int ProcessID { get; set; }
        public String ProcessName { get; set; }
        public String ProcessTable { get; set; }
        public String ProcessKey { get; set; }

        public override string ToString()
        {
            return ProcessName;
        }

    }
}
