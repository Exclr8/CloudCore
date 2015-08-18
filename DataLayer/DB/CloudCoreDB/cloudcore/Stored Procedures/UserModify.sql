create procedure [cloudcore].[UserModify]
    @UserId int,
    @Initials varchar(15),
    @Firstnames varchar(100),
    @Surname varchar(30),
    @Cellno varchar(15),
    @Email varchar(255)
as
begin

    if exists (select null 
                 from [cloudcore].[User]
                where Email = @Email
                  and UserId <> @UserId)
    begin
        raiserror(N'The specified email already exists in the database, please enter a unique email.',18, 1) 
        return
    end

    update [cloudcore].[User] 
       set Initials = @Initials,
           Firstnames = @Firstnames,
           Surname = @Surname,
           CellNo = @Cellno,
           Email = @Email
     where UserId = @UserId
end