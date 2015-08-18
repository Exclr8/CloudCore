create procedure [cloudcore].[DashboardRightCreate]
	@DashboardId int,
	@AccessPoolId int
as
begin
	if exists (select DashboardId
				 from [cloudcore].DashboardRight
				where DashboardId = @DashboardId and 
				      AccessPoolId = @AccessPoolId)
				      begin
							raiserror(N'The access right has already been configured for this item', 18,1)
							return
				      end
				      
  insert into [cloudcore].DashboardRight (DashboardId,AccessPoolId) values (@DashboardId, @AccessPoolId)
end