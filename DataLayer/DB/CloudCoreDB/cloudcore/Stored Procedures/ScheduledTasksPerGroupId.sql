CREATE PROCEDURE [cloudcore].[ScheduledTasksPerGroupId]
	@scheduledTaskGroupId int = 0
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT
		st.ScheduledTaskId,
		st.ScheduledTaskGuid,
		st.ScheduledTaskName,
		st.ScheduledTaskTypeId,
		st.StatusId,
		st.[Status],
		st.Active,
		st.ScheduledTaskGroupId
	FROM 
		ScheduledTask st
	WHERE 
		st.ScheduledTaskGroupId = @scheduledTaskGroupId
END