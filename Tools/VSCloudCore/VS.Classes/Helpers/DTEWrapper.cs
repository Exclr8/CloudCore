using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data.Linq;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using VSLangProj;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using Microsoft.VisualStudio.Shell.Interop;

namespace CloudCore.VSExtension.Classes.Helpers
{
    public class DTEWrapper
    {
        public static DTE GetDTE()
        {
            return Package.GetGlobalService(typeof(DTE)) as DTE;
        }

        public static IVsSolution GetSolution()
        {
            return Package.GetGlobalService(typeof(SVsSolution)) as IVsSolution;
        }

        internal static Project GetActiveProject(DTE dte)
        {
            Project activeProject = null;

            Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
            if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
            {
                activeProject = activeSolutionProjects.GetValue(0) as Project;
            }

            return activeProject;
        }

        internal static Project GetActiveProject()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            return GetActiveProject(dte);
        }

        public static List<string> GetAllReferencesEx()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            List<string> refList = new List<string>();
            Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
            if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
            {
                for (int i = 0; i < activeSolutionProjects.Length; i++)
			    {
		          	Project activeProject = activeSolutionProjects.GetValue(i) as Project;
                    VSProject vsItem = activeProject.Object as VSProject;
                    if (vsItem != null)
                    {
                        foreach (Reference refItem in vsItem.References)
                        {
                            if (!refList.Exists(r => r == refItem.Path))
                                refList.Add(refItem.Path);
                        }
                    }
			    }

            }
            return refList;
        }

        public static List<string> GetAllReferences()
        {
            List<string> refList = new List<string>();
            
            EnvDTE.Project project = GetDTE().Solution.Projects.Item(1);

            foreach (Project projItem in GetProjectsFromSolution(GetSolution(), project.UniqueName, string.Format(@"{{{0}}}", GuidList.CSharpString)))
            {
                //         refList.Add( projItem.Properties.Item("FullPath").Value.ToString() );
                VSProject vsItem = projItem.Object as VSProject;

                if (vsItem != null)
                {

                    foreach (Reference refItem in vsItem.References)
                    {
                        if (!refList.Exists(r => r == refItem.Path))
                            refList.Add(refItem.Path);
                    }
                }
            }
            return refList;
        }

        

        public static Project[] GetProjectsFromSolution(IVsSolution solution, string pUniqueName, string projectKind)
        {
            List<Project> projects = new List<Project>();
            if (solution == null)
            {
                return projects.ToArray();
            }
            IEnumHierarchies ppEnum;
            Guid tempGuid = Guid.Empty;
            solution.GetProjectEnum((uint)Microsoft.VisualStudio.Shell.Interop.__VSENUMPROJFLAGS.EPF_ALLPROJECTS, ref tempGuid, out ppEnum);
            if (ppEnum != null)
            {
                uint actualResult = 0;
                IVsHierarchy hierarchy;
                solution.GetProjectOfUniqueName(pUniqueName, out hierarchy);
                IVsHierarchy[] nodes = new IVsHierarchy[1];
                nodes[0] = hierarchy;
                while (0 == ppEnum.Next(1, nodes, out actualResult))
                {
                    Object obj;
                    nodes[0].GetProperty((uint)Microsoft.VisualStudio.VSConstants.VSITEMID_ROOT, (int)Microsoft.VisualStudio.Shell.Interop.__VSHPROPID.VSHPROPID_ExtObject, out obj);
                    Project project = obj as Project;
                    if (project != null)
                    {
                        if (string.IsNullOrEmpty(projectKind))
                        {
                            projects.Add(project);
                        }
                        else if (projectKind.Equals(project.Kind, StringComparison.InvariantCultureIgnoreCase))
                        {
                            projects.Add(project);
                        }
                    }
                }
            }
            return projects.ToArray();
        }

        

        public static List<string> GetProjectTypeGuids(EnvDTE.Project proj)
        {

            string projectTypeGuids = "";
            IVsHierarchy hierarchy = null;
            int result = 0;

            object service = GetService(proj.DTE, typeof(Microsoft.VisualStudio.Shell.Interop.IVsSolution));
            IVsSolution solution = (Microsoft.VisualStudio.Shell.Interop.IVsSolution)service;

            result = solution.GetProjectOfUniqueName(proj.UniqueName, out hierarchy);

            if (result == 0)
            {
                IVsAggregatableProject aggregatableProject = (IVsAggregatableProject)hierarchy;
                result = aggregatableProject.GetAggregateProjectTypeGuids(out projectTypeGuids);
            }

            return projectTypeGuids.Split(';').ToList();

        }

        private static object GetService(object serviceProvider, System.Type type)
        {
            return GetService(serviceProvider, type.GUID);
        }

        private static object GetService(object serviceProviderObject, System.Guid guid)
        {

            object service = null;
            Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider = null;
            IntPtr serviceIntPtr;
            int hr = 0;
            Guid SIDGuid;
            Guid IIDGuid;

            SIDGuid = guid;
            IIDGuid = SIDGuid;
            serviceProvider = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)serviceProviderObject;
            hr = serviceProvider.QueryService(ref SIDGuid, ref IIDGuid, out serviceIntPtr);

            if (hr != 0)
            {
                System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(hr);
            }
            else if (!serviceIntPtr.Equals(IntPtr.Zero))
            {
                service = System.Runtime.InteropServices.Marshal.GetObjectForIUnknown(serviceIntPtr);
                System.Runtime.InteropServices.Marshal.Release(serviceIntPtr);
            }

            return service;
        }
    }
}
