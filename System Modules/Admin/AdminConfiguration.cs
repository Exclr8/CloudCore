using CloudCore.Core.Menu;
using CloudCore.Core.Modules;
using CloudCore.Domain;

namespace CloudCore.Admin
{
    public class AdminConfiguration : IModuleConfiguration
    {
        public void LoadModuleActions(MenuRoot root)
        {
            /* ALL ActionGuids must be specified as constant values - do not call "new Guid()" functions */

            /* Add administration menu folders */
            var adminFolder  = root.AddMenuFolder("0B49B2BE-C6C7-4BCC-B683-1D5408761ED4", "System Administration");
            var accessFolder = adminFolder.AddMenuFolder("2EDEF353-E948-4CAF-AA4F-47C8AC3BD411", "User & Access Management");
            var schedulesFolder = adminFolder.AddMenuFolder("5D5DB8EC-C60C-49AB-A7A6-A842A3732C31", "Scheduled Tasks");
            var pagesFolder = adminFolder.AddMenuFolder("7E6AFA58-1F26-4C8F-AF2A-CD38F8CDF4A2", "Pages");
            var workflowFolder = adminFolder.AddMenuFolder("49820C37-2B75-476B-97F4-14B5C052EA4D", "Workflow Tools");
            var systemFolder = adminFolder.AddMenuFolder("70FBB9F9-1132-4F7C-A205-5B9D4BDDCD71", "System Applications");
            var systemValueFolder = adminFolder.AddMenuFolder("5743E862-C1E4-4DA2-8639-EC2CC7B63728", "System Values");
            
            /* Add system actions that appear on the menu structure */
            accessFolder.AddMenuAction("A5B7A71B-E8C7-46DE-B164-F68C65055758", SystemActionType.Search, "Find User", "User", "Search");
            accessFolder.AddMenuAction("BC13FD67-E17A-49C3-81A9-AC3028C0E499", SystemActionType.Create, "Create User",  "User", "Create");
            accessFolder.AddMenuAction("AED6F29A-554F-438B-A01C-5A0304334160", SystemActionType.Search, "Find Access Pool",  "AccessPool", "Search");
            accessFolder.AddMenuAction("71C07B75-B345-45CF-AAFF-9CD6CAB6D703", SystemActionType.Create, "Create Access Pool", "AccessPool", "Create");
            
            schedulesFolder.AddMenuAction("AC3112A2-5F75-4045-B33B-2F5CD3FED9EC", SystemActionType.Search, "Search Scheduled Tasks",  "ScheduledTask", "Search");
            schedulesFolder.AddMenuAction("C0AB30C4-0533-4FF4-92E6-5B3D857BD3DF", SystemActionType.Search, "Search Scheduled Task Groups", "ScheduledTaskGroup", "Search");

            pagesFolder.AddMenuAction("FD168DD8-9F68-44B0-BC35-C6978F926679", SystemActionType.Search, "Search For Page", "Pages", "Search");
            pagesFolder.AddMenuAction("18D0CF01-EE4B-4667-9904-BDDD06A32536", SystemActionType.Search, "Pages Without Access Rights", "Pages", "ShowWithoutRights");
            
            workflowFolder.AddMenuAction("9BF0284E-ED54-413D-BB38-636B302AE043", SystemActionType.Details, "Failed Activities",  "WorkflowTools", "FailedActivities");
            workflowFolder.AddMenuAction("4833D29D-BAA9-49D3-96A3-471B04020927", SystemActionType.Search, "Find Worklist Item",  "WorkflowTools", "FindWorklistItem");
            workflowFolder.AddMenuAction("85F7732D-53E3-43B7-8F9E-DB604426B1DD", SystemActionType.Search, "Find Activity", "Activity", "Search");

            systemFolder.AddMenuAction("656FB0F9-67E5-4976-9821-1D5342A04768", SystemActionType.Search, "Find Application",  "SystemApplication", "FindApplication");
            systemFolder.AddMenuAction("B382C8FC-A193-4DE8-8A4B-10663CEB56A8", SystemActionType.Create, "Create Application",  "SystemApplication", "CreateApplication");

            systemValueFolder.AddMenuAction("EC41A383-ECF8-4B11-B396-678A65C98D9F", SystemActionType.Search, "Find Category",  "SystemValues", "Search");
            systemValueFolder.AddMenuAction("F923BAFC-8323-4E3B-841A-17BAB171B897", SystemActionType.Create, "Create Category", "SystemValues", "Create");

            /* Add system actions that do not appear on the menu but need to be managed by access rights */
            root.AddSystemAction("61671EBA-D63B-4581-BCE9-6AE2EC2E4A64", SystemActionType.Details, "View User", "User", "details");
            root.AddSystemAction("819B3B42-AB42-48C0-8169-70F4A75A2BED", SystemActionType.Modify, "Modify User", "User", "modify");
            root.AddSystemAction("0a9f962b-9df7-4d51-9a08-8b23feba7ca6", SystemActionType.Details, "User Reset Password", "User", "UserResetPassword");

            root.AddSystemAction("DD76503D-3BD1-4B06-8887-B59FB4CD6AC3", SystemActionType.Modify, "Deactivate User", "User", "deactivate");
            root.AddSystemAction("4F486C85-1EED-428A-8FEC-56733E99E103", SystemActionType.Modify, "Activate User", "User", "activate");
            root.AddSystemAction("E6B87EA7-7B65-4A40-9DF1-9AA69073626B", SystemActionType.Tools, "Login History", "User", "loginhistory");
            root.AddSystemAction("37740D94-4BCD-448D-A37E-50F8D0750F7E", SystemActionType.Details, "View Access Pool", "AccessPool", "Details");
            root.AddSystemAction("79F8FD86-00E0-450B-962C-B27B6459DA5E", SystemActionType.Modify, "Modify Access Pool",  "AccessPool", "Modify");

            root.AddSystemAction("ED92845C-56AF-4D43-9876-C1A91F590BF5", SystemActionType.Details, "View Scheduled Task",  "ScheduledTask", "Details");
            root.AddSystemAction("F6FD43FC-691A-4DC1-BDC0-76FB57BA6BE7", SystemActionType.Modify, "Modify Scheduled Task", "ScheduledTask", "Modify");
            root.AddSystemAction("5286C17D-E799-4F9A-9180-5FE658B2CE1A", SystemActionType.Details, "View Scheduled Task Group", "ScheduledTaskGroup", "Details");
            root.AddSystemAction("1CDD86A9-2863-4386-9A70-2B862DF37160", SystemActionType.Modify, "Modify Scheduled Task Group", "ScheduledTaskGroup", "Modify");

            root.AddSystemAction("8ece148c-81f5-4fdf-9195-8b5ef9e29bc7", SystemActionType.Details, "View Application", "SystemApplication", "Details");
            root.AddSystemAction("e2be25b2-f36f-4a77-a7c1-28b27015bccb", SystemActionType.Modify, "Modify Application", "SystemApplication", "ModifyApplication");

            root.AddSystemAction("2a67cc52-83cf-4308-b76e-30329f12ec1d", SystemActionType.Delete, "Remove User From Access Pool", "AccessPool", "Remove"); 
            root.AddSystemAction("303e7905-384b-4304-be46-960c64441f13", SystemActionType.Details, "Details", "Pages", "Details");
            root.AddSystemAction("8216d884-664d-4793-a7e4-510270165763", SystemActionType.Delete, "Remove Access Pool From Page", "Pages", "RemoveAccessPoolFromPage");
            root.AddSystemAction("a2057ce6-ca38-479f-b66a-96a812e03331", SystemActionType.Details, "Index", "SystemApplication", "Index");
            root.AddSystemAction("25064ed1-56dd-4665-b3d0-13f2b7b71b34", SystemActionType.Delete, "Delete Activity From Application", "SystemApplication", "DeleteActivityFromApplication");
            root.AddSystemAction("00483a62-fe1f-4291-89a3-39d21b18f4cb", SystemActionType.Delete, "Delete Application", "SystemApplication", "DeleteApplication");
            root.AddSystemAction("aadde6ad-55d9-4c71-add6-ecf156e08459", SystemActionType.Details, "Details", "SystemValues", "Details");
            root.AddSystemAction("4c00cc8b-60f9-4680-84a3-21d09b2d02bc", SystemActionType.Create, "Add System Value", "SystemValues", "AddSystemValue");
            root.AddSystemAction("b227698e-f899-40bb-b3c6-30615d2200d6", SystemActionType.Modify, "Modify System Value", "SystemValues", "ModifySystemValue");
            root.AddSystemAction("1a0a0bbe-94cd-44e4-97d9-5846b018b36f", SystemActionType.Modify, "Update", "User", "Update");
            root.AddSystemAction("0d5f5908-5824-4cb0-b728-1677286022fd", SystemActionType.Delete, "Delete Access Pool From User", "User", "DeleteAccessPoolFromUser");
            root.AddSystemAction("7092160f-29f7-435d-9b3c-0291aea4c3ce", SystemActionType.Modify, "Change System Access", "User", "UserAccessStatus");
            root.AddSystemAction("6953B030-19CD-461D-83D1-79DF73576D82", SystemActionType.Tools, "Restart Failed Instance", "WorkflowTools", "RestartFailedInstance");
            root.AddSystemAction("2a2e9638-fc05-4afd-8277-0bbd69ad4313", SystemActionType.Tools, "Restart Failed Activity", "WorkflowTools", "RestartFailedActivity");
            root.AddSystemAction("9ca769e5-3637-4d02-9e94-299baa2cffa7", SystemActionType.Details, "Failed Activity Info", "AdminPopup", "FailedInstanceInfo");
            root.AddSystemAction("4429977f-12cd-4058-84c4-436a2a5cec8a", SystemActionType.Details, "Details", "WorkflowTools", "Details");
            root.AddSystemAction("39a0c222-fcad-47bb-bd30-0597e7733938", SystemActionType.Modify, "Change User", "WorkflowTools", "ChangeUser");
            root.AddSystemAction("f8f4db97-1e27-48fd-9d18-a482c88954e3", SystemActionType.Tools, "Change Priority", "WorkflowTools", "ChangePriority");
            root.AddSystemAction("abaee091-beff-42a9-96ea-eb933f0b559e", SystemActionType.Delete, "Cancel Item", "WorkflowTools", "CancelItem");
            root.AddSystemAction("1b4142b4-f8a1-475a-82a9-77ceb8eb6bb5", SystemActionType.Delete, "Release Item", "WorkflowTools", "ReleaseItem");
            root.AddSystemAction("0826628b-dae6-468b-9071-427757eed738", SystemActionType.Modify, "Change Due Date", "WorkflowTools", "ChangeDueDate");

            root.AddSystemAction("87B31EED-55AA-4908-9682-CC61C781AAA4", SystemActionType.Details, "Activity Overview", "Activity", "Details");
            root.AddSystemAction("6E0779AF-6F1F-437D-88B6-2A620F3914A8", SystemActionType.Tools, "Applications", "Activity", "ApplicationAllocation");
            root.AddSystemAction("010416CC-A7E5-4F64-9462-D68B5AC68261", SystemActionType.Tools, "Access Pools", "Activity", "AccessPoolAllocation");
            root.AddSystemAction("106A03A9-6B75-4199-B31C-CB99BF814EA0", SystemActionType.Delete, "Remove Access Pools", "Activity", "RemoveAccessPool");
            root.AddSystemAction("EA9F87E9-3B7A-4846-AC8A-5B13EB4A19B6", SystemActionType.Modify, "Automated Retries", "Activity", "AutomatedRetries");
        }


        public string GetAreaName()
        {
            return "Admin";
        }
    }

}