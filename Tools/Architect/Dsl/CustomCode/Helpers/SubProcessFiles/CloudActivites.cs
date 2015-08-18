using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using System.Linq;
using System.Text;

namespace Architect.CustomCode.Helpers
{
    public partial class SubProcessFiles
    {
        public static void AddClass(Store store, string itemGuid, string subProcessGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "cs");

            string defaultNamespace = dteProject.Properties.Item("DefaultNamespace").Value.ToString();
            // string projectPath = dteProject.FullName.Substring(0, dteProject.FullName.LastIndexOf("\\", System.StringComparison.Ordinal));
            string itemName = string.Format("{0}.cs", itemGuid.Replace("-", "_"));

            var itemContent = (FileTypes.GetList().Where(ft => ft.Type == itemType.Type)).Single();
            var item = new UTF8Encoding(true).GetBytes(string.Format(itemContent.Content, defaultNamespace, itemGuid.Replace("-", "_")));

            AddProcessFile(dteProject, subProcessGuid, itemType.FolderName, itemName, item);
        }

        public static void OpenClass(Store store, string itemGuid, string subProcessGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "cs");
            string itemName = string.Format("{0}.cs", itemGuid.Replace("-", "_"));

            if (!CheckFileExists(dteProject, itemName, subProcessGuid, itemType.FolderName))
            {
                AddClass(store, itemGuid, subProcessGuid, itemType);
            }

            OpenProcessFile(dteProject, itemName, itemType.FolderName, subProcessGuid);
        }

        public static void DeleteClass(Store store, string subProcessGuid, string itemGuid, GenerateFileType itemType)
        {
            Project dteProject = getDteProject(store, "cs");

            string itemName = string.Format("{0}.cs", itemGuid.Replace("-", "_"));

            DeleteProcessFile(dteProject, itemName, itemType.FolderName, subProcessGuid);
        }
    }
}
