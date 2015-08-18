using Architect.ScheduledTasks;
using Architect.ScheduledTasks.CustomCode.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CloudCore.Data;
using EnvDTE;
using CloudCore.Data.Buildbase;

namespace Architect.CustomCode.ContextMenu
{
    class DeployCommand : DSLMenuCommandImplBase
    {
        Guid commandGuid = new Guid("D869A940-9D28-4DE4-977F-6E12E4870825");
        List<myScheduledTask> scheduledtasks = new List<myScheduledTask>();
        List<DBScheduledTask> dbscheduledtasks = new List<DBScheduledTask>();

        private void CleanLists()
        {
            scheduledtasks = new List<myScheduledTask>();
            dbscheduledtasks = new List<DBScheduledTask>();
        }

        public override System.ComponentModel.Design.CommandID GetCommandID()
        {
            return new CommandID(this.commandGuid, 0x02002);
        }

        public override void StatusHandler(CommandSetState state)
        {
            MenuCommand.Visible = true;
            MenuCommand.Enabled = true;
        }

        public override void InvokeHandler(CommandSetState state)
        {
            CleanLists();
            var store = state.CurrentDocView.CurrentDiagram.Store;
            var showscript = true;

            ConnectionStringBuilderPopup form = new ConnectionStringBuilderPopup();
            form.MyConnectionString = "Data Source=localhost; Integrated Security=True; Initial Catalog=CloudCoreDB;";
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                CloudCoreDB db = new CloudCoreDB(form.MyConnectionString);
                EnvDTE._DTE dte = new ScheduledTasks.VsEnvironment.ScheduledTaskDte(store).Dte;
                var project = dte.ActiveWindow.Project;

                Group group = getDiagramTasks(store, project);
                getDatabaseTasks(db, group.Id);

                string AssemblyName = project.Properties.Item("AssemblyName").Value.ToString();
                string AssemblyGuid = project.Properties.Item("AssemblyGuid").Value.ToString();

                // Do List Comparison
                scheduledtasks.ForEach(task => task.DoCreate = !dbscheduledtasks.Any(a => a.ScheduledTask.ScheduledTaskGuid == task.ScheduledTask.Id));
                dbscheduledtasks.ForEach(task => task.DoDelete = !scheduledtasks.Any(a => a.ScheduledTask.Id == task.ScheduledTask.ScheduledTaskGuid));

                string script = GenerateScript(AssemblyName, AssemblyGuid, group.Id, group.GroupName, scheduledtasks, dbscheduledtasks);

                CleanLists();

                if (showscript)
                {
                    ViewScriptForm scriptform = new ViewScriptForm(script);
                    scriptform.ShowDialog();
                }
            }
        }

