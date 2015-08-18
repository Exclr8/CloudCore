create Procedure [cloudcore].[LoginDetailsGet]
@Login VARCHAR (320), @UserId INT OUTPUT, @PasswordHash VARCHAR (64) OUTPUT
AS
begin
  set @PasswordHash = 'x0x'
  set @UserId = -1

  -- get the user details
  select @PasswordHash = isnull(U.PasswordHash, ''), 
         @UserId = U.UserId
    from [cloudcore].[User] U
   where U.[Login] = @Login and U.Active = 1 and isnull(U.PasswordHash,'')<>''
  
   if (@UserId = -1) and exists(select Active from [cloudcore].[User] where [Login] = @Login and Active = 0)
   begin
     raiserror ('User account is not active. Please contact your system administrator.', 16, 2)
     return
   end 

   if (@UserId > -1) and not exists(select null from [cloudcore].AccessPoolUser where UserId = @UserId and AccessPoolId > 0)
   begin
     raiserror ('This user has not been granted any access rights.', 16, 2)
     return
   end 
end