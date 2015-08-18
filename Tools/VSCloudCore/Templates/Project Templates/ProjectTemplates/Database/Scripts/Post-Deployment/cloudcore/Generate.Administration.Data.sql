set identity_insert [cloudcore].SystemModule on
go

insert into [cloudcore].SystemModule ([SystemModuleId],[SystemModuleGuid], [AssemblyName])
    values (1, '51aa1e97-1cc7-42e1-9f3a-6af89e0cdd3b', 'CloudCore.Admin')


set identity_insert [cloudcore].SystemModule off
go

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
('204EE5D7-2721-4F4C-BEEC-911083ED261D' , @AdminModuleId ,'Folder', 'Admin', '', '', 'Scheduled Task Groups'),
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
('2A67CC52-83CF-4308-B76E-30329F12EC1D' , @AdminModuleId ,'Details', 'Admin', 'AccessPool', 'Remove', 'Remove'),
('303E7905-384B-4304-BE46-960C64441F13' , @AdminModuleId ,'Details', 'Admin', 'Pages', 'Details', 'Details'),
('8216D884-664D-4793-A7E4-510270165763' , @AdminModuleId ,'Details', 'Admin', 'Pages', 'RemoveAccessPoolFromPage', 'Remove Access Pool From Page'),
('A2057CE6-CA38-479F-B66A-96A812E03331' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'Index', 'Index'),
('25064ED1-56DD-4665-B3D0-13F2B7B71B34' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'DeleteActivityFromApplication', 'Delete Activity From Application'),
('00483A62-FE1F-4291-89A3-39D21B18F4CB' , @AdminModuleId ,'Details', 'Admin', 'SystemApplication', 'DeleteApplication', 'Delete Application'),
('AADDE6AD-55D9-4C71-ADD6-ECF156E08459' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'Details', 'Details'),
('4C00CC8B-60F9-4680-84A3-21D09B2D02BC' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'AddSystemValue', 'Add System Value'),
('B227698E-F899-40BB-B3C6-30615D2200D6' , @AdminModuleId ,'Details', 'Admin', 'SystemValues', 'ModifySystemValue', 'Modify System Value'),
('1A0A0BBE-94CD-44E4-97D9-5846B018B36F' , @AdminModuleId ,'Details', 'Admin', 'User', 'Update', 'Update'),
('F9F32AFF-020A-447D-B8A4-B155F3849DE0' , @AdminModuleId ,'Details', 'Admin', 'User', 'ViewAccessPools', 'View Access Pools'),
('FA1C4980-DDD4-4292-82EE-1D3C30BE5251' , @AdminModuleId ,'Details', 'Admin', 'User', 'UpdateAccessPools', 'Update Access Pools'),
('0D5F5908-5824-4CB0-B728-1677286022FD' , @AdminModuleId ,'Details', 'Admin', 'User', 'DeleteAccessPoolFromUser', 'Delete Access Pool From User'),
('7092160F-29F7-435D-9B3C-0291AEA4C3CE' , @AdminModuleId ,'Details', 'Admin', 'User', 'ChangeUserStatus', 'Change User Status'),
('C6380D0A-BEBB-4D8E-977D-BA855DBDD26F' , @AdminModuleId ,'Details', 'Admin', 'User', 'UserStatus', 'User Status'),
('2A2E9638-FC05-4AFD-8277-0BBD69AD4313' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'RestartFailedActivity', 'Restart Failed Activity'),
('6953B030-19CD-461D-83D1-79DF73576D82' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'RestartFailedInstance', 'Restart Failed Instance'),
('9CA769E5-3637-4D02-9E94-299BAA2CFFA7' , @AdminModuleId ,'Details', 'Admin', 'AdminPopup', 'FailedInstanceInfo', 'Failed Activity Info'),
('4429977F-12CD-4058-84C4-436A2A5CEC8A' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'Details', 'Details'),
('39A0C222-FCAD-47BB-BD30-0597E7733938' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangeUser', 'Change User'),
('F8F4DB97-1E27-48FD-9D18-A482C88954E3' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangePriority', 'Change Priority'),
('ABAEE091-BEFF-42A9-96EA-EB933F0B559E' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'CancelItem', 'Cancel Item'),
('1B4142B4-F8A1-475A-82A9-77CEB8EB6BB5' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ReleaseItem', 'Release Item'),
('0826628B-DAE6-468B-9071-427757EED738' , @AdminModuleId ,'Details', 'Admin', 'WorkflowTools', 'ChangeDueDate', 'Change Due Date'),

('85F7732D-53E3-43B7-8F9E-DB604426B1DD' , @AdminModuleId ,'Search', 'Admin', 'Activity', 'Search', 'Find Activity'),
('87B31EED-55AA-4908-9682-CC61C781AAA4' , @AdminModuleId ,'Details', 'Admin', 'Activity', 'Details', 'Activity Overview'),
('6E0779AF-6F1F-437D-88B6-2A620F3914A8' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'ApplicationAllocation', 'Applications'),
('010416CC-A7E5-4F64-9462-D68B5AC68261' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'AccessPoolAllocation', 'Access Pools'),
('EA9F87E9-3B7A-4846-AC8A-5B13EB4A19B6' , @AdminModuleId ,'Tools', 'Admin', 'Activity', 'AutomatedRetries', 'Automated Retries')
go

declare @EverySingleUserAR int = 0

--- the default stuff in CloudCore:
insert into [cloudcore].SystemActionAllocation(ActionId,AccessPoolId)
     select ActionId, @EverySingleUserAR AR from [cloudcore].SystemAction where ActionType = 'Folder' and SystemModuleId = 1 -- the menu itself as everyone everywhere
go
