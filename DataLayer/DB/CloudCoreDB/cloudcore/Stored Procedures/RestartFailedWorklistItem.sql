CREATE PROCEDURE [cloudcore].[RestartFailedWorklistItem]
	@InstanceId int
AS

UPDATE [cloudcore].Worklist
	SET StatusTypeId = 0
WHERE InstanceId = @InstanceId
AND	  StatusTypeId = 101


	 


	
