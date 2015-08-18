using CloudCore.Data.Buildbase;
using Architect.ProcessOverview;
using Architect.ProcessOverview.CustomCode.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Modeling.Integration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using CloudCore.Data;

namespace Architect.CustomCode.ContextMenu
{
    class DeployCommand : DSLMenuCommandImplBase
    {
        #region Init Lists
        Guid commandGuid = new Guid("2F871A5C-A05E-4F91-984B-B99A35CCB6BC");
        List<SubProcess> mySubProcesses = new List<SubProcess>();
        List<LocalActivity> myActivities = new List<LocalActivity>();
        List<LocalFlow> myFlows = new List<LocalFlow>();

        List<KeyValuePair<string, Guid>> formItemList = new List<KeyValuePair<string, Guid>>();
        List<KeyValuePair<string, Guid>> formNewItemList = new List<KeyValuePair<string, Guid>>();

        List<MigrateItem> migrateItemList = new List<MigrateItem>();
        List<Cloudcoremodel_SubProcess> dbSubProcesses = new List<Cloudcoremodel_SubProcess>();
        List<dbActivityModel> dbActivities = new List<dbActivityModel>();
        List<Cloudcoremodel_FlowModel> dbFlows = new List<Cloudcoremodel_FlowModel>();
        #endregion

        private void CleanLists()
        {
            mySubProcesses = new List<SubProcess>();
            myActivities = new List<LocalActivity>();
            myFlows = new List<LocalFlow>();

            dbSubProcesses = new List<Cloudcoremodel_SubProcess>();
            dbActivities = new List<dbActivityModel>();
            dbFlows = new List<Cloudcoremodel_FlowModel>();

            formItemList = new List<KeyValuePair<string, Guid>>();
            formNewItemList = new List<KeyValuePair<string, Guid>>();

            migrateItemList = new List<MigrateItem>();
        }

        public override System.ComponentModel.Design.CommandID GetCommandID()
        {
            return new CommandID(this.commandGuid, 0x00002);
        }

        public override void StatusHandler(CommandSetState state)
        {
            MenuCommand.Visible = true;
            MenuCommand.Enabled = true;
        }

        public override void InvokeHandler(CommandSetState state)
        {
            CleanLists();

            ConnectionStringBuilderPopup form = new ConnectionStringBuilderPopup();
            form.MyConnectionString = "Data Source=localhost; Integrated Security=True; Initial Catalog=CloudCoreDB;";
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                CloudCoreDB db = new CloudCoreDB(form.MyConnectionString);
                var store = state.CurrentDocView.CurrentDiagram.Store;
                var showscript = true;

                Architect.CustomCode.Helpers.ArchitectDte.Instance.Store = store;
                var dte = Architect.CustomCode.Helpers.ArchitectDte.Dte;
                var project = dte.ActiveWindow.Project;

                string AssemblyName = project.Properties.Item("AssemblyName").Value.ToString();
                string SystemModuleGuid = project.Properties.Item("AssemblyGuid").Value.ToString();

                Architect.ProcessOverview.Process process = store.ElementDirectory.AllElements.OfType<Architect.ProcessOverview.Process>().First();

                getDiagramSubProcess(store, process, project);
                getDatabaseSubProcesses(db, new Guid(process.VisioId));

                // Do List Comparison
                myActivities.FindAll(a => !(a.activity is FromProcessConnector) && !(a.activity is ToProcessConnector)).ForEach(act => act.DoCreate = !dbActivities.Any(a => a.activity.ActivityGuid == new Guid(act.activity.VisioId)));
                dbActivities.ForEach(act => act.DoDelete = !myActivities.FindAll(a => !(a.activity is FromProcessConnector) && !(a.activity is ToProcessConnector)).Any(a => new Guid(a.activity.VisioId) == act.activity.ActivityGuid));

                if (dbActivities.Any(a => a.DoDelete))
                {
                    showscript = getReplacementIds();
                }

                string script = GenerateScript(AssemblyName, SystemModuleGuid, new Guid(process.VisioId), process.ProcessName, db, migrateItemList, mySubProcesses, myActivities, myFlows);

                CleanLists();

                if (showscript)
                {
                    ViewScriptForm scriptform = new ViewScriptForm(script);
                    scriptform.ShowDialog();
                }
            }
        }

