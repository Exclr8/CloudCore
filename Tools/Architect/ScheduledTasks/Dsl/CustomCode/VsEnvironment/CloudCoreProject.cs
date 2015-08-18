using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Architect.ScheduledTasks.Files;
using System.IO;
using EnvDTE80;

namespace Architect.ScheduledTasks.VsEnvironment
{
    public sealed class CloudCoreProject
    {
        private Project _BaseProject = null;

        public CloudCoreProject(Project baseProject)
        {
            _BaseProject = baseProject;
        }

        public string Path
        {
            get
            {
                try
                {
                    return _BaseProject.FileName.Substring(0, _BaseProject.FullName.LastIndexOf("\\"));
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string Name
        {
            get
            {
                return _BaseProject.Name;
            }
        }

        public string FileName
        {
            get
            {
                return _BaseProject.FileName;
            }
        }

        public string FullName
        {
            get
            {
                return _BaseProject.FullName;
            }
        }

        public void AddClass(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string taskGuidString = scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
            string groupGuidString = groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);

            string defaultNamespace = _BaseProject.Properties.Item("DefaultNamespace").Value.ToString();
            var basePath = _BaseProject.FullName.Substring(0, _BaseProject.FullName.LastIndexOf("\\") + 1) + @"Scheduled Tasks";

            var defaultContent = FileTypes.FilesTypes.Where(ft => ft.Type == TaskFileType.CSharp).SingleOrDefault().DefaultContent;

            defaultContent = string.Format(defaultContent, defaultNamespace, taskGuidString.Replace("-", "_"));

            var itemPath = string.Format("{0}\\_{1}\\_{2}.cs", basePath, groupGuidString.Replace("-", "_"), taskGuidString.Replace("-", "_"));
            var fileContent = new UTF8Encoding(true).GetBytes(defaultContent);

            var fileToAdd = new FileInfo(itemPath);

            AddFileIfNotExists(fileToAdd, fileContent);
        }

        public void AddSql(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string taskGuidString = scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
            string groupGuidString = groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);

            var basePath = _BaseProject.FullName.Substring(0, _BaseProject.FullName.LastIndexOf("\\") + 1) + @"Scheduled Tasks\sql";

            var defaultContent = FileTypes.FilesTypes.Where(ft => ft.Type == TaskFileType.Sql).SingleOrDefault().DefaultContent;

            defaultContent = string.Format(defaultContent, taskGuidString.Replace("-", "_"));

            var itemPath = string.Format("{0}\\_{1}\\_{2}.sql", basePath, groupGuidString.Replace("-", "_"), taskGuidString.Replace("-", "_"));
            var fileContent = new UTF8Encoding(true).GetBytes(defaultContent);

            var fileToAdd = new FileInfo(itemPath);

            AddFileIfNotExists(fileToAdd, fileContent);
        }
        
        private void AddFileIfNotExists(FileInfo fileToAdd, byte[] content)
        {
            if (!fileToAdd.Exists)
            {
                fileToAdd.Directory.Create();
                File.Create(fileToAdd.FullName).Write(content, 0, content.Length);
            }

            CheckoutFileIfRequired(_BaseProject.FullName);
            CheckoutFileIfRequired(fileToAdd.FullName);

            ProjectItem scheduleTaskProjectItem = null;

            try
            {
                scheduleTaskProjectItem = _BaseProject.ProjectItems.Item(fileToAdd.Name);
            }
            catch { }

            if (scheduleTaskProjectItem == null)
            {
                _BaseProject.ProjectItems.AddFromFile(fileToAdd.FullName);
            }
        }

        public void OpenSql(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string taskGuidString = scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
            string groupGuidString = groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);

            var basePath = _BaseProject.FullName.Substring(0, _BaseProject.FullName.LastIndexOf("\\") + 1) + @"Scheduled Tasks\sql";

            var defaultContent = FileTypes.FilesTypes.Where(ft => ft.Type == TaskFileType.Sql).SingleOrDefault().DefaultContent;

            defaultContent = string.Format(defaultContent, taskGuidString.Replace("-", "_"));

            string groupFolderName = "_" + groupGuidString.Replace("-", "_");

            var itemPath = string.Format("{0}\\{1}\\_{2}.sql", basePath, groupFolderName, taskGuidString.Replace("-", "_"));
            var fileContent = new UTF8Encoding(true).GetBytes(defaultContent);

            var fileToOpen = new FileInfo(itemPath);

            AddFileIfNotExists(fileToOpen, fileContent);

            OpenFile(fileToOpen.Name, groupFolderName, TaskType.SQL);
        }

        public void OpenClass(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string taskGuidString = scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
            string groupGuidString = groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty);

            var basePath = _BaseProject.FullName.Substring(0, _BaseProject.FullName.LastIndexOf("\\") + 1) + @"Scheduled Tasks";

            string defaultNamespace = _BaseProject.Properties.Item("DefaultNamespace").Value.ToString();
            var defaultContent = FileTypes.FilesTypes.Where(ft => ft.Type == TaskFileType.CSharp).SingleOrDefault().DefaultContent;

            defaultContent = string.Format(defaultContent, defaultNamespace, taskGuidString.Replace("-", "_"));

            string groupFolderName = "_" + groupGuidString.Replace("-", "_");

            var itemPath = string.Format("{0}\\{1}\\_{2}.cs", basePath, groupFolderName, taskGuidString.Replace("-", "_"));
            var fileContent = new UTF8Encoding(true).GetBytes(defaultContent);

