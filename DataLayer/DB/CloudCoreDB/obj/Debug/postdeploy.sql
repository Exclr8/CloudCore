/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.					
--------------------------------------------------------------------------------------
*/

exec sp_msforeachtable 'alter table ? nocheck constraint all'
GO
exec sp_msforeachtable 'alter table ? disable trigger all'
GO


set identity_insert [cloudcore].[AccessPool] on
GO

insert into [cloudcore].[AccessPool] ([AccessPoolId], [AccessPoolName], [ManagerId])
     values (0, 'CloudCore System User', 0)
GO

set identity_insert [cloudcore].[AccessPool] off
GO


set identity_insert [cloudcore].UserAccessProvider on
GO
insert into [cloudcore].UserAccessProvider (ProviderId,ProviderName)
values (1,'CloudCore')
GO
set identity_insert [cloudcore].UserAccessProvider off
GO


set identity_insert [cloudcore].SystemValueCategory on
GO

insert into [cloudcore].SystemValueCategory(CategoryId, [CategoryName])
values
(1, 'Password'),
(2, 'Licence'),
(3, 'Application'),
(4, 'Worker')
GO

set identity_insert [cloudcore].SystemValueCategory off
GO

insert into [cloudcore].SystemValue ([CategoryId], [ValueName], [ValueData], [ValueDescription])
values
(1, 'Expiry', '60', 'Number of days until the password expired.'),
(1, 'Strength', '3', 'The level of strength required to define a new password.'),
(2, 'LicenseMode', '$(LicenseMode)', 'Available Modes: Development, Production'),
(2, 'LicenceKey', '$(LicenceKey)', 'Licence Key for this cloudcore installation'),
(3, 'Url Root', 'https://localhost:444/', 'The URI root to use when calling the hosted web services from all the different Azure roles in the application. It includes the URI scheme (such as https), the fully qualified DNS hostname, and port.')
GO

set  identity_insert [cloudcore].SystemTally on
GO

with base (nm) as (select 0 union all select 1 union all select 2 union all select 3 union all select 4 union all select 5 union all select 6 union all select 7 union all select 8 union all select 9),
     base_1 (nm) as (SELECT b1.nm + b2.nm*10 + b3.nm*100 + b4.nm*1000 + b5.nm*10000 + b6.nm*100000 from base b1, base b2, base b3, base b4, base b5, base b6)
insert into [cloudcore].SystemTally (TallyId, ZeroBased)     
select nm+1, nm from base_1
GO

set  identity_insert [cloudcore].SystemTally off
GO

set identity_insert [cloudcore].SystemAction on
GO

insert into [cloudcore].SystemAction (ActionId, ActionGuid, SystemModuleId, ActionTitle, Area, Controller, [Action], ActionType) 
values(0, '00000000-0000-0000-0000-000000000000', 1, 'Menu Options','','','','Folder')

set identity_insert [cloudcore].SystemAction off
GO





-- [cloudcore].User Explicit rows are a system requirement
set identity_insert [cloudcore].[User] on
GO

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'
declare @AdminUserEnabled bit = cast('$(EnableAdminAccount)' as bit)
declare @AdminPasswordHash varchar(200)

set @AdminPasswordHash = case when @AdminUserEnabled = 1
                                 then cloudcore.CreatePasswordHash(0, '$(AdminPassword)')
                              else
                                 'system'
                         end

insert into [cloudcore].[User] (UserId, Login, PasswordHash, Email, Initials, Firstnames, Surname, Created, CellNo, PasswordChanged, IsNamedUser, IntAccess) 
        values (0, 'sys', @AdminPasswordHash, 'dev@frameworkone.co.za', 'System', 'System', 'System', GETDATE(), '', GETDATE(), 0, @AdminUserEnabled)

insert into [cloudcore].[User] (UserId, Login, PasswordHash, Email, Initials, Firstnames, Surname, Created, CellNo, PasswordChanged, IsNamedUser, IntAccess) 
      values (-99, 'virtual worker', 'virtual worker', 'fake@example.com', 'V', 'Virtual', 'Worker', GETDATE(), '', GETDATE(), 0, 1)
GO

set identity_insert [cloudcore].[User] off
GO

insert into [cloudcore].Period (StartDate, EndDate, PeriodMonth, PeriodYear) values ('2009/01/01', '2009/01/31', 1, 2009)
exec [cloudcore].MaintainPeriods
GO

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
    values(0, 0),
          (0, -99)

