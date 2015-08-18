using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE80;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using System.Reflection;
using System.IO;
using Architect.ScheduledTasks.Properties;

namespace Architect.ScheduledTasks.VsEnvironment
{
    public sealed class ScheduledTaskDte
    {
        private _DTE _dte;
        private DTE2 _dte2;
        private Store _store;

        private readonly object padlock = new object();

        private CloudCoreProject _DiagramContainerProject = null;
        private CloudCoreProject _ActionLibraryProject = null;

        public ScheduledTaskDte(Store store)
        {
            _store = store;
            _DiagramContainerProject = DiagramContainerProject;
        }

        public _DTE Dte
        {
            get
            {
                lock (padlock)
                {
                    if (_store == null)
                        return null;

                    return _dte ?? (_dte = _store.GetService(typeof(_DTE)) as _DTE);
                }
            }
        }

        public DTE2 Dte2
        {
            get
            {
                lock (padlock)
                {
                    if (_store == null)
                        return null;

                    return _dte2 ?? (_dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0"));
                }
            }
        }

        public CloudCoreProject DiagramContainerProject
        {
            get
            {
                lock (padlock)
                {
                    if (Dte != null)
                    {
                        if (Dte.ActiveDocument == null)
                        {
                            if (Dte.ActiveSolutionProjects == null)
                            {
                                return null;
                            }

                            return new CloudCoreProject((Dte.ActiveSolutionProjects as Array).GetValue(0) as Project);
                        }

                        _ActionLibraryProject = new CloudCoreProject(Dte.ActiveDocument.ProjectItem.ContainingProject);
                    }
                    return _ActionLibraryProject;
                }
            }
        }

        public static string[] GetStoreProcedureDrop(Guid scheduledTaskGuid, Project dteProject) 
        {
            var cc = new CloudCoreProject(dteProject);
            var sTaskGuid = scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_");
            var sTaskStoreProcedureName = string.Format(@"[cloudcore].[CCScheduledTask_{0}]", sTaskGuid);
            var retString = string.Format("IF OBJECTPROPERTY(object_id('{0}'), N'IsProcedure') = 1\" + Environment.NewLine + \"BEGIN\" + Environment.NewLine + \"DROP PROCEDURE {0}\" + Environment.NewLine + \"END \"+ Environment.NewLine", sTaskStoreProcedureName).Split('\n');
            return retString;
        }

        public static string[] GetSqlFileContent(string scheduledTaskName, Guid scheduledTaskGuid, Guid groupGuid, Project dteProject)
        {
            string groupFolderName = "_" + groupGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_");
            string scheduledTaskFileName = "_" + scheduledTaskGuid.ToString().Replace("{", string.Empty).Replace("}", string.Empty).Replace("-", "_") + ".sql";

            ProjectItem scheduledTaskProjectItem = dteProject.ProjectItems.Item("Scheduled Tasks").ProjectItems.
                Item("sql").ProjectItems.
                Item(groupFolderName).ProjectItems.
                Item(scheduledTaskFileName);

            EnvDTE.TextDocument textDocument = (EnvDTE.TextDocument)scheduledTaskProjectItem.Open().Document.Object("TextDocument");
            EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
            string[] lines = editPoint.GetText(textDocument.EndPoint).Replace("\"", "\"\"").Replace("\r", string.Empty).Split('\n');

            for (int lineIndex = 0; lineIndex < lines.Count(); lineIndex++)
            {
                string line = lines[lineIndex];

                //if (lineIndex > 0 && lineIndex <= lines.Count() - 1)
                if (lineIndex <= lines.Count() - 1)
                {
                    line = "                                                            \"" + line;
                }

               line = line + "\" + Environment.NewLine";

                if (lineIndex < lines.Count() - 1)
                {
                    line = line + "+";
                }

                lines[lineIndex] = line;
            }

            if (lines.Count() == 0)
            {
                throw new Exception(string.Format("The sql script for Scheduled Task \"{0}\" is empty.", scheduledTaskName));
            }

            return lines;
        }

    }
}
