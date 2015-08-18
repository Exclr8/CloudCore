using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.ScheduledTasks.Files
{
    public enum TaskFileType
    {
        Sql = 0,
        CSharp = 1
    }

    public class FileType
    {
        public TaskFileType Type { get; set; }
        public string Extension { get; set; }
        public string DefaultContent { get; set; }
    }

    public static class FileTypes
    {
        private static List<FileType> _FileTypes = null;
        public static List<FileType> FilesTypes
        {
            get
            {
                if (_FileTypes == null)
                    _FileTypes = GetList();

                return _FileTypes;
            }
        }

        private static List<FileType> GetList()
        {
            List<FileType> fileTypes = new List<FileType>();

            fileTypes.Add(new FileType
            {
                Type = TaskFileType.Sql,
                Extension = "sql",
                DefaultContent = @"create procedure [cloudcore].[CCScheduledTask_{0}]" + Environment.NewLine +
                          @"as" + Environment.NewLine +
                          @"begin" + Environment.NewLine + Environment.NewLine +
                          @"      raiserror('Not implemented', 16, 1)" + Environment.NewLine +
                          @"end" + Environment.NewLine
            });

            fileTypes.Add(new FileType
            {
                Type = TaskFileType.CSharp,
                Extension = "cs",
                DefaultContent = @"using System;" + Environment.NewLine +
                          @"using System.Collections.Generic;" + Environment.NewLine +
                          @"using System.Linq;" + Environment.NewLine +
                          @"using CloudCore.Core.VirtualWorker.InstantiatedTasks.ScheduledTasks;" + Environment.NewLine + 
                          Environment.NewLine +
                          @"namespace {0}" + Environment.NewLine +
                          @"{{" + Environment.NewLine +
                          @"    public partial class _{1} : ScheduledTask" + Environment.NewLine +
                          @"    {{" + Environment.NewLine +
                          @"        public override void Execute()" + Environment.NewLine +
                          @"        {{" + Environment.NewLine +
                          @"             throw new NotImplementedException();" + Environment.NewLine +
                          @"        }}" + Environment.NewLine +
                          @"    }}" + Environment.NewLine +
                          @"}}"
            });

            return fileTypes;
        }
    }
}