            var fileToOpen = new FileInfo(itemPath);

            AddFileIfNotExists(fileToOpen, fileContent);

            OpenFile(fileToOpen.Name, groupFolderName, TaskType.CSharp);
        }

        private void OpenFile(string scheduledTaskFileName, string groupFolderName, TaskType taskType)
        {
            if (taskType == TaskType.SQL)
                _BaseProject.ProjectItems.
                    Item("Scheduled Tasks").ProjectItems.
                    Item("sql").ProjectItems.
                    Item(groupFolderName).ProjectItems.
                    Item(scheduledTaskFileName).Open().Activate();
            else
                _BaseProject.ProjectItems.
                    Item("Scheduled Tasks").ProjectItems.
                    Item(groupFolderName).ProjectItems.
                    Item(scheduledTaskFileName).Open().Activate();
        }

        private void CheckoutFileIfRequired(String fileName)
        {
            SourceControl sourceControl = _BaseProject.DTE.SourceControl;

            Action<String> _checkOutAction = (String fn) => sourceControl.CheckOutItem(fn);

            if (sourceControl != null && sourceControl.IsItemUnderSCC(fileName) && !sourceControl.IsItemCheckedOut(fileName))
                _checkOutAction.EndInvoke(_checkOutAction.BeginInvoke(fileName, null, null));
        }

        internal void RemoveClass(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string scheduledTaskFileName = "_" + scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_") + ".cs";
            string groupFolderName = "_" + groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_");

            DeleteFile(scheduledTaskFileName, groupFolderName, TaskType.CSharp);
        }

        internal void RemoveSql(Guid scheduledTaskGuid, Guid groupGuid)
        {
            string scheduledTaskFileName = "_" + scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_") + ".sql";
            string groupFolderName = "_" + groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_");

            DeleteFile(scheduledTaskFileName, groupFolderName, TaskType.SQL);
        }

        private void DeleteFile(string scheduledTaskFileName, string groupFolderName, TaskType taskType)
        {
            string projectPath = this.Path;
            string groupFolderPath = string.Format("{0}\\Scheduled Tasks\\{1}\\{2}", projectPath, (taskType == TaskType.SQL) ? "sql" : string.Empty, groupFolderName);
            string filePath = string.Format("{0}\\{1}", groupFolderPath, scheduledTaskFileName);

            CheckoutAndDeleteFileIfExists(filePath);
            DeleteGroupFolderIfNoFilesExist(groupFolderPath);

            try
            {
                RemoveScheduledTaskItemAndFolderFromProject(scheduledTaskFileName, taskType, groupFolderName);
            }
            catch (Exception)
            {
                return;
            }
        }
        
        #region Helper Methods

            private static void DeleteGroupFolderIfNoFilesExist(string groupFolderPath)
            {
                if (Directory.Exists(groupFolderPath))
                {
                    var noGroupFilesExist = Directory.EnumerateFiles(groupFolderPath).Count() == 0;

                    if (noGroupFilesExist)
                    {
                        Directory.Delete(groupFolderPath);
                    }
                }
            }

            private void CheckoutAndDeleteFileIfExists(string filePath)
            {
                if (File.Exists(filePath))
                {
                    CheckoutFileIfRequired(_BaseProject.FullName);
                    CheckoutFileIfRequired(filePath);
                    File.Delete(filePath);
                }
            }

            private void RemoveScheduledTaskItemAndFolderFromProject(string scheduledTaskFileName, TaskType taskType, string groupFolderName)
            {
                var ScheduleTaskProjectItem = _BaseProject.ProjectItems.Item("Scheduled Tasks");
                var scheduledTasksProjectItems = ScheduleTaskProjectItem.ProjectItems;
                ProjectItems groupFolderFileItems = null;

                switch (taskType)
                {
                    case TaskType.SQL: groupFolderFileItems = GetSqlFileItems(groupFolderName, scheduledTasksProjectItems);
                        break;
                    case TaskType.CSharp: groupFolderFileItems = GetCSharpFileItems(groupFolderName, scheduledTasksProjectItems);
                        break;
                }

                if (groupFolderFileItems.Count == 0 || groupFolderFileItems == null)
                    return;

                groupFolderFileItems.Item(scheduledTaskFileName).Remove();

                 if (groupFolderFileItems.Count == 0)
                    ((ProjectItem)groupFolderFileItems.Parent).Remove();

            }

            private static ProjectItems GetCSharpFileItems(string groupFolderName, ProjectItems scheduledTasksProjectItems)
            {
                ProjectItems groupFolderFileItems;
                ProjectItem groupFolder = GetGroupFolder(groupFolderName, scheduledTasksProjectItems);

                groupFolderFileItems = groupFolder.ProjectItems;

                return groupFolderFileItems;
            }

            private static ProjectItems GetSqlFileItems(string groupFolderName, ProjectItems scheduledTasksProjectItems)
            {
                ProjectItems groupFolderFileItems;
                ProjectItem groupFolder = GetGroupFolder(groupFolderName, scheduledTasksProjectItems.Item("sql").ProjectItems);

                groupFolderFileItems = groupFolder.ProjectItems;

                return groupFolderFileItems;
            }

            private static ProjectItem GetGroupFolder(string groupFolderName, ProjectItems ProjectItems)
            {
                ProjectItem groupFolder = ProjectItems.Item(groupFolderName);

                if (groupFolder == null)
                    throw new Exception(string.Empty);

                return groupFolder;
            }

        #endregion
    }
}
