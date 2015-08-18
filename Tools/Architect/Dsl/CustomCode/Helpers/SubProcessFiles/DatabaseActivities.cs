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
        public static void AddSql(Store store, string itemGuid, string subProcessGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "sql");

            string defaultNamespace = dteProject.Properties.Item("DefaultNamespace").Value.ToString();

            //Set the new file name, assume you provide fileName for the new file somewhere
            var itemContent = string.Format(itemType.Content, itemGuid.Replace("-", "_"));
            var item = new UTF8Encoding(true).GetBytes(itemContent);
            var fileName = string.Format("{0}.sql", itemGuid.Replace("-", "_"));

            AddProcessFile(dteProject, subProcessGuid, itemType.FolderName, fileName, item);

            GenerateFileType classType = FileTypes.FilesTypes.Where(a => a.Type == FileType.ActivityPropertiesClass).SingleOrDefault();

            CreatePropertiesFile(store, itemGuid, subProcessGuid, " : " + itemType.Type.ToString());
        }

        public static void OpenSql(Store store, string itemGuid, string subProcessGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "sql");

            string itemName = string.Format("{0}.sql", itemGuid.Replace("-", "_"));

            if (!CheckFileExists(dteProject, itemName, subProcessGuid, itemType.FolderName))
            {
                AddSql(store, itemGuid, subProcessGuid, itemType);
            }

            OpenProcessFile(dteProject, itemName, itemType.FolderName, subProcessGuid);
        }

        public static void DeleteSQL(Store store, string itemGuid, string subProcessGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "sql");
            string itemName = string.Format("{0}.sql", itemGuid.Replace("-", "_"));
            DeleteProcessFile(dteProject, itemName, itemType.FolderName, subProcessGuid);

            GenerateFileType classType = FileTypes.FilesTypes.Where(a => a.Type == FileType.ActivityPropertiesClass).SingleOrDefault();
            itemName = string.Format("{0}.cs", itemGuid.Replace("-", "_"));
            DeleteProcessFile(dteProject, itemName, classType.FolderName, subProcessGuid);
        }
    }
}
