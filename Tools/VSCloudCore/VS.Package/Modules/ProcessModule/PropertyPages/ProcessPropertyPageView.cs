/****************************** Module Header ******************************\
 * Module Name:  CustomPropertyPageView.cs
 * Project:      CSVSXProjectSubType
 * Copyright (c) Microsoft Corporation.
 * 
 * The CustomPropertyPageView Class inherits the PageView Class and overrides 
 * the PropertyControlTable Property, to which this class adds two Property 
 * Name / Control KeyValuePairs. For more detailed description, see the 
 * PageView Class.
 * 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Runtime.InteropServices;
using CloudCore.VSExtension.PropertyPages.Base;
using CloudCore.VSExtension.Classes.Helpers;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;


namespace CloudCore.VSExtension.ProcessProperties
{
    [Guid(GuidList.guidProcessModule_PV_String)]
    partial class ProcessPropertyPageView : PageView
    {

        internal class ItemProject
        {
            public string Name { get; set; }
            public string UniqueName { get; set; }
        }

        #region Constructors
        /// <summary>
        /// This is the runtime constructor.
        /// </summary>
        /// <param name="site">Site for the page.</param>
        public ProcessPropertyPageView(IPageViewSite site)
            : base(site)
        {
            InitializeComponent();
        }
        /// <summary>
        /// This constructor is only to enable winform designers
        /// </summary>
        public ProcessPropertyPageView()
        {
            InitializeComponent();
        }
        #endregion

        private PropertyControlTable propertyControlTable;

        /// <summary>
        /// This property is used to map the control on a PageView object to a property
        /// in PropertyStore object.
        /// 
        /// This property will be called in the base class's constructor, which means that
        /// the InitializeComponent has not been called and the Controls have not been
        /// initialized.
        /// </summary>
        protected override PropertyControlTable PropertyControlTable
        {
            get
            {
                if (propertyControlTable == null)
                {
                    // This is the list of properties that will be persisted and their
                    // assciation to the controls.
                    propertyControlTable = new PropertyControlTable();

                    // This means that this CustomPropertyPageView object has not been
                    // initialized.
                    if (string.IsNullOrEmpty(base.Name))
                    {
                        this.InitializeComponent();
                    }

                    // Add two Property Name / Control KeyValuePairs. 
                    propertyControlTable.Add("WebModule", cmbWebModules);

                    try
                    {
                        BindAllControlsData();
                    }
                    catch (Exception)
                    {
                        throw;
                        //DTEWrapper.GetDTE().ActiveWindow.Close();
                    }
                }

                return propertyControlTable;
            }
        }

        private void BindAllControlsData()
        {
            FillWebModuleDropDown();
        }

        private void FillWebModuleDropDown()
        {
            IVsSolution vsSolution = Package.GetGlobalService(typeof(SVsSolution)) as IVsSolution;
            EnvDTE.Project uproject = DTEWrapper.GetDTE().Solution.Projects.Item(1);
            var projectList = new List<ItemProject>();
            var projects = DTEWrapper.GetProjectsFromSolution(vsSolution, uproject.UniqueName, string.Format(@"{{{0}}}", GuidList.CSharpString));
            var projectCount = projects.GetUpperBound(0);

            if (projectCount == 0)
                txtWebModuleWarning.Visible = true;

            for (int i = 0; i <= projectCount; i++)
            {
                var project = (EnvDTE.Project)projects.GetValue(i);

                var projectTypeGuids = DTEWrapper.GetProjectTypeGuids(project);

                foreach (var item in projectTypeGuids)
                {
                    if (IsWebModule(item))
                    {
                        projectList.Add(new ItemProject { Name = project.Name, UniqueName = project.UniqueName });
                    }
                }
            }

            cmbWebModules.DataSource = projectList;
            cmbWebModules.DisplayMember = "Name";
            cmbWebModules.ValueMember = "UniqueName";
        }

        private bool IsWebModule(string item)
        {
            return item.Equals(string.Format(@"{{{0}}}", GuidList.guidWebModuleFactoryString), StringComparison.CurrentCultureIgnoreCase);
        }
    }


}