insert into [cloudcore].SystemApplication (ApplicationGuid,ApplicationName,CompanyName,ContactNumber,ContactPerson)
values('$(UiApplicationKey)','Cloudcore Site','Exclr8','0218139947','Alexander Mehlhorn'),
      ('$(VwApplicationKey)','Cloudcore Virtual Worker','Exclr8','0218139947','Alexander Mehlhorn')
GO

-- generate system data for workflow tables

set identity_insert [cloudcoremodel].CostType on
GO

insert into [cloudcoremodel].CostType([CostTypeId], [CostType]) values (0, 'Unidentified Cost')
GO

set identity_insert [cloudcoremodel].CostType off
GO


set identity_insert cloudcoremodel.ProcessModel on
GO
insert into [cloudcoremodel].ProcessModel(ProcessModelId, ProcessGuid, ProcessName) 
                    values (0, '00000000-0000-0000-0000-000000000000', 'End Process')
set identity_insert cloudcoremodel.ProcessModel off
GO

set identity_insert [cloudcoremodel].ProcessRevision on
GO
insert into [cloudcoremodel].ProcessRevision(ProcessRevisionId, ProcessModelId, ProcessRevision, UserId, Changed, [CheckSum]) 
                    values (0, 0, 1, 0, GETDATE(), null)
set identity_insert [cloudcoremodel].ProcessRevision off
GO
set identity_insert [cloudcoremodel].SubProcess on
GO
insert into [cloudcoremodel].[SubProcess] ([SubProcessId], [SubProcessGuid], [ProcessRevisionId], [SubProcessName])
     values                       (0, '00000000-0000-0000-0000-000000000000', 0, 'End Process')

set identity_insert [cloudcoremodel].SubProcess off
GO

