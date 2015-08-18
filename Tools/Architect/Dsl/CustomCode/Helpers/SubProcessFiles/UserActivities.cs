using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using System.Runtime.Serialization.Formatters.Binary;

namespace Architect.CustomCode.Helpers
{
    public partial class SubProcessFiles
    {
        public static void AddPage(Store store, string itemGuid, string subProcessGuid)
        {
            Project dteProject = getDteProject(store, "page");

            string defaultNamespace = dteProject.Properties.Item("DefaultNamespace").Value.ToString();

            var view = FileTypes.getFileType(FileType.View);
            var model = FileTypes.getFileType(FileType.PageModel);
            var controller = FileTypes.getFileType(FileType.Controller);

            #region Add View
            byte[] item = new UTF8Encoding(true).GetBytes(string.Format(view.Content, defaultNamespace, itemGuid.Replace("-", "_")));
            string fileName = string.Format("{0}.cshtml", itemGuid.Replace("-", "_"));

            AddProcessFile(dteProject, subProcessGuid, view.FolderName, fileName, item, true);
            #endregion

            #region Add Controller
            item = new UTF8Encoding(true).GetBytes(string.Format(controller.Content, defaultNamespace, subProcessGuid.Replace("-", "_"), itemGuid.Replace("-", "_")));
            fileName = string.Format("{0}Controller.cs", itemGuid.Replace("-", "_"));

            AddController(dteProject, controller.FolderName, fileName, item);
            #endregion

            #region Add Model
            item = new UTF8Encoding(true).GetBytes(string.Format(model.Content, itemGuid.Replace("-", "_"), defaultNamespace));
            fileName = string.Format("{0}Model.cs", itemGuid.Replace("-", "_"));

            AddProcessFile(dteProject, subProcessGuid, model.FolderName, fileName, item, true);
            #endregion
        }

        public static void OpenView(Store store, string itemGuid, string subProcessGuid)
        {
            Project dteProject = getDteProject(store, "page");
            var view = FileTypes.getFileType(FileType.View);
            string itemName = string.Format("{0}.cshtml", itemGuid.Replace("-", "_"));

            if (!CheckFileExists(dteProject, itemName, subProcessGuid, FolderName.Views, true))
            {
                AddPage(store, itemGuid, subProcessGuid);
            }

            OpenProcessFile(dteProject, itemName, view.FolderName, subProcessGuid, true);
        }

        public static void OpenModel(Store store, string itemGuid, string subProcessGuid)
        {
            Project dteProject = getDteProject(store, "page");
            var model = FileTypes.getFileType(FileType.PageModel);
            var itemName = string.Format("{0}Model.cs", itemGuid.Replace("-", "_"));

            if (CheckFileExists(dteProject, itemName, subProcessGuid, model.FolderName, true))
            {
                OpenProcessFile(dteProject, itemName, model.FolderName, subProcessGuid, true);
            }
        }

        public static void OpenController(Store store, string itemGuid, string subProcessGuid)
        {
            Project dteProject = getDteProject(store, "page");
            var controller = FileTypes.getFileType(FileType.Controller);
            var itemName = string.Format("{0}Controller.cs", itemGuid.Replace("-", "_"));

            if (ControllerExists(store, controller.FolderName, itemName))
            {
                OpenController(dteProject, controller.FolderName, itemName);
            }
        }

        public static void DeletePage(Store store, string itemGuid, string subProcessGuid)
        {
            Project dteProject = getDteProject(store, "page");

            string itemName = string.Format("{0}.cshtml", itemGuid.Replace("-", "_"));
            DeleteProcessFile(dteProject, itemName, FileTypes.getFileType(FileType.View).FolderName, subProcessGuid, true);

            itemName = string.Format("{0}Model.cs", itemGuid.Replace("-", "_"));
            DeleteProcessFile(dteProject, itemName, FileTypes.getFileType(FileType.PageModel).FolderName, subProcessGuid, true);

            itemName = string.Format("{0}Controller.cs", itemGuid.Replace("-", "_"));
            DeleteController(dteProject,FileTypes.getFileType(FileType.Controller).FolderName, itemName);
        }

        internal static bool ControllerExists(Store store, FolderName contentFolder, string itemName)
        {
            Project dteProject = getDteProject(store, "page");

            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));

            string itemPath = string.Format("{0}\\Areas\\{1}\\{2}\\_{3}", projectPath, rootFolder, contentFolder.ToString(), itemName);

            return File.Exists(itemPath);
        }

        internal static void AddController(Project dteProject, FolderName contentFolder, string itemName, byte[] content)
        {
            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));
            string itemPath = string.Format("{0}\\Areas\\{1}\\{2}\\_{3}", projectPath, rootFolder, contentFolder.ToString(), itemName);

            CreateDirectories(projectPath, "Areas");
            CreateDirectories(string.Format("{0}\\Areas\\{1}", projectPath, rootFolder), contentFolder.ToString());

            CheckoutFileIfRequired(dteProject.DTE, dteProject.FullName);
            CheckoutFileIfRequired(dteProject.DTE, itemPath);

            File.Create(itemPath).Write(content, 0, content.Length);

            dteProject.ProjectItems.AddFromFile(itemPath);
        }

        internal static void DeleteController(Project dteProject, FolderName contentFolder, string itemName)
        {
            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));

            string itemPath = string.Format("{0}\\Areas\\{1}\\{2}\\_{3}", projectPath, rootFolder, contentFolder.ToString(), itemName);

            dteProject.ProjectItems.
                        Item("Areas").ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(contentFolder.ToString()).ProjectItems.
                        Item("_" + itemName).Remove();

            if (dteProject.ProjectItems.Item("Areas").ProjectItems.Item(rootFolder).ProjectItems.Item(contentFolder.ToString())
                .ProjectItems.Count == 0)
            {
                dteProject.ProjectItems.
                        Item("Areas").ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(contentFolder.ToString()).Remove();
            }

            File.Delete(itemPath);
        }

        internal static void OpenController(Project dteProject, FolderName contentFolder, string itemName)
        {
            dteProject.ProjectItems.
                        Item("Areas").ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(contentFolder.ToString()).ProjectItems.
                        Item("_" + itemName).Open().Activate();
        }
    }
}