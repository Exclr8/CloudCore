using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessViewer.Library.Shapes
{
    public class Process : BaseShape
    {
        public int RevisionId { get; set; }
        public List<SubProcess> SubProcesses {get; set;}
        public List<Connector> Connectors { get; set; }
        private DrawItem drawItem { get; set; }

        public Process(DrawItem drawItem)
        {
            this.drawItem = drawItem;
        }

        public override string TemplateShapeName
        {
            get { return null; }
        }

        public override bool HasTitle
        {
            get { return false; }
        }

        public override bool IsDrawable
        {
            get { return false; }
        }

        public void GenerateContent(string connectionString)
        {
            SubProcesses = new List<SubProcess>();
            Connectors = new List<Connector>();

            GenerateActivities(connectionString);
            GenerateConnectors(connectionString);
        }

        private void GenerateConnectors(string connectionString)
        {
            var db = new Data1.CloudCoreDB(connectionString);

            var connectors = (from f in db.Cloudcoremodel_FlowModel
                              join fa in db.Cloudcoremodel_ActivityModel on f.FromActivityModelId equals fa.ActivityModelId
                              join t in db.Cloudcoremodel_SubProcess on fa.SubProcessId equals t.SubProcessId
                              join p in db.Cloudcoremodel_ProcessRevision on t.ProcessRevisionId equals p.ProcessRevisionId
                              where RevisionId == p.ProcessRevisionId
                              select new
                              {
                                  Title = f.Outcome == "-" ? String.Empty : f.Outcome,
                                  FromId = f.FromActivityModelId,
                                  ToId = f.ToActivityModelId,
                                  OptimalFlow = f.OptimalFlow,
                                  NegativeFlow = f.NegativeFlow,
                                  HasTrigger = (bool)db.Cloudcore_FlowHasTrigger(f.FlowGuid)
                              }).Distinct();

            foreach (var connector in connectors)
            {
                var con = new Connector()
                {
                    Title = connector.Title,
                    FromActivityId = connector.FromId,
                    ToActivityId = connector.ToId
                };
                if (connector.OptimalFlow)
                {
                    con.AddProperty(ConnectorProperties.Optimal);
                }
                if (connector.NegativeFlow)
                {
                    con.AddProperty(ConnectorProperties.Negative);
                }
                if (connector.HasTrigger)
                {
                    con.AddProperty(ConnectorProperties.Trigger);
                }

                Connectors.Add(con);
            }
        }

        
        private void GenerateActivities(string connectionString)
        {
            var db = new Data1.CloudCoreDB(connectionString);

            var activities = from am in db.Cloudcoremodel_ActivityModel
                             join sub in db.Cloudcoremodel_SubProcess on am.SubProcessId  equals sub.SubProcessId
                             join pr in db.Cloudcoremodel_ProcessRevision on am.ProcessRevisionId equals pr.ProcessRevisionId
                             where pr.ProcessRevisionId == Id || pr.ProcessModelId == 0
                             select new
                             {
                                 Id = am.ActivityModelId,
                                 Title = am.ActivityName,
                                 SubProcessId = sub.SubProcessId,
                                 SubProcessName = sub.SubProcessName,
                                 Startable = am.Startable,
                                 ActivityTypeId = am.ActivityTypeId,
                                 Decision = (from f in db.Cloudcoremodel_FlowModel
                                             where f.FromActivityModelId == am.ActivityModelId
                                             select am.ActivityModelId).Count() > 1
                             };

            foreach (var activity in activities)
            {
                var subProcess = SubProcesses.Where(r => r.Id == activity.SubProcessId).SingleOrDefault();
                if (subProcess == null)
                {
                    subProcess = new SubProcess()
                    {
                        Id = activity.SubProcessId,
                        Parent = this,
                        Title = activity.SubProcessName

                    };
                    SubProcesses.Add(subProcess);
                }

                IActivity act;

                switch (activity.ActivityTypeId)
                {
                    case 0:
                        act = new CloudCore_User_Activity();
                        break;
                    case 1:
                        act = new Custom_User_Activity();
                        break;
                    case 2:
                        act = new Database_Custom_Activity();
                        break;
                    case 3:
                        act = new Database_Parked_Activity();
                        break;
                    case 4:
                        act = new Flow_Rule();
                        break;
                    case 5:
                        act = new Cloud_Custom_Activity();
                        break;
                    case 6:
                        act = new Database_Costing();
                        break;
                    case 7:
                        act = new Cloud_Costing();
                        break;
                    case 8:
                        act = new Database_Batch_Start();
                        break;
                    case 9:
                        act = new Cloud_Batch_Start();
                        break;
                    case 10:
                        act = new Cloud_Batch_Wait();
                        break;
                    case 11:
                        act = new Cloud_Parked_Activity();
                        break;
                    case 12:
                        act = new SMS_Activity();
                        break;
                    case 13:
                        act = new Email_Activity();
                        break;
                    case 14:
                        act = new Corticon_Business_Rule();
                        break;
                    case 99:
                        act = new StopActivity();
                        break;
                    default:
                        act = new CloudCore_User_Activity();
                        break;
                }

                act.Title = activity.Title;
                act.Id = activity.Id;
                act.Parent = subProcess;

                if (activity.Startable)
                    act.AddProperty(ActivityProperties.Startable);


                subProcess.Activities.Add(act);
            }
        }

    }
}