set identity_insert [cloudcoremodel].ActivityModel on
GO
insert into [cloudcoremodel].[ActivityModel] ([ActivityModelId], [ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [Startable], [ActivityTypeId], [Priority], [DocWait], CostTypeId)
      values (0, 0,  0, '00000000-0000-0000-0000-000000000000', 0, 'End Process', 0, 99, 0, 0, 0)


set identity_insert [cloudcoremodel].ActivityModel off
GO


set identity_insert [cloudcore].Activity on
GO
insert into [cloudcore].Activity(ActivityId, ActivityModelId, ProcessRevisionId, SystemModuleId, ActivityGuid,SubProcessGuid, ProcessGuid, ActivityTypeId) values
      (0, 0, 1, 1, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', 0)

GO
set identity_insert [cloudcore].Activity off
GO
insert into cloudcore.ActivityAllocation (AccessPoolId, ActivityId)
    values (0, 0)

insert into [cloudcoremodel].[ActivityType] ([ActivityTypeId], [ActivityTypeName])
values (0, 'CloudCore User Activity'),
       (1, 'Custom User Activity'),
       (2, 'Database Custom Activity'),
       (3, 'Database Parked Activity'),
       (4, 'Workflow Rule'),
       (5, 'Cloud Custom Activity'),
       (6, 'Database Costing Activity'),
       (7, 'Cloud Costing Activity'),
       (8, 'Database Batch Start Activity'),
       (9, 'Cloud Batch Start Activity'),
       (10, 'Cloud Batch Wait Activity'),
       (11, 'Cloud Parked Activity'),
	   (12, 'Clickatel Activity'),
	   (13, 'PostageApp Activity'),
	   (14, 'Corticon Activity'),
	   (15, 'Database Batch Wait Activity'),
	   (16, 'Email Activity'),
       (99, 'Stop')
GO

insert into [cloudcoremodel].[StatusType] (StatusTypeId, StatusTypeName)
values	(0, 'Pending'),
		(1, 'Started'),
        --(2, 'Suspended'),
        (3, 'Assigned'),
        --(4, 'Exception'),
        --(10, 'Batchitem'),
		(42, 'Retry'),
        (99, 'Cancelled'),
        (100, 'Completed'),
        (101, 'Failed')
GO

GO

set identity_insert [cloudcore].SystemModule on
GO

insert into [cloudcore].SystemModule ([SystemModuleId],[SystemModuleGuid], [AssemblyName])
    values (1, '51aa1e97-1cc7-42e1-9f3a-6af89e0cdd3b', 'CloudCore.Admin')


set identity_insert [cloudcore].SystemModule off
GO

declare @AdminModuleId int
set @AdminModuleId = 1 

insert into [cloudcore].SystemAction (ActionGuid, SystemModuleId, ActionType, Area, Controller, [Action], ActionTitle) values
('0B49B2BE-C6C7-4BCC-B683-1D5408761ED4' , @AdminModuleId ,'Folder', 'Admin', '', '', 'System Administration'),
('2EDEF353-E948-4CAF-AA4F-47C8AC3BD411' , @AdminModuleId ,'Folder', 'Admin', '', '', 'User & Access Management'),
('A5B7A71B-E8C7-46DE-B164-F68C65055758' , @AdminModuleId ,'Search', 'Admin', 'User', 'Search', 'Find User'),
('BC13FD67-E17A-49C3-81A9-AC3028C0E499' , @AdminModuleId ,'Create', 'Admin', 'User', 'Create', 'Create User'),
('61671EBA-D63B-4581-BCE9-6AE2EC2E4A64' , @AdminModuleId ,'Details', 'Admin', 'User', 'details', 'View User'),
('819B3B42-AB42-48C0-8169-70F4A75A2BED' , @AdminModuleId ,'Modify', 'Admin', 'User', 'modify', 'Modify User'),
('DD76503D-3BD1-4B06-8887-B59FB4CD6AC3' , @AdminModuleId ,'Modify', 'Admin', 'User', 'deactivate', 'Deactivate User'),
('4F486C85-1EED-428A-8FEC-56733E99E103' , @AdminModuleId ,'Modify', 'Admin', 'User', 'activate', 'Activate User'),
('E6B87EA7-7B65-4A40-9DF1-9AA69073626B' , @AdminModuleId ,'Tools', 'Admin', 'User', 'loginhistory', 'Login History'),
('AED6F29A-554F-438B-A01C-5A0304334160' , @AdminModuleId ,'Search', 'Admin', 'AccessPool', 'Search', 'Find Access Pool'),
('71C07B75-B345-45CF-AAFF-9CD6CAB6D703' , @AdminModuleId ,'Create', 'Admin', 'AccessPool', 'Create', 'Create Access Pool'),
('37740D94-4BCD-448D-A37E-50F8D0750F7E' , @AdminModuleId ,'Details', 'Admin', 'AccessPool', 'Details', 'View Access Pool'),
('79F8FD86-00E0-450B-962C-B27B6459DA5E' , @AdminModuleId ,'Modify', 'Admin', 'AccessPool', 'Modify', 'Modify Access Pool'),
('C0AB30C4-0533-4FF4-92E6-5B3D857BD3DF' , @AdminModuleId ,'Search', 'Admin', 'ScheduledTaskGroup', 'Search', 'Search Scheduled Task Groups'),
('5286C17D-E799-4F9A-9180-5FE658B2CE1A' , @AdminModuleId ,'Details', 'Admin', 'ScheduledTaskGroup', 'Details', 'View Scheduled Task Group'),
('1CDD86A9-2863-4386-9A70-2B862DF37160' , @AdminModuleId ,'Modify', 'Admin', 'ScheduledTaskGroup', 'Modify', 'Modify Scheduled Task Group'),
('5D5DB8EC-C60C-49AB-A7A6-A842A3732C31' , @AdminModuleId ,'Folder', 'Admin', '', '', 'Scheduled Tasks'),
('AC3112A2-5F75-4045-B33B-2F5CD3FED9EC' , @AdminModuleId ,'Search', 'Admin', 'ScheduledTask', 'Search', 'Search Scheduled Tasks'),
('ED92845C-56AF-4D43-9876-C1A91F590BF5' , @AdminModuleId ,'Details', 'Admin', 'ScheduledTask', 'Details', 'View Scheduled Task'),
('F6FD43FC-691A-4DC1-BDC0-76FB57BA6BE7' , @AdminModuleId ,'Modify', 'Admin', 'ScheduledTask', 'Modify', 'Modify Scheduled Task'),
('7E6AFA58-1F26-4C8F-AF2A-CD38F8CDF4A2' , @AdminModuleId ,'Folder', 'Admin', '', '', 'Pages'),
('FD168DD8-9F68-44B0-BC35-C6978F926679' , @AdminModuleId ,'Search', 'Admin', 'Pages', 'Search', 'Search For Page'),
('18D0CF01-EE4B-4667-9904-BDDD06A32536' , @AdminModuleId ,'Search', 'Admin', 'Pages', 'ShowWithoutRights', 'Pages Without Access Rights'),
('49820C37-2B75-476B-97F4-14B5C052EA4D' , @AdminModuleId ,'Folder', 'Admin', '', '', 'Workflow Tools'),
('9BF0284E-ED54-413D-BB38-636B302AE043' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'FailedActivities', 'Failed Activities'),
('4833D29D-BAA9-49D3-96A3-471B04020927' , @AdminModuleId ,'Search', 'Admin', 'WorkflowTools', 'FindWorklistItem', 'Find Worklist Item'),
('70FBB9F9-1132-4F7C-A205-5B9D4BDDCD71' , @AdminModuleId ,'Folder', 'Admin', '', '', 'System Applications'),
('656FB0F9-67E5-4976-9821-1D5342A04768' , @AdminModuleId ,'Search', 'Admin', 'SystemApplication', 'FindApplication', 'Find Application'),
('B382C8FC-A193-4DE8-8A4B-10663CEB56A8' , @AdminModuleId ,'Create', 'Admin', 'SystemApplication', 'CreateApplication', 'Create Application'),
('5743E862-C1E4-4DA2-8639-EC2CC7B63728' , @AdminModuleId ,'Folder', 'Admin', '', '', 'System Values'),
('EC41A383-ECF8-4B11-B396-678A65C98D9F' , @AdminModuleId ,'Search', 'Admin', 'SystemValues', 'Search', 'Find Category'),
('F923BAFC-8323-4E3B-841A-17BAB171B897' , @AdminModuleId ,'Create', 'Admin', 'SystemValues', 'Create', 'Create Category'),
('8ECE148C-81F5-4FDF-9195-8B5EF9E29BC7' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'Details', 'View Application'),
('E2BE25B2-F36F-4A77-A7C1-28B27015BCCB' , @AdminModuleId ,'Modify', 'Admin', 'SystemApplication', 'ModifyApplication', 'Modify Application'),
('2A67CC52-83CF-4308-B76E-30329F12EC1D' , @AdminModuleId ,'Details', 'Admin', 'AccessPool', 'Remove', 'Remove User From Access Pool'),
('303E7905-384B-4304-BE46-960C64441F13' , @AdminModuleId ,'Details', 'Admin', 'Pages', 'Details', 'Details'),
('8216D884-664D-4793-A7E4-510270165763' , @AdminModuleId ,'Details', 'Admin', 'Pages', 'RemoveAccessPoolFromPage', 'Remove Access Pool From Page'),
('A2057CE6-CA38-479F-B66A-96A812E03331' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'Index', 'Index'),
('25064ED1-56DD-4665-B3D0-13F2B7B71B34' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'DeleteActivityFromApplication', 'Delete Activity From Application'),
('00483A62-FE1F-4291-89A3-39D21B18F4CB' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'DeleteApplication', 'Delete Application'),
('AADDE6AD-55D9-4C71-ADD6-ECF156E08459' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'Details', 'Details'),
('4C00CC8B-60F9-4680-84A3-21D09B2D02BC' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'AddSystemValue', 'Add System Value'),
('B227698E-F899-40BB-B3C6-30615D2200D6' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'ModifySystemValue', 'Modify System Value'),
('1A0A0BBE-94CD-44E4-97D9-5846B018B36F' , @AdminModuleId ,'Details', 'Admin', 'User', 'Update', 'Update'),
('0D5F5908-5824-4CB0-B728-1677286022FD' , @AdminModuleId ,'Details', 'Admin', 'User', 'DeleteAccessPoolFromUser', 'Delete Access Pool From User'),
('7092160F-29F7-435D-9B3C-0291AEA4C3CE' , @AdminModuleId ,'Modify', 'Admin', 'User', 'UserAccessStatus', 'Change System Access'),
('2A2E9638-FC05-4AFD-8277-0BBD69AD4313' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'RestartFailedActivity', 'Restart Failed Activity'),
('6953B030-19CD-461D-83D1-79DF73576D82' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'RestartFailedInstance', 'Restart Failed Instance'),
('9CA769E5-3637-4D02-9E94-299BAA2CFFA7' , @AdminModuleId ,'Details', 'Admin', 'AdminPopup', 'FailedInstanceInfo', 'Failed Activity Info'),
('4429977F-12CD-4058-84C4-436A2A5CEC8A' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'Details', 'Details'),
('39A0C222-FCAD-47BB-BD30-0597E7733938' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangeUser', 'Change User'),
('F8F4DB97-1E27-48FD-9D18-A482C88954E3' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangePriority', 'Change Priority'),
('ABAEE091-BEFF-42A9-96EA-EB933F0B559E' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'CancelItem', 'Cancel Item'),
('1B4142B4-F8A1-475A-82A9-77CEB8EB6BB5' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ReleaseItem', 'Release Item'),
('0826628B-DAE6-468B-9071-427757EED738' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangeDueDate', 'Change Due Date'),
('0a9f962b-9df7-4d51-9a08-8b23feba7ca6', @AdminModuleId, 'Details', 'Admin', 'User', 'UserResetPassword', 'User Reset Password'),
('85F7732D-53E3-43B7-8F9E-DB604426B1DD' , @AdminModuleId ,'Search', 'Admin', 'Activity', 'Search', 'Find Activity'),
('87B31EED-55AA-4908-9682-CC61C781AAA4' , @AdminModuleId ,'Details', 'Admin', 'Activity', 'Details', 'Activity Overview'),
('6E0779AF-6F1F-437D-88B6-2A620F3914A8' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'ApplicationAllocation', 'Applications'),
('010416CC-A7E5-4F64-9462-D68B5AC68261' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'AccessPoolAllocation', 'Access Pools'),
('EA9F87E9-3B7A-4846-AC8A-5B13EB4A19B6' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'AutomatedRetries', 'Automated Retries'),
('106A03A9-6B75-4199-B31C-CB99BF814EA0', @AdminModuleId , 'Details', 'Admin', 'Activity', 'RemoveAccessPool', 'Remove Access Pools')

GO

declare @EverySingleUserAR int = 0

--- the default stuff in CloudCore:
insert into [cloudcore].SystemActionAllocation(ActionId,AccessPoolId)
     select ActionId, @EverySingleUserAR AR from [cloudcore].SystemAction where ActionType = 'Folder' and SystemModuleId = 1 -- the menu itself as everyone everywhere
GO

GO

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'

if isnull(@BuildConfigMode, 'Debug') = 'Release'
begin
    declare @stringToPrint varchar(50) 
    set @stringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' mode. Exclr8 user data will NOT be included.'
    print @stringToPrint
    set noexec on;
end
GO

set identity_insert [cloudcore].[User] on
GO
        insert into [cloudcore].[User] (UserId, [Login], PasswordHash, Email, Initials, Firstnames, Surname, IntAccess, Created, CellNo, PasswordChanged) 
                   values 
                          
                          (1, 'ahm', '3354481600540322a9334e9a8d5136371____', 'ahm@frameworkone.co.za', 'AH', 'Alexander', 'Mehlhorn', 1, GETDATE(), '0824951496', GETDATE()),
                          (2, 'jhr', 'dfd691b80b061f04638e3d419c2a66e72____', 'jhr@frameworkone.co.za', 'J','Johan', 'van Tonder', 1, GETDATE(), '0720761226', GETDATE()),
                          (3, 'wou', 'ec6f9f50aa6e4340ac5cb5ecd551cca53____', 'wou@frameworkone.co.za', 'W', 'Wouter', 'Olivier', 1, GETDATE(), '0712005534', GETDATE()),
                          (4, 'spx', '6e770c9bb7dc5d4278f68ba2584324324____', 'spx@frameworkone.co.za', 'S','Stephan', 'Pienaar', 1, GETDATE(), '0828149009', GETDATE()),
                          (5, 'lyb', '50e87a566aba74b9fa44b39c6e6ab3b57____', 'lyb@frameworkone.co.za', 'L',  'Lyon', 'Blecher', 1, GETDATE(), '0784594955', GETDATE()),
						  (7, 'whw', '9dab3c1a5b299de7c4dade07ca173dba11___', 'whw@frameworkone.co.za', 'WH', 'Walter', 'Weder', 1, GETDATE(), '0763798805', GETDATE()),
						  (8, 'brg', '6e770c9bb7dc5d4278f68ba2584324324____', 'brg@frameworkone.co.za', 'B', 'Brendon', 'Greyling', 1, GETDATE(), '0723173766', GETDATE())

GO
    set identity_insert [cloudcore].[User] off
GO

update [cloudcore].[User] set IsAdministrator = 1 where UserId  between 1 and 8
GO

update  U
set     U.PasswordHash = cloudcore.CreatePasswordHash(U.UserId, 'password')
from    cloudcore.[user] U
where   UserId > 0
GO

-- Update userAccessMappings
insert into cloudcore.UserAccessMapping(ProviderId,UserId,UserKey)
select 1,UserId,UserKey
from cloudcore.[user] where UserId > 0

GO

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
   select AP.AccessPoolId, U.UserId
      from cloudcore.AccessPool AP
      cross join cloudcore.[User] U 
	 where UserId >0
	 
GO

set noexec off;
GO


GO

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'

if isnull(@BuildConfigMode, 'Debug') = 'Release'
begin
    declare @stringToPrint varchar(50) 
    set @stringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' mode. Test data will NOT be generated.'
    print @stringToPrint
    set noexec on;
end
GO

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'
declare @ModeStringToPrint varchar(100)
set @ModeStringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' Mode'
print @ModeStringToPrint
GO



/**************************************************************************************************** TEST USERS ********************************************/
/**************************************************************************************************** TEST USERS ********************************************/
/**************************************************************************************************** TEST USERS ********************************************/

declare @UserId int

insert into [cloudcore].[User] ([Login], PasswordHash, Email, Initials, Firstnames, Surname, IntAccess, Created, CellNo, PasswordChanged) 
    values ('test', 'zaber', 'f1team@frameworkone.co.za', 'FO', 'Framework', 'One', 1, GETDATE(), '0824951496', GETDATE())

set @UserId = SCOPE_IDENTITY()

update  U
set     U.PasswordHash = cloudcore.CreatePasswordHash(U.UserId, 'password')
from    cloudcore.[user] U
where   U.UserId = @UserId

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
   values (0, @UserId)
     


/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/
/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/
/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/

print 'Deploying test (demo) processes...'
GO


declare @systemmoduleid int
declare @processmodelid int
declare @processrevision int
declare @processrevisionid int
declare @subprocessid int
declare @activitymodelid int
declare @fromactivitymodelid int
declare @toactivitymodelid int
declare @oldprocessrevisionid int
declare @processguid uniqueidentifier 
declare @replacementid int

if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')
    begin
      select @systemmoduleid = SystemModuleId
      from    cloudcore.SystemModule
      where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f'
    end
else
    begin
      insert into [cloudcore].SystemModule(AssemblyName, SystemModuleGuid)
      values('CloudCore.ProcessTest', '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')

      set @systemmoduleid = scope_identity()
    end

-- create the model if its new
set @processguid = 'b2318944-d545-41e3-9f97-712310a7b53a'
if not exists(select null from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid)
begin
  insert into [cloudcoremodel].[ProcessModel] ([ProcessGuid], [ProcessName])
       values (@processguid, 'Test Process')

  set @processmodelid = SCOPE_IDENTITY()
  set @processrevision = 1
  set @oldprocessrevisionid = null
end else
begin
  select @processmodelid = ProcessModelId  from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid 
  select @processrevision = max(ProcessRevision) from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid
  select @oldprocessrevisionid = ProcessRevisionId from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid and ProcessRevision = @processrevision
  update [cloudcoremodel].ProcessModel set ProcessName = 'Test Process' where ProcessModelId = @processmodelid
  set @processrevision = @processrevision + 1
end

-- create the new revision
insert into [cloudcoremodel].[ProcessRevision] ([ProcessModelId], [ProcessRevision], [CheckSum], [UserId], [ManagerId], [Changed])
     values (@processmodelid, @processrevision, null, 0, 0, getdate())

set @processrevisionid = SCOPE_IDENTITY()

-- create the new subprocess for each one we found
insert into [cloudcoremodel].[SubProcess] ([ProcessRevisionId], [SubProcessGuid], [SubProcessName])
     values (@processrevisionid, '7c293d3f-bad7-445d-8935-ea78a94421cd', 'Test Subprocess 1')
set @subprocessid = SCOPE_IDENTITY()

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [OnlyVisibleAtLocation], [LocationRadius])
     values (@processrevisionid, 0, '31ba9bf0-6bdb-4850-9a92-f9b82ae1b008', @subprocessid, 'Some DB Stuff', '2', 0, '1', '0', '0', '0', null)
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [OnlyVisibleAtLocation], [LocationRadius])
     values (@processrevisionid, 0, 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46', @subprocessid, 'CloudcoreUser1', '0', 0, '0', '0', '0', '0', null)
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid

-- create each flow (repeat)
select @fromactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '31ba9bf0-6bdb-4850-9a92-f9b82ae1b008'
select @toactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46'

insert into [cloudcoremodel].[FlowModel] ([FlowGuid], [ProcessRevisionId], [FromActivityModelId], [Outcome], [ToActivityModelId], [OptimalFlow], [NegativeFlow], [Storyline])
     values ('e8ea2bed-bfe8-4a45-8b36-c30703348b2a', @processrevisionid, @fromactivitymodelid, '-', @toactivitymodelid, '0', '0', '')

-- create each flow (repeat)
select @fromactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46'
select @toactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '00000000-0000-0000-0000-000000000000'

insert into [cloudcoremodel].[FlowModel] ([FlowGuid], [ProcessRevisionId], [FromActivityModelId], [Outcome], [ToActivityModelId], [OptimalFlow], [NegativeFlow], [Storyline])
     values ('4cac9e22-77cd-4e25-8183-546e120fc049', @processrevisionid, @fromactivitymodelid, '-', @toactivitymodelid, '0', '0', '')

  -- insert the new ones
  insert into [cloudcore].Activity  ([ActivityModelId]
           ,[ProcessRevisionId]
           ,[SystemModuleId]
           ,[ActivityTypeId]
           ,[OnlyVisibleAtLocation]
		   ,[LocationRadius]
           ,[ActivityGuid]
           ,[SubProcessGuid]
           ,[ProcessGuid])
  select AM.ActivityModelId, AM.ProcessRevisionId, @systemmoduleid,
         AM.ActivityTypeId, AM.OnlyVisibleAtLocation, AM.LocationRadius, AM.ActivityGuid,
		 SP.SubProcessGuid, PM.ProcessGuid

     from [cloudcoremodel].ActivityModel AM
	inner join [cloudcoremodel].SubProcess SP
	  on SP.SubProcessId = AM.SubProcessId
    inner join [cloudcoremodel].ProcessRevision PR
	   on PR.ProcessRevisionId = SP.ProcessRevisionId
    inner join [cloudcoremodel].ProcessModel PM
	   on PM.ProcessModelId = PR.ProcessModelId
	where AM.ActivityGuid not in (select ActivityGuid from [cloudcoremodel].ActivityModel where ProcessRevisionId = @oldprocessrevisionid)
	and AM.ProcessRevisionId = @processrevisionid

-- select old revision info
if (@oldprocessrevisionid is not null)
begin
  -- reset failed activities in this process
  delete from [cloudcore].WorklistFailure where ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)
  update [cloudcore].Worklist set StatusTypeId = 0 where StatusTypeId = 101 and ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)

  -- update the ones that remain
  update A 
     set A.ProcessRevisionId = @processrevisionid,
	     A.ActivityModelId = AM.ActivityModelId,
		 A.OnlyVisibleAtLocation = AM.OnlyVisibleAtLocation,
		 A.LocationRadius = AM.LocationRadius,
		 A.ActivityTypeId = AM.ActivityTypeId
    from [cloudcore].Activity A
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityGuid = A.ActivityGuid
	where A.ProcessRevisionId = @oldprocessrevisionid
	  and AM.ProcessRevisionId = @processrevisionid

  -- delete the ones that get removed 
  update W 
     set W.ActivityId = AN.ActivityId
    from [cloudcore].Worklist W
   inner join [cloudcore].Activity A
      on A.ActivityId = W.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   delete from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid
end
GO


if exists(select null from sys.sysobjects
where type = 'p' and name = 'CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008')
begin
    drop procedure [cloudcore].[CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008]
end
GO

create procedure [cloudcore].[CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008]
    @InstanceId bigint,
    @KeyValue bigint
as
  begin
    print 'A test activity yeaaah.'
    return
  end
  
GO


/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/
/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/
/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/

print 'Deploying test (demo) process workflow instance test data...'
GO

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'
declare @NumberOfInstancesDesired bigint = 2500
declare @ActivityGuidToStartWith uniqueidentifier = '31BA9BF0-6BDB-4850-9A92-F9B82AE1B008'

declare @KeyValue bigint = 1, @UserId int = 0, @InstanceId bigint

while @KeyValue <= @NumberOfInstancesDesired
begin
	exec cloudcore.ActivityStart @ActivityGuidToStartWith, @KeyValue, @UserId, @InstanceId out
	set @KeyValue = @KeyValue + 1
end
GO



/***************************************************************** SCHEDULED TASKS ******************************************/
/***************************************************************** SCHEDULED TASKS ******************************************/
/***************************************************************** SCHEDULED TASKS ******************************************/

print 'Deploying test (demo) scheduled tasks...'
GO

declare @systemmoduleid int
declare @scheduledtaskgroupguid uniqueidentifier = 'd2ba6fb1-832d-4d5f-b561-09fd5d5b7545'
declare @scheduledtaskgroupid int

if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')
    begin
      select @systemmoduleid = SystemModuleId
      from    cloudcore.SystemModule
      where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f'
    end
else
    begin
      insert into [cloudcore].SystemModule(AssemblyName, SystemModuleGuid)
      values('CloudCore.ProcessTest', '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')

      set @systemmoduleid = scope_identity()
    end

-- create or update scheduled task group
if not exists(select null from [cloudcore].[ScheduledTaskGroup] where [ScheduledTaskGroupGuid] = @scheduledtaskgroupguid)
begin
  insert into [cloudcore].[ScheduledTaskGroup] ([ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
  values (@scheduledtaskgroupguid, @systemmoduleid, 'Test', 0)
  set @scheduledtaskgroupid = SCOPE_IDENTITY()
end else
begin
  select @scheduledtaskgroupid = ScheduledTaskGroupId from [cloudcore].[ScheduledTaskGroup] where ScheduledTaskGroupGuid = @scheduledtaskgroupguid
  update [cloudcore].[ScheduledTaskGroup] set ScheduledTaskGroupName = 'Test' where ScheduledTaskGroupId = @scheduledtaskgroupid
end

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('d37e5a1e-0983-4892-869f-60b00baf722f', 'SqlScheduledTask1', '0', getdate(), null, 0, 1, 0, 6, '3', getdate(), getdate(), @scheduledtaskgroupid, @systemmoduleid)

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('092dbe81-ac1e-4ad2-8e84-700dfa18fc11', 'CSharpScheduledTask1', '1', getdate(), null, 0, 1, 0, 6, '5', getdate(), getdate(), @scheduledtaskgroupid, @systemmoduleid)

GO

if exists(select null from sys.sysobjects
where type = 'p' and name = 'CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f')
begin
    drop procedure [cloudcore].[CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f]
end
GO

create procedure [cloudcore].[CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f]
as
begin
    declare @SecondsToRun int = 4,
            @EndDateTime datetime

    select @EndDateTime = dateadd(second, @SecondsToRun, getdate())
    while getdate() < @EndDateTime
    begin
        print 'Simulating time passing for test scheduled task...'
    end
end
GO



/***************************************************************** SYSTEM VALUES ********************************************/
/***************************************************************** SYSTEM VALUES ********************************************/
/***************************************************************** SYSTEM VALUES ********************************************/

set identity_insert [cloudcore].SystemValueCategory on
GO

insert into [cloudcore].SystemValueCategory(CategoryId, [CategoryName])
values
(5, 'ClickatellSettings'),
(6, 'MySettingsWithIntegers'),
(7, 'MySettingsWithDateTime'),
(8, 'MySettingsWithTypeDouble'),
(9, 'MySettingsUpdated'),
(10, 'MySettingsSave')

GO

set identity_insert [cloudcore].SystemValueCategory off
GO

insert into [cloudcore].SystemValue ([CategoryId], [ValueName], [ValueData], [ValueDescription])
values
(5, 'Username', 'myusername', 'Clicaktell Username'),
(5, 'Password', 'mypassword', 'Clicaktell Password'),
(5, 'ApiKey', 'myapikey', 'Clicaktell ApiKey'),
(6, 'NumberValue', '2', 'NumberValue'),
(7, 'DateTimeValue', '2009-10-17 14:31:27', 'DateTimeValue'),
(8, 'DoubleValue', '2.7', 'DoubleValue'),
(9, 'CanBeUpdated', 'TestValue', 'TestValue'),
(10, 'A', '1', 'A'),
(10, 'B', '2', 'B'),
(10, 'C', '3', 'C')
GO



/**************************************************************** SYSTEM ACTIONS ********************************************/
/**************************************************************** SYSTEM ACTIONS ********************************************/
/**************************************************************** SYSTEM ACTIONS ********************************************/

--insert into [cloudcore].SystemAction (ActionGuid, SystemModuleId, ActionType, Area, Controller, [Action], ActionTitle) values
--('622A2620-769B-416B-B16A-57B93098BFD4' , 1 ,'Create', 'Area51', 'Controller51', 'Action51', 'Title51')



/**************************************************************** NOTIFICATIONS *********************************************/
/**************************************************************** NOTIFICATIONS *********************************************/
/**************************************************************** NOTIFICATIONS *********************************************/

declare @NotificationId int
insert into cloudcore.[Notification] ([Subject], [Message], Creator)
    values ('Welcome', 'Welcome to CloudCore. Enjoy your stay.', 0)

set @NotificationId = SCOPE_IDENTITY()

insert into cloudcore.UserNotification (UserId, NotificationId)
    select  UserId, @NotificationId
    from    cloudcore.[User]
GO



/************************************************************ END OF TEST DATA **********************************************/
/************************************************************ END OF TEST DATA **********************************************/
/************************************************************ END OF TEST DATA **********************************************/

set noexec off;
GO

GO

set noexec off
GO

exec sp_msforeachtable 'alter table ? enable trigger all'
GO
exec sp_msforeachtable 'alter table ? WITH CHECK check constraint all'
GO

GO
