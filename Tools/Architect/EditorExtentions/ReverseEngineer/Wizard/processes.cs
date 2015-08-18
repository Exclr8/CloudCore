using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrameworkOne.EditorExtentions.Classes;

namespace Btomic
{
    public partial class Processes : Form
    {
        public Processes()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BtomicDB db = new BtomicDB();

            dslHelper.ActTypes.Clear();
            dslHelper.ActTypes.Add(new ActivityType { Id = 0, Type = "page" });
            dslHelper.ActTypes.Add(new ActivityType { Id = 1, Type = "unkown" });
            dslHelper.ActTypes.Add(new ActivityType { Id = 2, Type = "storedProcedure" });
            dslHelper.ActTypes.Add(new ActivityType { Id = 3, Type = "outPort" });
            dslHelper.ActTypes.Add(new ActivityType { Id = 4, Type = "inPort" });
            dslHelper.ActTypes.Add(new ActivityType { Id = 5, Type = "stop" });

            foreach (object item in checkProcesses.CheckedItems)
            {
                int processid = ((dynamic) item).ProcessID;

                Process process = (from p in db.BTProcess
                                   where p.ProcessID == processid
                                   select new Process
                                              {
                                                  ProcessID = p.ProcessID,
                                                  ProcessName = p.ProcessName,
                                                  ManagerID = p.ManagerID,
                                                  EntityID = p.EntityID,
                                                  LastUpdate = p.LastUpdate,
                                                  Outdated = p.Outdated,
                                                  Guid = db.NewGuid()
                                              }).SingleOrDefault();

                List<Task> allTask = (from t in db.BTTask
                                      where t.ProcessID == processid
                                      select new Task
                                                 {
                                                     DocWait = t.DocWait,
                                                     Guid = db.NewGuid(),
                                                     LastUpdate = t.LastUpdate,
                                                     Outdated = t.Outdated,
                                                     Priority = t.Priority,
                                                     ProcessID = t.ProcessID,
                                                     SystemModuleID = t.SystemModuleID,
                                                     TaskID = t.TaskID,
                                                     TaskName = t.TaskName
                                                 }).ToList();

                List<Activity> allActivity = (from a in db.BTActivity
                                              join t in db.BTTask
                                                  on a.TaskID equals t.TaskID
                                              where t.ProcessID == processid
                                              select new Activity
                                                         {
                                                             ActivityID = a.ActivityID,
                                                             ActivityInd = a.ActivityInd,
                                                             ActivityName = a.ActivityName,
                                                             ActivityType = a.ActivityType,
                                                             Guid = db.NewGuid(),
                                                             IsMenuItem = a.IsMenuItem,
                                                             LastUpdate = a.LastUpdate,
                                                             Outdated = a.Outdated,
                                                             Startable = a.Startable,
                                                             TaskID = a.TaskID
                                                         }).ToList();

                List<FlowMap> allFlow = (from f in db.BTFlowMap
                                         join a in db.BTActivity
                                             on f.FromActivity equals a.ActivityID
                                         join t in db.BTTask
                                             on a.TaskID equals t.TaskID
                                         where t.ProcessID == processid
                                         select new FlowMap
                                                    {
                                                        FlowID = f.FlowID,
                                                        FromActivity = f.FromActivity,
                                                        LastUpdate = f.LastUpdate,
                                                        OutcomeID = f.OutcomeID,
                                                        Outdated = f.Outdated,
                                                        Storyline = f.Storyline,
                                                        ToActivity = f.ToActivity,
                                                        FromTaskID = f.BTActivity.TaskID,
                                                        ToTaskID = f.ToActivityBTActivity.TaskID,
                                                        Outcome = f.BTOutcome.Outcome
                                                    }).ToList();

                dslHelper.AddPorts(ref process, ref allTask, ref allActivity, ref allFlow);
                string str = dslHelper.GenerateDiagram(ref process, ref allTask, ref allActivity, ref allFlow);

                dslHelper.BtomicDiagrams.Add(new BtomicDiagram() {name = process.ProcessName, content = str});
            }
            
            DialogResult = DialogResult.OK;
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            checkProcesses.DataSource = (from p in BtomicDB.Context.BTProcess
                                         select new { p.ProcessID, p.ProcessName });

            checkProcesses.DisplayMember = "ProcessName";
            checkProcesses.ValueMember = "ProcessID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
