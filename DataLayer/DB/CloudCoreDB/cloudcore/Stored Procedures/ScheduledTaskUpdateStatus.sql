CREATE PROCEDURE [cloudcore].[ScheduledTaskUpdateStatus]
	@scheduledTaskId int,
	@statusId int
AS
BEGIN
	UPDATE 
		[cloudcore].ScheduledTask
	SET
		[StatusId] = @statusId
	WHERE
		ScheduledTaskId = @scheduledTaskId
END
