create procedure [cloudcore].[DashboardModify]
	@DashboardId int,
	@Title varchar(100),
	@Description varchar(MAX)
as
begin
  update [cloudcore].Dashboard
	 set Title = @Title,
	     [Description] = @Description
   where DashboardId = @DashboardId
end