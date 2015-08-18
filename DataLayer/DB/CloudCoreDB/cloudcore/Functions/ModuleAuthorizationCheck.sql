CREATE FUNCTION [cloudcore].ModuleAuthorizationCheck (@IntAccess bit, @ExtAccess bit, @UserId int )
RETURNS bit
AS
begin
  return case when exists(  select  NULL
                              from cloudcore.[User] U 
							 where UserId = @UserId 
							   and IntAccess = @IntAccess
							   and ExtAccess = @ExtAccess

            ) then 1 else 0 end

end