        private bool getReplacementIds()
        {
            foreach (var act in dbActivities.Where(a => a.DoDelete))
            {
                formItemList.Add(new KeyValuePair<string, Guid>(act.activity.ActivityName, act.activity.ActivityGuid));
            }

            foreach (var act in myActivities)
            {
                formNewItemList.Add(new KeyValuePair<string, Guid>(act.activity.Name, new Guid(act.activity.VisioId)));
            }

            ReplaceActivityForm repForm = new ReplaceActivityForm(formItemList, formNewItemList);
            repForm.ShowDialog();

            if (repForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                repForm.FinalMatchList.ForEach(a => migrateItemList.Add(new MigrateItem { OldActivityGuid = a.Key, NewActivityGuid = a.Value }));
                return true;
            }

            return false;
        }

        private string GenerateScript(string AssemblyName, string SystemModuleGuid, Guid ProcessGuid, string ProcessName, CloudCoreDB db, List<MigrateItem> MigrateItems, List<SubProcess> SubProcesses, List<LocalActivity> Activities, List<LocalFlow> Flows)
        {
            string DeploymentScript = string.Empty;

            var processModelId = (from p in db.Cloudcoremodel_ProcessModel
                                  where p.ProcessGuid == ProcessGuid
                                  select p.ProcessModelId).SingleOrDefault();

            DeploymentScript += @"
declare @systemmoduleid int
declare @processmodelid int
declare @processrevision int
declare @processrevisionid int
declare @subprocessid int
declare @activitymodelid int
declare @fromactivitymodelid int
declare @toactivitymodelid int
declare @oldprocessrevisionid int
declare @processguid uniqueidentifier 
declare @replacementid int";


            DeploymentScript += string.Format(@"

if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = '{3}')
    begin
      select @systemmoduleid = SystemModuleId
      from    cloudcore.SystemModule
      where SystemModuleGuid = '{3}'
    end
else
    begin
      insert into [cloudcore].SystemModule(AssemblyName, SystemModuleGuid)
      values('{0}', '{3}')

      set @systemmoduleid = scope_identity()
    end

-- create the model if its new
set @processguid = '{1}'
if not exists(select null from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid)
begin
  insert into [cloudcoremodel].[ProcessModel] ([ProcessGuid], [ProcessName])
       values (@processguid, '{2}')

  set @processmodelid = SCOPE_IDENTITY()
  set @processrevision = 1
  set @oldprocessrevisionid = null
end else
begin
  select @processmodelid = ProcessModelId  from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid 
  select @processrevision = max(ProcessRevision) from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid
  select @oldprocessrevisionid = ProcessRevisionId from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid and ProcessRevision = @processrevision
  update [cloudcoremodel].ProcessModel set ProcessName = '{2}' where ProcessModelId = @processmodelid
  set @processrevision = @processrevision + 1
end", AssemblyName, ProcessGuid.ToString(), ProcessName, SystemModuleGuid);


            DeploymentScript += @"

-- create the new revision
insert into [cloudcoremodel].[ProcessRevision] ([ProcessModelId], [ProcessRevision], [CheckSum], [UserId], [ManagerId], [Changed])
     values (@processmodelid, @processrevision, null, 0, 0, getdate())

set @processrevisionid = SCOPE_IDENTITY()";

            foreach (var sub in SubProcesses)
            {
                DeploymentScript += string.Format(@"

-- create the new subprocess for each one we found
insert into [cloudcoremodel].[SubProcess] ([ProcessRevisionId], [SubProcessGuid], [SubProcessName])
     values (@processrevisionid, '{0}', '{1}')
set @subprocessid = SCOPE_IDENTITY()", sub.VisioId.ToString(), sub.SubProcessName);

                foreach (var act in Activities.FindAll(a => a.activity.SubProcess.VisioId == sub.VisioId).FindAll(a => !(a.activity is FromProcessConnector) && !(a.activity is ToProcessConnector)))
                {
                    DeploymentScript += string.Format(@"

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [OnlyVisibleAtLocation], [LocationRadius])
     values (@processrevisionid, 0, '{0}', @subprocessid, '{1}', '{2}', 0, '{3}', '{4}', '{5}', '{6}', '{7}')
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid",
                     act.activity.VisioId.ToString(),
                     act.activity.Name,
                     getActivityTypeId(act.activity).ToString(),
                     (act.activity as Start).IsStartable ? "1" : "0",
                     "0",
                     act.activity is CloudcoreUser ? (act.activity as CloudcoreUser).DocWait ? "1" : "0" : "0",
                     act.activity is UserActivity ? (act.activity as UserActivity).OnlyVisibleAtLocation ? "1" : "0" : "0",
                     act.activity is UserActivity ? (act.activity as UserActivity).LocationRadius.ToString() : "null");
                }
            }

            foreach (var flow in Flows)
            {
                DeploymentScript += string.Format(@"

-- create each flow (repeat)
select @fromactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '{0}'
select @toactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '{1}'

insert into [cloudcoremodel].[FlowModel] ([FlowGuid], [ProcessRevisionId], [FromActivityModelId], [Outcome], [ToActivityModelId], [OptimalFlow], [NegativeFlow], [Storyline])
     values ('{2}', @processrevisionid, @fromactivitymodelid, '{3}', @toactivitymodelid, '{4}', '{5}', '{6}')",
                flow.FromActivityGuid.ToString(),
                flow.ToActivityGuid.ToString(),
                flow.FlowGuid.ToString(),
                flow.Outcome,
                flow.IsOptimal ? "1" : "0",
                flow.IsNegative ? "1" : "0",
                flow.StoryLine);
            }

            foreach (var match in MigrateItems)
            {
                DeploymentScript += string.Format(@"

-- update the old model replacement id (repeat)
select @activitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '{0}' and ProcessRevisionId = @oldprocessrevisionid 
select @replacementid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '{1}' and ProcessRevisionId = @processrevisionid
update [cloudcoremodel].ActivityModel set ReplacementId = @replacementid where ActivityModelId = @activitymodelid and ProcessRevisionId = @oldprocessrevisionid",
                match.OldActivityGuid.ToString(), match.NewActivityGuid.ToString());
            }


            DeploymentScript += @"

  -- insert the new ones
  insert into [cloudcore].Activity  ([ActivityModelId]
           ,[ProcessRevisionId]
           ,[SystemModuleId]
           ,[ActivityTypeId]
           ,[OnlyVisibleAtLocation]
           ,[LocationRadius]
           ,[ActivityGuid]
           ,[SubProcessGuid]
           ,[ProcessGuid])
  select AM.ActivityModelId, AM.ProcessRevisionId, @systemmoduleid,
         AM.ActivityTypeId, AM.OnlyVisibleAtLocation,
         AM.LocationRadius, AM.ActivityGuid,
		 SP.SubProcessGuid, PM.ProcessGuid

     from [cloudcoremodel].ActivityModel AM
	inner join [cloudcoremodel].SubProcess SP
	  on SP.SubProcessId = AM.SubProcessId
    inner join [cloudcoremodel].ProcessRevision PR
	   on PR.ProcessRevisionId = SP.ProcessRevisionId
    inner join [cloudcoremodel].ProcessModel PM
	   on PM.ProcessModelId = PR.ProcessModelId
	where AM.ActivityGuid not in (select ActivityGuid from [cloudcoremodel].ActivityModel where ProcessRevisionId = @oldprocessrevisionid)
	and AM.ProcessRevisionId = @processrevisionid

-- select old revision info
if (@oldprocessrevisionid is not null)
begin
  -- reset failed activities in this process
  delete from [cloudcore].WorklistFailure where ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)
  update [cloudcore].Worklist set StatusTypeId = 0 where StatusTypeId = 101 and ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)

  -- update the ones that remain
  update A 
     set A.ProcessRevisionId = @processrevisionid,
	     A.ActivityModelId = AM.ActivityModelId,
         A.OnlyVisibleAtLocation = AM.OnlyVisibleAtLocation,
         A.LocationRadius = AM.LocationRadius,
		 A.ActivityTypeId = AM.ActivityTypeId
    from [cloudcore].Activity A
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityGuid = A.ActivityGuid
	where A.ProcessRevisionId = @oldprocessrevisionid
	  and AM.ProcessRevisionId = @processrevisionid

  -- delete the ones that get removed 
  update W 
     set W.ActivityId = AN.ActivityId
    from [cloudcore].Worklist W
   inner join [cloudcore].Activity A
      on A.ActivityId = W.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   delete from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid
