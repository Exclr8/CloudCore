CREATE PROCEDURE [cloudcore].[UserPasswordUpdate]
    @UserId int,
    @PasswordHash varchar(200)
as
begin
    update [cloudcore].[User]
    set PasswordHash = @PasswordHash,
        PasswordChanged = GETDATE(),
        ReferenceGuid = null 
    where UserId = @UserId
end