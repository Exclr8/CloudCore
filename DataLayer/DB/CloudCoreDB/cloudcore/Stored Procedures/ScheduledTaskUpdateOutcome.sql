CREATE PROCEDURE [cloudcore].[ScheduledTaskUpdateOutcome]
	@ScheduledTaskId int,
	@StatusId tinyint, 
	@Reason varchar(max) = null
as
begin
	if @StatusId not in (0, 42, 101)
    begin
        raiserror('Invalid status ID specified for "ScheduledTaskUpdateOutcome". Allowed values are: 0 (Pending), 42 (Retry) and 101 (Failed).', 16, 1)
        return
    end

    if @StatusId in (42,101)
	BEGIN
        if len(isnull(rtrim(@Reason), '')) = 0
        begin
            raiserror('The @Reason parameter is required when using "ScheduledTaskUpdateOutcome" to indicate @StatusId of Retry (42) or Failure (101).', 16, 1)
            return
        end

	    insert into cloudcore.ScheduledTaskFailed (ScheduledTaskId, Reason)
             values (@ScheduledTaskId, @Reason)
	END

	update  ST
	set     ST.StatusId = @StatusId,
            ST.OnDemand = 0,
	        ST.NextRunDate = case when @StatusId = 0 then [cloudcore].CalculateNextRunDate(ST.InitDate, ST.IntervalType, ST.IntervalValue) else ST.NextRunDate end,
		    ST.InitDate = case when @StatusId = 0 then [cloudcore].CalculateNextInitDate(ST.InitDate, ST.IntervalType, ST.IntervalValue) else ST.InitDate end -- shifting along
    from    cloudcore.ScheduledTask ST
	where   ST.ScheduledTaskId = @ScheduledTaskId
end
