create procedure [cloudcore].UserUpdateAccess
@UserId int,
@InternalAccess bit,
@ExternalAccess bit,
@IsAdministrator bit = null
as
begin
    update [cloudcore].[User] 
    set IsAdministrator = isnull(@IsAdministrator, IsAdministrator),
        IntAccess = @InternalAccess,
        ExtAccess = @ExternalAccess
    where UserId = @UserId
end
