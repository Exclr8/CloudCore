using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.CustomCode.Helpers
{
    public enum FileType
    {
        View,
        Controller,
        PageModel,

        SqlCustomActivity,
        SqlWorkflowRuleActivity,
        SqlCostingActivity,
        SqlBatchStartActivity,
        SqlBatchWaitActivity,
        SqlParkedActivity,

        ActivityPropertiesClass,

        CloudCustomActivity,
        CloudCorticonActivity,
        CloudClickatellActivity,
        CloudPostageActivity,
        CloudCostingActivity,
        CloudBatchWaitActivity,
        CloudBatchStartActivity,
        CloudParkedActivity,

        Email
    }

    public enum FolderName
    {
        Sql,
        Cloud,
        Settings,
        Views,
        Models,
        Controllers
    }

    public class GenerateFileType
    {
        public int Id { get; set; }
        public FileType Type { get; set; }
        public FolderName FolderName { get; set; }
        public string Extension { get; set; }
        public string Content { get; set; }
    }

    public static class FileTypes
    {
        public static List<GenerateFileType> FilesTypes = new List<GenerateFileType>();

        public static GenerateFileType getFileType(FileType fileType)
        {
            return FileTypes.GetList().Where(a => a.Type == fileType).SingleOrDefault();
        }

        public static List<GenerateFileType> GetList()
        {
            FilesTypes.Clear();

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.ActivityPropertiesClass,
                FolderName = FolderName.Settings,
                Extension = "cs",
                Content = @"using System;" + Environment.NewLine +
                          @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1}{2}" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        {3}" + Environment.NewLine + 
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.View,
                FolderName = FolderName.Views,
                Extension = "cshtml",
                Content = @"@inherits CloudCore.Web.Core.BaseViews.WorkItemView<{0}.Models._{1}Model>" + Environment.NewLine +
                          @"@{{" + Environment.NewLine +
                          @"    ViewBag.Title = ""My WorkItem Title"";" + Environment.NewLine +
                          @" }}" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.Controller,
                FolderName = FolderName.Controllers,
                Extension = "cs",
                Content = @"using System;" + Environment.NewLine +
                          @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using System.Linq;" + Environment.NewLine +
                          @"using System.Web;" + Environment.NewLine +
                          @"using CloudCore.Web.Core.BaseControllers;" + Environment.NewLine +
                          @"using System.Web.Mvc;" + Environment.NewLine +
                          @"using {0}.Models;" + Environment.NewLine + 
                          Environment.NewLine +
                          @"namespace CloudCore.Activities.Controllers" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1}Controller : ProcessBaseController" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        //Load action for View" + Environment.NewLine +
                          @"        public ActionResult _{2}(long instanceId, long keyValue)" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"            _{2}Model model = new _{2}Model();" + Environment.NewLine + Environment.NewLine +
                          @"            model.InstanceId = instanceId;" + Environment.NewLine + Environment.NewLine +
                          @"            return View(model);" + Environment.NewLine +
                          @"        }}" + Environment.NewLine + Environment.NewLine +
                          @"        //Submit action for View" + Environment.NewLine +
                          @"        [HttpPost]" + Environment.NewLine +
                          @"        public ActionResult _{2}(long instanceId, long keyValue, _{2}Model model)" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"            // Your Code to save data here" + Environment.NewLine + Environment.NewLine +
                          @"            return FlowNavigate(instanceId);" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.PageModel,
                FolderName = FolderName.Models,
                Extension = "cs",
                Content = @"using System;" + Environment.NewLine +
                          @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using System.Linq;" + Environment.NewLine +
                          @"using System.Web;" + Environment.NewLine +
                          @"using CloudCore.Classes.Workflow;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {1}.Models" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public class _{0}Model : CloudCore.Web.Core.Workflow.Models.BaseWorkItemModel" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"    " + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlCustomActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create procedure [cloudcore].[CCEvent_{0}]" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    --Your Code Here" + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlWorkflowRuleActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create function [cloudcore].[CCWorkflowRule_{0}]" + Environment.NewLine +
                          @"(" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @")" + Environment.NewLine +
                          @"returns varchar(30)" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    declare @Outcome varchar(30)" + Environment.NewLine + Environment.NewLine +
                          @"    --Your Code Here" + Environment.NewLine + Environment.NewLine +
                          @"    return @Outcome" + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudCustomActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudCustomActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override void Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // Add Code Here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudCorticonActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudCorticonActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override void Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // Add Code Here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudClickatellActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudClickatellActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override ClickatellMessage Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // Add Code Here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudPostageActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudPostageActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override PostageData Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // add your custom code here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.Email,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using System.Net.Mail;" + Environment.NewLine +
                          @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudEmailActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override MailMessage Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // add your custom code here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlCostingActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create function [cloudcore].[CCCost_{0}]" + Environment.NewLine +
                          @"(" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @")" + Environment.NewLine +
                          @"returns money" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    declare @Cost money" + Environment.NewLine + Environment.NewLine +
                          @"    -- return your cost here" + Environment.NewLine + Environment.NewLine +
                          @"    return @Cost" + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Type = FileType.CloudCostingActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudCostingActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override decimal Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // return your cost here" + Environment.NewLine +
                          @"             return 0;" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlBatchWaitActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create function [cloudcore].[CCBatchWait_{0}]" + Environment.NewLine +
                          @"(" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @")" + Environment.NewLine +
                          @"returns int" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    --Return 0 to continue or return park delay value in seconds" + Environment.NewLine +
                          @"    return 0" + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudBatchWaitActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudBatchWaitActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        // Used If there are still active child instances in the worklist" + Environment.NewLine +
                          @"        // Prevents unnecessary processing in worker role" + Environment.NewLine +
                          @"        public override int Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // Calculate delay accordingly (in minutes)" + Environment.NewLine +
                          @"             return 0;" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlBatchStartActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create procedure [cloudcore].[CCBatchStart_{0}]" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    -- return child instance data" + Environment.NewLine +
                          @"    -- the resultset columns must match the names below" + Environment.NewLine +
                          @"    -- Activate, DocWait, KeyValue, Priority" + Environment.NewLine + Environment.NewLine +
                          @"/*" + Environment.NewLine +
                          @"create table #BatchItems" + Environment.NewLine +
                          @"	(" + Environment.NewLine +
                          @"		[Activate] datetime default(getdate()),	" + Environment.NewLine +
                          @"        [DocWait] int default(0)," + Environment.NewLine +
                          @"        [KeyValue] bigint not null," + Environment.NewLine +
                          @"        [Priority] tinyint default(0)" + Environment.NewLine +
                          @"	)" + Environment.NewLine +
                          @"*/" + Environment.NewLine + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudBatchStartActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine +
                          @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using System;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudBatchStartActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override Guid ChildProcessActivityGuid" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"           get {{" + Environment.NewLine +
                          @"                   // return Activity Guid from Child Process's Activity here" + Environment.NewLine +
                          @"                   throw new NotImplementedException(); " + Environment.NewLine +
                          @"               }}" + Environment.NewLine +
                          @"        }}" + Environment.NewLine + Environment.NewLine +
                          @"        public override IEnumerable<ChildActivity> Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             throw new NotImplementedException();" + Environment.NewLine +
                          @"             // Add code here to retrieve activities to complete in batch" + Environment.NewLine + Environment.NewLine +
                          @"             // Return your IEnumerable<ChildActivity> here" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.CloudParkedActivity,
                FolderName = FolderName.Cloud,
                Extension = "cs",
                Content = @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.WorkflowActivities;" + Environment.NewLine + Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : CloudParkedActivity" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override int Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             // Return 0 to continue or return park delay value in seconds" + Environment.NewLine +
                          @"             return 0;" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            FilesTypes.Add(new GenerateFileType
            {
                Id = 0,
                Type = FileType.SqlParkedActivity,
                FolderName = FolderName.Sql,
                Extension = "sql",
                Content = @"create function [cloudcore].[CCPark_{0}]" + Environment.NewLine +
                          @"(" + Environment.NewLine +
                          @"    @InstanceId bigint," + Environment.NewLine +
                          @"    @KeyValue bigint" + Environment.NewLine +
                          @")" + Environment.NewLine +
                          @"returns int" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"  begin" + Environment.NewLine + Environment.NewLine +
                          @"    --Return 0 to continue or return park delay value in seconds" + Environment.NewLine +
                          @"    return 0" + Environment.NewLine +
                          @"  end" + Environment.NewLine
            });

            return FilesTypes;
        }
    }
}
