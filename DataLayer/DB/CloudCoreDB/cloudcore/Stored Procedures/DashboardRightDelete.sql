create procedure [cloudcore].[DashboardRightDelete]
	@DashboardID int,
	@AccessPoolId int 
as
begin
	delete from [cloudcore].DashboardRight 
	 where DashboardId = @DashboardID 
	   and AccessPoolId = @AccessPoolId
end