CREATE VIEW [cloudcore].[vwOpenTasks]
	AS 
	select InstanceId, UserId from [cloudcore].vwTasklist where StatusTypeId = 1