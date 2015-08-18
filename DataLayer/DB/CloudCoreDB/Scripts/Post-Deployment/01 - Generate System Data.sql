set identity_insert [cloudcore].[AccessPool] on
go

insert into [cloudcore].[AccessPool] ([AccessPoolId], [AccessPoolName], [ManagerId])
     values (0, 'CloudCore System User', 0)
go

set identity_insert [cloudcore].[AccessPool] off
go


set identity_insert [cloudcore].UserAccessProvider on
GO
insert into [cloudcore].UserAccessProvider (ProviderId,ProviderName)
values (1,'CloudCore')
GO
set identity_insert [cloudcore].UserAccessProvider off
GO


set identity_insert [cloudcore].SystemValueCategory on
go

insert into [cloudcore].SystemValueCategory(CategoryId, [CategoryName])
values
(1, 'Password'),
(2, 'Licence'),
(3, 'Application'),
(4, 'Worker')
go

set identity_insert [cloudcore].SystemValueCategory off
go

insert into [cloudcore].SystemValue ([CategoryId], [ValueName], [ValueData], [ValueDescription])
values
(1, 'Expiry', '60', 'Number of days until the password expired.'),
(1, 'Strength', '3', 'The level of strength required to define a new password.'),
(2, 'LicenseMode', '$(LicenseMode)', 'Available Modes: Development, Production'),
(2, 'LicenceKey', '$(LicenceKey)', 'Licence Key for this cloudcore installation'),
(3, 'Url Root', 'https://localhost:444/', 'The URI root to use when calling the hosted web services from all the different Azure roles in the application. It includes the URI scheme (such as https), the fully qualified DNS hostname, and port.')
go

set  identity_insert [cloudcore].SystemTally on
go

with base (nm) as (select 0 union all select 1 union all select 2 union all select 3 union all select 4 union all select 5 union all select 6 union all select 7 union all select 8 union all select 9),
     base_1 (nm) as (SELECT b1.nm + b2.nm*10 + b3.nm*100 + b4.nm*1000 + b5.nm*10000 + b6.nm*100000 from base b1, base b2, base b3, base b4, base b5, base b6)
insert into [cloudcore].SystemTally (TallyId, ZeroBased)     
select nm+1, nm from base_1
go

set  identity_insert [cloudcore].SystemTally off
go

set identity_insert [cloudcore].SystemAction on
go

insert into [cloudcore].SystemAction (ActionId, ActionGuid, SystemModuleId, ActionTitle, Area, Controller, [Action], ActionType) 
values(0, '00000000-0000-0000-0000-000000000000', 1, 'Menu Options','','','','Folder')

set identity_insert [cloudcore].SystemAction off
go





-- [cloudcore].User Explicit rows are a system requirement
set identity_insert [cloudcore].[User] on
go

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
go

set identity_insert [cloudcore].[User] off
go

insert into [cloudcore].Period (StartDate, EndDate, PeriodMonth, PeriodYear) values ('2009/01/01', '2009/01/31', 1, 2009)
exec [cloudcore].MaintainPeriods
go

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
    values(0, 0),
          (0, -99)

insert into [cloudcore].SystemApplication (ApplicationGuid,ApplicationName,CompanyName,ContactNumber,ContactPerson)
values('$(UiApplicationKey)','Cloudcore Site','Exclr8','0218139947','Alexander Mehlhorn'),
      ('$(VwApplicationKey)','Cloudcore Virtual Worker','Exclr8','0218139947','Alexander Mehlhorn')
go

-- generate system data for workflow tables

set identity_insert [cloudcoremodel].CostType on
go

insert into [cloudcoremodel].CostType([CostTypeId], [CostType]) values (0, 'Unidentified Cost')
go

set identity_insert [cloudcoremodel].CostType off
go


set identity_insert cloudcoremodel.ProcessModel on
go
insert into [cloudcoremodel].ProcessModel(ProcessModelId, ProcessGuid, ProcessName) 
                    values (0, '00000000-0000-0000-0000-000000000000', 'End Process')
set identity_insert cloudcoremodel.ProcessModel off
go

set identity_insert [cloudcoremodel].ProcessRevision on
go
insert into [cloudcoremodel].ProcessRevision(ProcessRevisionId, ProcessModelId, ProcessRevision, UserId, Changed, [CheckSum]) 
                    values (0, 0, 1, 0, GETDATE(), null)
set identity_insert [cloudcoremodel].ProcessRevision off
go
set identity_insert [cloudcoremodel].SubProcess on
go
insert into [cloudcoremodel].[SubProcess] ([SubProcessId], [SubProcessGuid], [ProcessRevisionId], [SubProcessName])
     values                       (0, '00000000-0000-0000-0000-000000000000', 0, 'End Process')

set identity_insert [cloudcoremodel].SubProcess off
go

set identity_insert [cloudcoremodel].ActivityModel on
go
insert into [cloudcoremodel].[ActivityModel] ([ActivityModelId], [ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [Startable], [ActivityTypeId], [Priority], [DocWait], CostTypeId)
      values (0, 0,  0, '00000000-0000-0000-0000-000000000000', 0, 'End Process', 0, 99, 0, 0, 0)


set identity_insert [cloudcoremodel].ActivityModel off
go


set identity_insert [cloudcore].Activity on
go
insert into [cloudcore].Activity(ActivityId, ActivityModelId, ProcessRevisionId, SystemModuleId, ActivityGuid,SubProcessGuid, ProcessGuid, ActivityTypeId) values
      (0, 0, 1, 1, '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', 0)

go
set identity_insert [cloudcore].Activity off
go
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
go

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
go
