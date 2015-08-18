CREATE PROCEDURE [cloudcore].[ScheduledTaskUpdateConfig]
	@ScheduledTaskId int, 
	@ScheduledTaskName varchar(50),
	@IntervalValue int,
	@IntervalType tinyint,
	@NextRunDate datetime = null,
    @NotifyEmail varchar(255),
	@IsActive bit
as
  begin
	
	if exists (select null from cloudcore.ScheduledTask where ScheduledTaskName = @ScheduledTaskName and ScheduledTaskId <> @ScheduledTaskId)
	  begin
		raiserror('A Scheduled Task with the selected name already exists!',16,1)
		return
	  end

	update cloudcore.ScheduledTask
	set ScheduledTaskName = @ScheduledTaskName,
	    IntervalValue = @IntervalValue,
		IntervalType = @IntervalType,
		NextRunDate = isnull(@NextRunDate,NextRunDate),
		Active = @IsActive,
        StatusId = case when @IsActive = 1 then 
                            case when StatusId = 101 then 0 else StatusId end
                        else 
                            100
                   end,
        NotifyEmail = @NotifyEmail
	where ScheduledTaskId = @ScheduledTaskId

  end