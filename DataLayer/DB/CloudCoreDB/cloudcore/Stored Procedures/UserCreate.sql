create procedure [cloudcore].UserCreate
@Login varchar(320),
@Email varchar(255),
@Initials varchar(15),
@Firstnames varchar(100),
@Surname varchar(30),
@CellNo varchar(15),
@IntAccess bit,
@ExtAccess bit,
@UserId int output
as
begin

    if exists (select null 
                 from [cloudcore].[User]
                where Login = @Login)
    begin
        raiserror(N'The specified login already exists in the database, please enter a unique login.',18, 1) 
        return
    end 

    if exists (select null 
                 from [cloudcore].[User]
                where Email = @Email)
    begin
        raiserror(N'The specified email already exists in the database, please enter a unique email.',18, 1) 
        return
    end

    begin
        Insert into [cloudcore].[User]([Login], Email, Initials, Firstnames, Surname, CellNo, IntAccess, ExtAccess)
        values (@Login, @Email, @Initials, @Firstnames, @Surname, @CellNo, @IntAccess, @ExtAccess)

        set @UserId = SCOPE_IDENTITY()

		Insert into [cloudcore].UserAccessMapping(ProviderId,UserId,UserKey)
		    select 1, @UserId, u.UserKey from cloudcore.[User] u where u.UserId = @UserId

		-- make this user part of "CloudCore System User"
        insert into cloudcore.AccessPoolUser(AccessPoolId, UserId) values (0, @UserId)
    end
end
