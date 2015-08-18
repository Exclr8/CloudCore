using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace Architect.CustomCode.Helpers
{
    public partial class SubProcessFiles
    {
        private const string rootFolder = "Activities";

        private static Action<String> _checkOutAction;

        private static Project getDteProject(Store store, string fileType)
        {
            Project dteProject = null;

            ArchitectDte dte = ArchitectDte.Instance;
            dte.Store = store;

            switch (fileType)
            {
                case "sql":
                    dteProject = dte.WorkerProject;
                    break;
                case "cs":
                    dteProject = dte.WorkerProject;
                    break;
                case "page":
                    dteProject = dte.WebProject;
                    break;
            }

            return dteProject;
        }

        private static void CheckoutFileIfRequired(_DTE dte, String fileName)
        {
            _checkOutAction = (String fn) => dte.SourceControl.CheckOutItem(fn);

            var sc = dte.SourceControl;
            if (sc != null && sc.IsItemUnderSCC(fileName) && !sc.IsItemCheckedOut(fileName))
                _checkOutAction.EndInvoke(_checkOutAction.BeginInvoke(fileName, null, null));
        }

        private static void CreateDirectories(string projectPath, string folderName)
        {
            //Create process folder if not exist
            if (!Directory.Exists(projectPath))
                Directory.CreateDirectory(projectPath);

            string subFolder = string.Format("{0}\\{1}", projectPath, folderName);

            //Create folder if not exist
            if (!Directory.Exists(subFolder))
                Directory.CreateDirectory(subFolder);
        }

        internal static bool CheckFileExists(Project dteProject, string itemName, string subProcessGuid, FolderName itemFolder, bool IsUserItem = false)
        {
            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));
            string guidFolder = "_" + subProcessGuid.Replace("-", "_");
            string itemPath = "";

            itemPath = itemPath = getFullPath("_" + itemName, itemFolder, guidFolder, projectPath, IsUserItem);

            return File.Exists(itemPath);
        }

        internal static void AddProcessFile(Project dteProject, string subProcessGuid, FolderName itemFolder, string itemName, byte[] content, bool IsUserItem = false)
        {
            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));
            string guidFolder = "_" + subProcessGuid.Replace("-", "_");
            string itemPath = "";

            itemPath = getFullPath("_" + itemName, itemFolder, guidFolder, projectPath, IsUserItem);

            if (IsUserItem)
            {
                CreateDirectories(projectPath, "Areas");
                CreateDirectories(string.Format("{0}\\Areas\\{1}", projectPath, rootFolder), itemFolder.ToString());
                CreateDirectories(string.Format("{0}\\Areas\\{1}\\{2}", projectPath, rootFolder, itemFolder.ToString()), guidFolder);
            }
            else
            {
                CreateDirectories(projectPath, rootFolder);
                CreateDirectories(string.Format("{0}\\{1}\\{2}", projectPath, rootFolder, guidFolder), itemFolder.ToString());
            }

            CheckoutFileIfRequired(dteProject.DTE, dteProject.FullName);
            CheckoutFileIfRequired(dteProject.DTE, itemPath);

            File.Create(itemPath).Write(content, 0, content.Length);

            dteProject.ProjectItems.AddFromFile(itemPath);
        }

        internal static void OpenProcessFile(Project dteProject, string itemName, FolderName itemFolder, string subProcessGuid, bool IsUserItem = false)
        {
            string guidFolder = "_" + subProcessGuid.Replace("-", "_");
            if (IsUserItem)
            {
                dteProject.ProjectItems.
                        Item("Areas").ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(itemFolder.ToString()).ProjectItems.
                        Item(guidFolder).ProjectItems.
                        Item("_" + itemName).Open().Activate();
            }
            else
            {
                dteProject.ProjectItems.Item(rootFolder).ProjectItems.Item(guidFolder).ProjectItems.Item(itemFolder.ToString()).ProjectItems
                    .Item("_" + itemName).Open().Activate();
            }
        }

        internal static void DeleteProcessFile(Project dteProject, string itemName, FolderName itemFolder, string subProcessGuid, bool IsUserItem = false)
        {
            string guidFolder = "_" + subProcessGuid.Replace("-", "_");
            string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\"));
            string fileFullPath = "";

            try
            {
                if (IsUserItem)
                {
                    dteProject.ProjectItems.Item("Areas").ProjectItems.Item(rootFolder).ProjectItems.Item(itemFolder.ToString()).ProjectItems.Item(guidFolder).ProjectItems.
                        Item("_" + itemName).Remove();

                    if (dteProject.ProjectItems.Item("Areas").ProjectItems.Item(rootFolder).ProjectItems.Item(itemFolder.ToString()).ProjectItems.
                        Item(guidFolder).ProjectItems.Count == 0)
                    {
                        dteProject.ProjectItems.
                        Item("Areas").ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(itemFolder.ToString()).ProjectItems.
                        Item(guidFolder).Remove();

                        if (dteProject.ProjectItems.Item("Areas").ProjectItems.Item(rootFolder).ProjectItems.Item(itemFolder.ToString()).ProjectItems.Count == 0)
                        {
                            dteProject.ProjectItems.
                            Item("Areas").ProjectItems.
                            Item(rootFolder).ProjectItems.
                            Item(itemFolder.ToString()).Remove();

                            if (dteProject.ProjectItems.Item("Areas").ProjectItems.Item(rootFolder).ProjectItems.Count == 0)
                            {
                                dteProject.ProjectItems.
                                Item("Areas").ProjectItems.
                                Item(rootFolder).Remove();
                            }
                        }
                    }
                }
                else
                {
                    dteProject.ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(guidFolder).ProjectItems.
                        Item(itemFolder.ToString()).ProjectItems.
                        Item("_" + itemName).Remove();

                    if (dteProject.ProjectItems.Item(rootFolder).ProjectItems.Item(guidFolder).ProjectItems.
                        Item(itemFolder.ToString()).ProjectItems.Count == 0)
                    {
                        dteProject.ProjectItems.
                        Item(rootFolder).ProjectItems.
                        Item(guidFolder).ProjectItems.
                        Item(itemFolder.ToString()).Remove();

                        if (dteProject.ProjectItems.Item(rootFolder).ProjectItems.Item(guidFolder).ProjectItems.Count == 0)
                        {
                            dteProject.ProjectItems.
                            Item(rootFolder).ProjectItems.
                            Item(guidFolder).Remove();
                        }
                    }
                }

            }
            catch (Exception)
            { }

            fileFullPath = getFullPath("_" + itemName, itemFolder, guidFolder, projectPath, IsUserItem);

            FileInfo file = new FileInfo(fileFullPath);

            //Delete the files if exist
            if (file.Exists)
            {
                CheckoutFileIfRequired(dteProject.DTE, dteProject.FullName);
                CheckoutFileIfRequired(dteProject.DTE, file.FullName);
                file.Delete();

                if (file.Directory.GetFiles().Count() == 0 && file.Directory.GetDirectories().Count() == 0)
                {
                    file.Directory.Delete();

                    if (file.Directory.Parent.GetFiles().Count() == 0 && file.Directory.Parent.GetDirectories().Count() == 0)
                    {
                        file.Directory.Parent.Delete();
                    }
                }
            }

            
        }

        private static string getFullPath(string itemName, FolderName itemFolder, string guidFolder, string projectPath, bool IsUserItem)
        {
            if (IsUserItem)
            {
                return string.Format("{0}\\Areas\\{1}\\{3}\\{2}\\{4}", projectPath, rootFolder, guidFolder, itemFolder.ToString(), itemName);
            }
            else
            {
                return string.Format("{0}\\{1}\\{2}\\{3}\\{4}", projectPath, rootFolder, guidFolder, itemFolder.ToString(), itemName);
            }
        }

        public static void CreatePropertiesFile(Store store, string itemGuid, string subProcessGuid, string baseActivityClass, List<KeyValuePair<PropertyInfo, object>> properties = null)
        {
            GenerateFileType classType = FileTypes.FilesTypes.Where(a => a.Type == FileType.ActivityPropertiesClass).SingleOrDefault();
            Project dteProject = getDteProject(store, "sql");
            string defaultNamespace = dteProject.Properties.Item("DefaultNamespace").Value.ToString();
            var propertyCode = (properties == null) ? string.Empty : GeneratePropertyCode(properties);
            var itemContent = string.Format(classType.Content, defaultNamespace, itemGuid.Replace("-", "_"), baseActivityClass, propertyCode);
            var item = new UTF8Encoding(true).GetBytes(itemContent);
            var fileName = string.Format("{0}.cs", itemGuid.Replace("-", "_"));

            DeleteProcessFile(dteProject, fileName, classType.FolderName, subProcessGuid);

            AddProcessFile(dteProject, subProcessGuid, classType.FolderName, fileName, item);
        }

        public static List<KeyValuePair<PropertyInfo, object>> GetModelElementProperties(ModelElement element, params string[] propertyNames)
        {
            var modelElementType = element.GetType();
            var properties = new List<KeyValuePair<PropertyInfo, object>>();

            for (int i = 0; i < propertyNames.Count(); i++)
            {
                var property = modelElementType.GetProperties().FirstOrDefault(p => p.Name == propertyNames[i]);

                properties.Add(new KeyValuePair<PropertyInfo, object>(property, property.GetValue(element)));
            }

            return properties;
        }

        public static string GeneratePropertyCode(List<KeyValuePair<PropertyInfo, object>> properties)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in properties)
            {
                stringBuilder.Append(string.Format(@"public {0} {1} {{ get {{ return {2}; }} }}{3}"
                                                    , item.Key.PropertyType.Name
                                                    , item.Key.Name
                                                    , GenerateGetValue(item)
                                                    , Environment.NewLine));
            }

            return stringBuilder.ToString();

        }

        private static string GenerateGetValue(KeyValuePair<PropertyInfo, object> propertyValue)
        {
            switch (propertyValue.Key.PropertyType.Name)
            {
                case "Guid":
                    return string.Format(@"new Guid(""{0}"")", propertyValue.Value);
                default:
                    return propertyValue.Value.ToString();
            }
        }
    }
}