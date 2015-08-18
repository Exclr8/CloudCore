CREATE PROCEDURE [cloudcore].[DashboardFailed]
	@DashboardId bigint,
	@Reason varchar(max),
	@StatusTypeId tinyint
as
  begin
	
	if (@StatusTypeId not in (42, 101))
	begin
		raiserror('Invalid status type specified for work list failure update. Allowed values are: 42 (Retry) and 101 (Failed).', 16 ,1)
		return
	end
	
	insert into cloudcore.DashboardFailure(DashboardId, Reason)
	values (@DashboardId, @Reason)

	update d
	set d.StatusId = @StatusTypeId
	from cloudcore.Dashboard as d 
	where d.DashboardId = @DashboardId
  end