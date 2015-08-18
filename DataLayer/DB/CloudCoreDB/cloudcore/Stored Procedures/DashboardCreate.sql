create procedure [cloudcore].[DashboardCreate]
	@DashboardID int output,
	@SystemModuleId int,
	@Title varchar(100),
	@Description varchar(MAX),
	@IntervalInMinutes int,
	@DashboardGuid uniqueidentifier
as
  begin
	if not exists (select null from [cloudcore].Dashboard where DashboardGuid = @DashboardGuid)
	  begin
		insert into [cloudcore].Dashboard (SystemModuleId, Title, [Description], DashboardGuid, IntervalInMinutes) 
		     values (@SystemModuleId, @Title, @Description, @DashboardGuid, @IntervalInMinutes)

		set @DashboardID = scope_identity()
	  end
  end