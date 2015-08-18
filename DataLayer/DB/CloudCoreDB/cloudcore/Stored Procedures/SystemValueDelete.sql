create procedure [cloudcore].SystemValueDelete 
	@SystemValueId int
as
begin
	delete
	  from cloudcore.SystemValue
	 where ValueID = @SystemValueId
end