        private string GenerateScript(string AssemblyName, string AssemblyGuid, Guid ScheduledTaskGroupGuid, string ScheduledTaskGroupName, List<myScheduledTask> newscheduledtasks, List<DBScheduledTask> oldscheduledtasks)
        {
            string DeploymentScript = string.Empty;

            DeploymentScript += string.Format(@"
declare @systemmoduleid int
declare @scheduledtaskgroupguid uniqueidentifier = '{0}'
declare @scheduledtaskgroupid int",ScheduledTaskGroupGuid.ToString());

            DeploymentScript += string.Format(@"

if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = '{1}')
    begin
      select @systemmoduleid = SystemModuleId
      from    cloudcore.SystemModule
      where SystemModuleGuid = '{1}'
    end
else
    begin
      insert into [cloudcore].SystemModule(AssemblyName, SystemModuleGuid)
      values('{0}', '{1}')

      set @systemmoduleid = scope_identity()
    end", AssemblyName, AssemblyGuid);

            DeploymentScript += string.Format(@"

-- create or update scheduled task group
if not exists(select null from [cloudcore].[ScheduledTaskGroup] where [ScheduledTaskGroupGuid] = @scheduledtaskgroupguid)
begin
  insert into [cloudcore].[ScheduledTaskGroup] ([ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
  values (@scheduledtaskgroupguid, @systemmoduleid, '{0}', 0)
  set @scheduledtaskgroupid = SCOPE_IDENTITY()
end else
begin
  select @scheduledtaskgroupid = ScheduledTaskGroupId from [cloudcore].[ScheduledTaskGroup] where ScheduledTaskGroupGuid = @scheduledtaskgroupguid
  update [cloudcore].[ScheduledTaskGroup] set ScheduledTaskGroupName = '{0}' where ScheduledTaskGroupId = @scheduledtaskgroupid
end", ScheduledTaskGroupName);

            foreach (var task in oldscheduledtasks.Where(a => a.DoDelete))
            {
                DeploymentScript += string.Format(@"

-- drop tasks that no longer exist in the new implementation from the task table (repeat for each)
delete from [cloudcore].[ScheduledTaskFailed] where ScheduledTaskId in (Select ScheduledTaskId from [cloudcore].[ScheduledTask] where ScheduledTaskGuid = '{0}')
delete from [cloudcore].[ScheduledTask] where ScheduledTaskGuid = '{0}'", task.ScheduledTask.ScheduledTaskGuid.ToString());
            }

            foreach (var task in newscheduledtasks.Where(a => a.DoCreate))
            {
                DeploymentScript += string.Format(@"

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('{0}', '{1}', '{2}', getdate(), null, 0, 1, 0, {3}, '{4}', '{5}', '{6}', @scheduledtaskgroupid, @systemmoduleid)", 
               task.ScheduledTask.Id.ToString(), 
               task.ScheduledTask.Name,
               Convert.ToInt16(task.ScheduledTask.Type),
               Convert.ToInt16(task.ScheduledTask.IntervalType), 
               task.ScheduledTask.Interval, 
               task.ScheduledTask.StartDate, 
               task.ScheduledTask.StartDate);

            }

            DeploymentScript += @"

GO";

            foreach (var task in oldscheduledtasks.Where(a => a.ScheduledTask.ScheduledTaskTypeId == Convert.ToInt16(TaskType.SQL) || a.DoDelete))
            {
                DeploymentScript += string.Format(@"

if exists(select null from sys.sysobjects
where type = 'p' and name = '{0}')
begin
    drop procedure [cloudcore].[{0}]
end
GO", getFileName(task.ScheduledTask.ScheduledTaskGuid));
            }

            foreach (var task in newscheduledtasks.Where(a => a.ScheduledTask.Type == TaskType.SQL))
            {
                DeploymentScript += string.Format(@"

if exists(select null from sys.sysobjects
where type = 'p' and name = '{0}')
begin
    drop procedure [cloudcore].[{0}]
end
GO", task.FileName);

                DeploymentScript += string.Format(@"

{0}
GO", task.FileContent);
            }

            return DeploymentScript;
        }

        private string getFileName(Guid ScheduledTaskGuid)
        {
            return string.Format("CCScheduledTask_{0}", ScheduledTaskGuid.ToString().Replace("-", "_"));
        }

        private Group getDiagramTasks(Microsoft.VisualStudio.Modeling.Store store, Project project)
        {
            Group scheduledtaskGroup = store.ElementDirectory.AllElements.OfType<Group>().First();

            foreach (var task in scheduledtaskGroup.Elements)
            {
                var myTask = new myScheduledTask { ScheduledTask = task};

                if (task.Type == TaskType.SQL)
                {
                    myTask.FileContent = GetFileContent(scheduledtaskGroup.Id, task.Id, project);
                    myTask.FileName = string.Format("CCScheduledTask_{0}", task.Id.ToString().Replace("-", "_"));
                }

                scheduledtasks.Add(myTask);
            }

            return scheduledtaskGroup;
        }

        private string GetFileContent(Guid groupGuidString, Guid taskGuidString, Project dteProject)
        {
            try
            {
                ProjectItem groupFolder = dteProject.ProjectItems.
                Item("Scheduled Tasks").ProjectItems.
                Item("sql").ProjectItems.
                Item(string.Format("_{0}", groupGuidString.ToString().Replace("-", "_")));

                string itemName = string.Format("_{0}.sql", taskGuidString.ToString().Replace("-", "_"));
                ProjectItem projectItem = groupFolder.ProjectItems.Item(itemName);

                EnvDTE.TextDocument textDocument = (EnvDTE.TextDocument)projectItem.Open().Document.Object("TextDocument");
                EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
                return editPoint.GetText(textDocument.EndPoint).Replace("\"", "\"\"");
            }
            catch (Exception ex) { return ex.Message; }
        }

        private void getDatabaseTasks(CloudCoreDB db, Guid groupGuid)
        {
            var dbtasks = (from a in db.Cloudcore_ScheduledTask 
                           join b in db.Cloudcore_ScheduledTaskGroup on a.ScheduledTaskGroupId equals b.ScheduledTaskGroupId
                           where b.ScheduledTaskGroupGuid == groupGuid 
                           select a).ToList();

            dbtasks.ForEach(a => dbscheduledtasks.Add(new DBScheduledTask { ScheduledTask = a }));
        }
    }

    public class myScheduledTask
    {
        public BaseScheduledTask ScheduledTask { get; set; }
        public bool DoCreate { get; set; }
        public string FileContent { get; set; }
        public string FileName { get; set; }
    }

    public class DBScheduledTask
    {
        public Cloudcore_ScheduledTask ScheduledTask { get; set; }
        public bool DoDelete { get; set; }
    }
}
