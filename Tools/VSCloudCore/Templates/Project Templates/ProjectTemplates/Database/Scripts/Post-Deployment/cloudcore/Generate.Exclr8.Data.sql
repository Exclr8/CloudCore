declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'

if isnull(@BuildConfigMode, 'Debug') = 'Release'
begin
    declare @stringToPrint varchar(50) 
    set @stringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' mode. Framework One user data will NOT be included.'
    print @stringToPrint
    set noexec on;
end
go

set identity_insert [cloudcore].[User] on
GO
        insert into [cloudcore].[User] (UserId, [Login], PasswordHash, Email, Initials, Firstnames, Surname, IntAccess, Created, CellNo, PasswordChanged) 
                   values 
                          
                          (1, 'ahm', '3354481600540322a9334e9a8d5136371____', 'ahm@frameworkone.co.za', 'AH', 'Alexander', 'Mehlhorn', 1, GETDATE(), '0824951496', GETDATE()),
                          (2, 'jhr', 'dfd691b80b061f04638e3d419c2a66e72____', 'jhr@frameworkone.co.za', 'J','Johan', 'van Tonder', 1, GETDATE(), '0720761226', GETDATE()),
                          (3, 'wou', 'ec6f9f50aa6e4340ac5cb5ecd551cca53____', 'wou@frameworkone.co.za', 'W', 'Wouter', 'Olivier', 1, GETDATE(), '0712005534', GETDATE()),
                          (4, 'spx', '6e770c9bb7dc5d4278f68ba2584324324____', 'spx@frameworkone.co.za', 'S','Stephan', 'Pienaar', 1, GETDATE(), '0828149009', GETDATE()),
                          (5, 'lyb', '50e87a566aba74b9fa44b39c6e6ab3b57____', 'lyb@frameworkone.co.za', 'L',  'Lyon', 'Blecher', 1, GETDATE(), '0784594955', GETDATE()),
						  (7, 'whw', '9dab3c1a5b299de7c4dade07ca173dba11___', 'whw@frameworkone.co.za', 'WH', 'Walter', 'Weder', 1, GETDATE(), '0763798805', GETDATE()),
						  (8, 'brg', '6e770c9bb7dc5d4278f68ba2584324324____', 'brg@frameworkone.co.za', 'B', 'Brendon', 'Greyling', 1, GETDATE(), '0723173766', GETDATE())

        go
    set identity_insert [cloudcore].[User] off
GO 

update [cloudcore].[User] set IsAdministrator = 1 where UserId  between 1 and 7
go

update  U
set     U.PasswordHash = cloudcore.CreatePasswordHash(U.UserId, 'password')
from    cloudcore.[user] U
where   UserId > 0
go

-- Update userAccessMappings
insert into cloudcore.UserAccessMapping(ProviderId,UserId,UserKey)
select 1,UserId,UserKey
from cloudcore.[user] where UserId > 0

GO

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
   select AP.AccessPoolId, U.UserId
      from cloudcore.AccessPool AP
      cross join cloudcore.[User] U 
	 where UserId >0
	 
go

set noexec off;
go

