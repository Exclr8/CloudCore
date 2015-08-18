using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using CloudCore.Core.Hosting;
using CloudCore.Core.Menu;
using CloudCore.Core.Modules;
using CloudCore.Core.Utilities;
using CloudCore.Domain;
using CloudCore.Logging;
using CloudCore.Logging.Configuration;
using CloudCore.Web.Core.BaseControllers;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = CloudCore.Core.Modules.Environment;

namespace CloudCore.Web.Core.Tests.Hosting
{
    [TestClass]
    public class ModuleHostTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private static MockModuleHost mockHost;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            Logger.SetLogger(new DebugLogger(), VerbosityLevel.Debug);
            mockHost = new MockModuleHost();
            Assert.IsNotNull(mockHost);
        }

        [TestMethod]
        public void ModuleHost_ModulesHaveLoaded()
        {
            var modules = Environment.LoadedModules;
            Assert.AreEqual(6, modules.Count);
        }

        [TestMethod]
        public void ModuleHost_CanSeeAdminActions()
        {
            var actions = Environment.LoadedModuleActions.Where(a => a.SystemModule.AssemblyName.ToLower().StartsWith("cloudcore.admin"));
            Assert.IsTrue(actions.Any());
        }

        [TestMethod]
        public void ModuleHost_OnlyOneMenuRootRegistered()
        {
            var actionsC = Environment.LoadedModuleActions.Where(a => a.GetType() == typeof(MenuRoot));
            var rootCount = actionsC.Count();
            Assert.AreEqual(1, rootCount);
        }

        [TestMethod]
        [Ignore] // We don't have a IIS host core running yet, or we need to mock these things
        public void ModuleHost_CanSeeAdminResources()
        {
            HostingEnvironment.RegisterVirtualPathProvider(mockHost.PathProvider);
            var virtualFiles = VirtualFileBaseCollection.Files;
            Assert.IsTrue(virtualFiles.Count > 0);
        }

        [TestMethod]
        public void ModuleHost_AreAllControllerActions_AddedToModuleConfiguration()
        {
            var modules = Environment.LoadedModules;
            new List<InternalAuthenticatedController>();
            bool foundActionItems = false;


            foreach (var module in modules)
            {
                var actionList = new List<Tuple<string, string, string>>();
                var area = string.Empty;
                var configurations = (from a in module.Assembly.GetTypes()
                    where a.IsClass && !a.IsAbstract && a.GetInterfaces().Contains(typeof(IModuleConfiguration))
                    select a).ToList();

                foreach (var item in configurations)
                {
                    var configuration = (Activator.CreateInstance(item) as IModuleConfiguration);
                    if (configuration != null) area = configuration.GetAreaName();
                    Trace.WriteLine(string.Format(@"Scanning area: ""{0}""", area));
                }

                var allcontrollers = (from a in module.Assembly.GetTypes()
                                      where a.IsClass && !a.IsAbstract && typeof(InternalAuthenticatedController).IsAssignableFrom(a)
                    select a).ToList();

                foreach (var controller in allcontrollers)
                {
                    var controllername = controller.Name.Replace("Controller", "");
                    var methodInfos = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(r => r.ReturnType == typeof(ActionResult));
                    foreach (var method in methodInfos)
                    {
                        var methodname = method.Name;
                        var tupi = Tuple.Create(area.ToLower(), controllername.ToLower(), methodname.ToLower());
                        if (!actionList.Contains(tupi))
                        {
                            if (!Environment.GetAllLoadedModuleActions().HasAction(tupi))
                            {
                                actionList.Add(tupi);
                                string valueTransform = string.Format(@"root.AddSystemAction(""{0}"", SystemActionType.Details, ""{1}"", ""{2}"", ""{3}"");", Guid.NewGuid().ToString(), GenericUtils.SplitCamelCase(method.Name), controller.Name.Replace("Controller", ""), method.Name);

                                Trace.WriteLine(valueTransform);
                                foundActionItems = true;
                            }
                        }
                    }
                }
            }

            Assert.IsTrue(!foundActionItems, "There are actions defined that are not managed. Please use the output to verify.");
        }

        [TestMethod]
        public void ModuleDeployment_DeleteModuleActionIfExistsInDatabaseButNotRegistered()
        {
            var insertedSystemAction = InsertNonLoadedSystemActionIntoDatabase();

            ModuleDeployment.ManageDatabaseSystemAction(insertedSystemAction, Repository);
            var result = Repository.FindAll<SystemAction>(sa => sa.Title == "Bleep").SingleOrDefault();

            Assert.IsNull(result);
        }

        private SystemAction InsertNonLoadedSystemActionIntoDatabase()
        {
            var systemAction = new SystemAction
            {
                Title = "Bleep",
                Action = "Bleep",
                ActionGuid = Guid.NewGuid(),
                ActionType = SystemActionType.Folder,
                Area = "Bleep",
                Controller = "Bleep",
                Module = new SystemModule { Id = 1 }
            };

            systemAction.Id = Repository.Insert(systemAction);
            return systemAction;
        }

        [TestMethod]
        public void ModuleDeployment_ManageExistingDatabaseAction_KeepDatabaseAction()
        {
            var existingDatbaseAction = Repository.FindAll<SystemAction>(sa => sa.Id == 2).SingleOrDefault();
            
            ModuleDeployment.ManageDatabaseSystemAction(existingDatbaseAction, Repository);
            var result = Repository.FindAll<SystemAction>(sa => sa.Id == 2).SingleOrDefault();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ModuleDeployment_ManageExistingAction_WithNewUpdatedValues_DatabaseActionUpdated()
        {
            const string guid = "0BAEA491-B78D-485A-A190-3544B4500DAF";
            const string newTitle = "Administration123456";
            var systemAction = GetExistingDatabaseSystemAction(guid);
            systemAction.Title = newTitle;

            ModuleDeployment.ManageDatabaseSystemAction(systemAction, Repository);

            var result = GetExistingDatabaseSystemAction(guid);
            Assert.IsNotNull(result);
            Assert.AreEqual(newTitle, result.Title);
        }

        private SystemAction GetExistingDatabaseSystemAction(string guid)
        {
            var systemAction = Repository.FindAll<SystemAction>(sa => sa.ActionGuid == new Guid(guid)).SingleOrDefault();
            
            if (systemAction == null)
                throw new Exception(string.Format("Setup fail for this test. No system action defined with this Guid: {0}", guid));

            return systemAction;
        }
    }


}