using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Core.Logging;
using CloudCore.Core.ModuleActions;
using CloudCore.Domain;
using CloudCore.Logging;

using CloudCore.Data;
using CloudCore.Data.Buildbase;

namespace CloudCore.Core.Modules
{
    public class ModuleDeployment
    {
        private CloudCoreDB dbContext;

        private ModuleDeployment()
        {
            dbContext = CloudCoreDB.Context;
        }

        public static ModuleDeployment Synchronize()
        {
            return new ModuleDeployment();
        }

        public void SystemActions()
        {
            var existingActions = dbContext.Cloudcore_SystemAction.ToList();

            foreach (var databaseSystemAction in existingActions)
                ManageDatabaseSystemAction(databaseSystemAction, dbContext);

            foreach (var newSystemActions in SystemActionsNotFoundInDb())
                AddNewAction(newSystemActions);
        }

        private void ManageDatabaseSystemAction(Cloudcore_SystemAction dbSystemAction, CloudCoreDB dbContext)
        {
            var environmentSystemAction = (from a in Environment.LoadedModuleActions.Actions.Values
                                           where a.ActionGuid == dbSystemAction.ActionGuid
                                           select a).SingleOrDefault(); 

            if (environmentSystemAction == null)
            {
                dbContext.Cloudcore_SystemActionDelete(dbSystemAction.ActionId);
                return;
            }
            else
            {
                environmentSystemAction.IsNew = false;
            }

            if (IsDbSystemActionStale(dbSystemAction, environmentSystemAction))
            {
                UpdateDatabaseAction(dbSystemAction.ActionId, dbSystemAction.SystemModuleId, dbContext, environmentSystemAction);
            }
        }

        private bool IsDbSystemActionStale(Cloudcore_SystemAction dbSystemAction, ModuleAction environmentSystemAction)
        {
            return
            (
                (dbSystemAction.Action      ?? String.Empty) != (environmentSystemAction.Action      ?? String.Empty) ||
                (dbSystemAction.ActionTitle ?? String.Empty) != (environmentSystemAction.ActionTitle ?? String.Empty) ||
                (dbSystemAction.Area        ?? String.Empty) != (environmentSystemAction.Area        ?? String.Empty) ||
                (dbSystemAction.Controller  ?? String.Empty) != (environmentSystemAction.Controller  ?? String.Empty)
            );
        }

        private void UpdateDatabaseAction(int actionId, int systemModuleId, CloudCoreDB dbContext, ModuleAction systemAction)
        {
            try
            {
                dbContext.Cloudcore_SystemActionModify(actionId, systemAction.ActionTitle, systemAction.Area, systemAction.Controller, systemAction.Action, systemAction.ActionType.ToString(), systemModuleId);
            }
            catch (Exception exception)
            {
                Logger.Error(string.Format("Error updating system action [{0}]", systemAction.ActionTitle),
                    exception,
                    LogCategories.WebModuleDeploy,
                    ignoreVerbosityConfig: true);
            }
        }

        private IEnumerable<ModuleAction> SystemActionsNotFoundInDb()
        {
            return Environment.LoadedModuleActions.Actions.Values.Where(r => r.IsNew).ToList();
        }

        private void AddNewAction(ModuleAction newSystemAction)
        {
            try
            {
                if (newSystemAction.IsFolder)
                {
                    newSystemAction.ActionType = SystemActionType.Folder;
                }

                int? actionId = 0;

                dbContext.Cloudcore_SystemActionCreate(newSystemAction.ActionGuid,
                    newSystemAction.ActionTitle,
                    newSystemAction.Area,
                    newSystemAction.Controller,
                    newSystemAction.Action,
                    newSystemAction.ActionType.ToString(),
                    newSystemAction.SystemModule.SystemModuleIdOnDatbase,
                    ref actionId);

                newSystemAction.DatabaseActionId = actionId;
            }
            catch (Exception exception)
            {
                Logger.Error(string.Format("Error added system action [{0}]", newSystemAction.ActionTitle),
                    exception,
                    LogCategories.WebModuleDeploy,
                    ignoreVerbosityConfig: true);
            }
        }
    }
}