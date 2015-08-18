using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Shell;
using Architect.Properties;
using EnvDTE80;
using System.Xml;

namespace Architect.CustomCode.Helpers
{
    public sealed class ArchitectDte
    {
        static _DTE _dte;
        static Project _Webproject;
        static Project _Workerproject;
        static Store _store;
        private IMonitorSelectionService _monitorSelection;
        static ArchitectDte instance = null;
        static readonly object padlock = new object();

        public Store Store
        {
            set { _store = value; }
        }

        public static ArchitectDte Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ArchitectDte();
                    }

                    return instance;
                }
            }
        }

        public static _DTE Dte
        {
            get
            {
                lock (padlock)
                {
                    if (_store == null)
                        return null;
                    return _dte ?? (_dte = _store.GetService(typeof(EnvDTE._DTE)) as EnvDTE._DTE);
                }
            }
        }

        public Project WebProject
        {
            get
            {
                lock (padlock)
                {
                    _Webproject = null;
                    List<Project> projects = new List<Project>();
                    List<Project> childProjects = new List<Project>();

                    Action<Project> GetChildProjects = project =>
                    {
                        try
                        {
                            for (int i = 1; i <= project.ProjectItems.Count; i++)
                            {
                                getChildItems(childProjects, project.ProjectItems.Item(i));
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    };

                    foreach (Project p in Dte.Solution.Projects)
                    {
                        projects.Add(p);
                    }

                    projects.ForEach(a => GetChildProjects(a));
                    projects.AddRange(childProjects);

                    var webModule = GetUniqueWebProject(WorkerProject).ToLower();

                    _Webproject = projects.SingleOrDefault(a => a.UniqueName.ToLower() == webModule);

                    if (_Webproject == null)
                    {
                        throw new Exception("A Web Project cannot be found!");
                    }

                    return _Webproject;
                }
            }
        }

        private static void getChildItems(List<Project> projects, ProjectItem projectItem)
        {
            if (projectItem.SubProject != null)
            {
                if (projectItem.SubProject.FileName == "")
                {
                    if (projectItem.SubProject.Kind == EnvDTE.Constants.vsProjectKindSolutionItems)
                    {
                        if (projectItem.SubProject.ProjectItems != null)
                        {
                            for (int i = 1; i <= projectItem.SubProject.ProjectItems.Count; i++)
                            {
                                getChildItems(projects, projectItem.SubProject.ProjectItems.Item(i));
                            }
                        }
                    }
                }
                else
                {
                    projects.Add(projectItem.SubProject);
                }
            }
        }

        public Project WorkerProject
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

                            return (Dte.ActiveSolutionProjects as Array).GetValue(0) as Project;
                        }

                        _Workerproject = Dte.ActiveDocument.ProjectItem.ContainingProject;
                    }
                    return _Workerproject;
                }
            }
        }

        public static string WebProjectPath
        {
            get
            {
                try
                {
                    Uri uri = new Uri(_Webproject.FileName.Substring(0, _Webproject.FullName.LastIndexOf("\\")));
                    return Path.GetDirectoryName(uri.LocalPath);
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string WorkerProjectPath
        {
            get
            {
                try
                {
                    Uri uri = new Uri(_Workerproject.FileName.Substring(0, _Workerproject.FullName.LastIndexOf("\\")));
                    return Path.GetDirectoryName(uri.LocalPath);
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Returns the model element currently selected in the diagram, or 
        /// null if a model element could not be determined.
        /// </summary>
        /// <returns></returns>
        public ModelElement GetDiagramSelectedModelElement()
        {
            ModelingDocView view = null;
            _monitorSelection = (IMonitorSelectionService)_store.GetService(typeof(IMonitorSelectionService));
            // We are only interested if the selection container is a ModelingDocView
            // (if it isn't, then the selected item isn't on a diagram).
            if (_monitorSelection != null)
                view = _monitorSelection.CurrentSelectionContainer as ModelingDocView;

            if (view == null)
            {
                return null;
            }

            // The primary selection could be a PresentationElement (e.g. if a geometry shape is selected)
            // or a ModelElement (e.g. if an item in a compartment is selected).

            // If a presentation element is selected, then get the selected model element
            ModelElement selectedElement;
            var newSelectedShape = view.PrimarySelection as ShapeElement;

            if (newSelectedShape != null)
            {
                selectedElement = newSelectedShape;
            }
            else
            {
                selectedElement = view.PrimarySelection as ModelElement;
            }

            return selectedElement;
        }

        private string GetUniqueWebProject(Project WorkerProject)
        {
            var pi = GetProjectProperty(WorkerProject, "WebModule");

            if (string.IsNullOrEmpty(pi))
            {
                throw new Exception("Web Module not set in Process Module.  Please make sure you set this in the Properties Page of the Process Module in the CloudCore Tab.");
            }

            return pi;
        }

        private static string GetProjectProperty(Project project, string property)
        {
            if (string.IsNullOrEmpty(project.FullName))
                return string.Empty;

            XmlDocument xmlDoc = new XmlDocument(); //* create an xml document object.
            xmlDoc.Load(project.FullName); //* load the XML document from the specified file.

            //* Get elements.
            XmlNodeList propertyNode = xmlDoc.GetElementsByTagName(property);

            if (propertyNode.Count == 0)
                return string.Empty;

            return propertyNode.Item(0).InnerText;
        }

        private static void EnsureUsingDirective(FileCodeModel2 fileCodeModel, string importName)
        {
            bool importNotFound = true;
            foreach (CodeElement ce in (fileCodeModel).CodeElements)
            {
                if (ce is CodeImport && ((CodeImport)ce).Namespace == importName)
                {
                    importNotFound = false;
                    break;
                }
            }

            if (importNotFound)
                fileCodeModel.AddImport(importName);
        }
    }
}