CREATE PROCEDURE [cloudcore].[ScheduledTaskGroupUpdate]
	@ScheduledTaskGroupId int = 0,
	@ScheduledTaskGroupName varchar(50),
	@ManagerUserId int
as
  begin
  	if exists (select null from cloudcore.ScheduledTask where ScheduledTaskName = @ScheduledTaskGroupName and ScheduledTaskId <> @ScheduledTaskGroupId)
	  begin
		raiserror('A Scheduled Task Group with the selected name already exists!',16,1)
		return
      end

	update cloudcore.ScheduledTaskGroup 
	set ScheduledTaskGroupName = @ScheduledTaskGroupName,
	    ManagerUserId = @ManagerUserId
    where ScheduledTaskGroupId = @ScheduledTaskGroupId
  end