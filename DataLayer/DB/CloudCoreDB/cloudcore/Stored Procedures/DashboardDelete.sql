create procedure [cloudcore].[DashboardDelete]
	@DashboardID int
AS
begin
  delete from [cloudcore].DashboardRight where DashboardId = @DashboardID
  delete from [cloudcore].Dashboard where DashboardId = @DashboardID
end