end
GO
";

            foreach (var act in Activities.FindAll(a => !(a.activity is FromProcessConnector) && !(a.activity is ToProcessConnector)))
            {

                if (act.IsSQLActivity && act.activity is DatabaseEvent)
                {
                    DeploymentScript += string.Format(@"

if exists(select null from sys.sysobjects
where type = 'p' and name = '{0}')
begin
    drop procedure [cloudcore].[{0}]
end
GO", act.FileName);

                    DeploymentScript += string.Format(@"

{0}
GO", act.FileContent);
                }

                else if (act.IsSQLActivity)
                {
                    DeploymentScript += string.Format(@"

if exists(select null from sys.sysobjects
where type = 'FN' and name = '{0}')
begin
    drop function [cloudcore].[{0}]
end
GO", act.FileName);

                    DeploymentScript += string.Format(@"

{0}
GO", act.FileContent);
                }
            }

            return DeploymentScript;
        }

        private int getActivityTypeId(Activity act)
        {
            int ActivityTypeId = 0;

            if (act is Architect.CloudcoreUser) { ActivityTypeId = 0; }
            else if (act is Architect.CustomUser) { ActivityTypeId = 1; }
            else if (act is Architect.DatabaseEvent) { ActivityTypeId = 2; }
            else if (act is Architect.DatabasePark) { ActivityTypeId = 3; }
            else if (act is Architect.WorkflowRule) { ActivityTypeId = 4; }
            else if (act is Architect.CloudCustom) { ActivityTypeId = 5; }
            else if (act is Architect.DatabaseCosting) { ActivityTypeId = 6; }
            else if (act is Architect.CloudCosting) { ActivityTypeId = 7; }
            else if (act is Architect.DatabaseBatchStart) { ActivityTypeId = 8; }
            else if (act is Architect.CloudBatchStart) { ActivityTypeId = 9; }
            else if (act is Architect.CloudBatchWait) { ActivityTypeId = 10; }
            else if (act is Architect.CloudPark) { ActivityTypeId = 11; }
            else if (act is Architect.Clickatell) { ActivityTypeId = 12; }
            else if (act is Architect.PostageApp) { ActivityTypeId = 13; }
            else if (act is Architect.Corticon) { ActivityTypeId = 14; }
            else if (act is Architect.DatabaseBatchWait) { ActivityTypeId = 15; }
            else if (act is Architect.Email) { ActivityTypeId = 16; }
            else if (act is Architect.MobileActivity) { ActivityTypeId = 17; }
            else if (act is Architect.HybridActivity) { ActivityTypeId = 18; }

            return ActivityTypeId;
        }

        private string GetFileContent(string SubProcessGuid, string itemGuid, Project dteProject)
        {
            try
            {
                ProjectItem sqlFolder = dteProject.ProjectItems.
                Item("Activities").ProjectItems.
                Item("_" + SubProcessGuid.Replace("-", "_")).ProjectItems.
                Item("Sql");

                string itemName = string.Format("_{0}.sql", itemGuid.Replace("-", "_"));
                ProjectItem projectItem = sqlFolder.ProjectItems.Item(itemName);

                EnvDTE.TextDocument textDocument = (EnvDTE.TextDocument)projectItem.Open().Document.Object("TextDocument");
                EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
                return editPoint.GetText(textDocument.EndPoint).Replace("\"", "\"\"");
            }
            catch (Exception ex) { return ex.Message; }
        }

        #region Get Diagram Objects

        private void getDiagramSubProcess(Microsoft.VisualStudio.Modeling.Store store, Architect.ProcessOverview.Process process, Project project)
        {


            foreach (var item in process.BTSubProcess)
            {
                IModelBus modelBus = item.SubProcessRef.ModelBus;
                ModelBusReference reference = ((SubProcessElement)item).SubProcessRef;
                ModelBusAdapter toSubProcAdapter = modelBus.CreateAdapter(reference);

                var toSubProc = (((Architect.ModelBusAdapters.CloudCoreArchitectSubProcessAdapterBase)(toSubProcAdapter)).ModelRoot as SubProcess);

                mySubProcesses.Add(toSubProc);
                getDiagramActivities(toSubProc, project);
            }
        }

        private void getDiagramActivities(SubProcess subProcess, Project project)
        {
            foreach (var activity in subProcess.Activities.Where(a => !(a is Stop)))
            {
                var newact = new LocalActivity
                {
                    activity = activity,
                    IsSQLActivity = activity is DatabaseEvent || activity is Architect.WorkflowRule || activity is Architect.DatabaseCosting || activity is Architect.DatabaseBatchStart || activity is Architect.DatabaseBatchWait || activity is Architect.DatabasePark,
                };

                if (newact.IsSQLActivity)
                {
                    newact.FileContent = GetFileContent(subProcess.VisioId, activity.VisioId, project);

                    newact.FileName = activity is DatabaseEvent ? string.Format("CCEvent_{0}", activity.VisioId.ToString().Replace("-", "_"))
                        : activity is Architect.WorkflowRule ? string.Format("CCWorkFlowRule_{0}", activity.VisioId.ToString().Replace("-", "_"))
                        : activity is Architect.DatabaseCosting ? string.Format("CCCost_{0}", activity.VisioId.ToString().Replace("-", "_"))
                        : activity is Architect.DatabaseBatchStart ? string.Format("CCBatchStart_{0}", activity.VisioId.ToString().Replace("-", "_"))
                        : activity is Architect.DatabaseBatchWait ? string.Format("CCBatchWait_{0}", activity.VisioId.ToString().Replace("-", "_"))
                        : activity is Architect.DatabasePark ? string.Format("CCPark_{0}", activity.VisioId.ToString().Replace("-", "_")) : "";
                }

                myActivities.Add(newact);
                getDiagramFlows(activity);
            }
        }

        private void getDiagramFlows(Activity activity)
        {
            var flows = FlowBase.GetLinksToTargetActs(activity);

            foreach (var flow in flows)
            {
                Guid targetGuid;

                if (flow.SourceActivity is FromProcessConnector)
                {
                    continue;
                }

                if (flow.TargetActivity is Stop)
                {
                    if (flow.TargetActivity is ToProcessConnector)
                    {
                        targetGuid = ((ToProcessConnector)flow.TargetActivity).ToActivityGuid;
                    }
                    else
                    {
                        targetGuid = new Guid();
                    }
                }
                else
                {
                    targetGuid = new Guid(flow.TargetActivity.VisioId);
                }


                myFlows.Add(new LocalFlow
                {
                    FlowGuid = new Guid(flow.VisioId),
                    FromActivityGuid = new Guid(flow.SourceActivity.VisioId),
                    ToActivityGuid = targetGuid,
                    Outcome = flow is Flow ? (flow as Flow).Outcome : "-",
                    StoryLine = flow is Flow ? (flow as Flow).Storyline : "",
                    IsOptimal = flow.Type == FlowType.Optimal,
                    IsNegative = flow.Type == FlowType.Negative
                });
            }
        }

        #endregion

        #region Get Database Objects

        private void getDatabaseSubProcesses(CloudCoreDB db, Guid ProcessGuid)
        {
            int maxRevision = 0;
            var Revisions = (from max in db.Cloudcoremodel_ProcessRevision
                             join b in db.Cloudcoremodel_ProcessRevision on max.ProcessRevisionId equals b.ProcessRevisionId
                             join c in db.Cloudcoremodel_ProcessModel on b.ProcessModelId equals c.ProcessModelId
                             where c.ProcessGuid == ProcessGuid
                             select new
                             {
                                 max.ProcessRevisionId,
                                 max.ProcessRevision
                             }).ToList();

            if (Revisions.Count > 0)
            {
                maxRevision = Revisions.Max(a => a.ProcessRevision);
            }

            var dbtasks = (from a in db.Cloudcoremodel_SubProcess
                           join b in db.Cloudcoremodel_ProcessRevision on a.ProcessRevisionId equals b.ProcessRevisionId
                           join c in db.Cloudcoremodel_ProcessModel on b.ProcessModelId equals c.ProcessModelId
                           where c.ProcessGuid == ProcessGuid
                              && b.ProcessRevision == maxRevision
                           select a).ToList();

            foreach (var sub in dbtasks)
            {
                dbSubProcesses.Add(sub);

                getDatabaseActivities(db, sub.SubProcessGuid, maxRevision);
            }
        }

        private void getDatabaseActivities(CloudCoreDB db, Guid SubProcessGuid, int maxRevision)
        {
            var dbtasks = (from a in db.Cloudcoremodel_ActivityModel
                           join b in db.Cloudcoremodel_ProcessRevision on a.ProcessRevisionId equals b.ProcessRevisionId
                           join c in db.Cloudcoremodel_SubProcess on a.SubProcessId equals c.SubProcessId
                           where c.SubProcessGuid == SubProcessGuid
                              && b.ProcessRevision == maxRevision
                           select a).ToList();

            foreach (var act in dbtasks)
            {
                dbActivities.Add(new dbActivityModel { activity = act });

                getDatabaseFlows(db, act.ActivityGuid);
            }
        }

        private void getDatabaseFlows(CloudCoreDB db, Guid ActivityGuid)
        {
            var dbtasks = (from a in db.Cloudcoremodel_FlowModel
                           join b in db.Cloudcoremodel_ActivityModel on a.FromActivityModelId equals b.ActivityModelId
                           where b.ActivityGuid == ActivityGuid
                           select a).ToList();

            dbtasks.ForEach(a => dbFlows.Add(a));
        }

        #endregion
    }

    public class LocalActivity
    {
        public Activity activity { get; set; }
        public bool DoCreate { get; set; }
        public bool IsSQLActivity { get; set; }
        public string FileContent { get; set; }
        public string FileName { get; set; }
    }

    public class LocalFlow
    {
        public Guid FlowGuid { get; set; }
        public Guid FromActivityGuid { get; set; }
        public Guid ToActivityGuid { get; set; }
        public string Outcome { get; set; }
        public bool IsOptimal { get; set; }
        public bool IsNegative { get; set; }
        public string StoryLine { get; set; }
    }

    public class dbActivityModel
    {
        public Cloudcoremodel_ActivityModel activity { get; set; }
        public bool DoDelete { get; set; }
    }

    public class MigrateItem
    {
        public Guid OldActivityGuid { get; set; }
        public Guid NewActivityGuid { get; set; }
    }
}
