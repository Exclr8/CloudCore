/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.					
--------------------------------------------------------------------------------------
*/

exec sp_msforeachtable 'alter table ? nocheck constraint all'
go
exec sp_msforeachtable 'alter table ? disable trigger all'
go


:r "01 - Generate System Data.sql"
go

:r "02 - Generate Administration Data.sql"
go

:r "03 - Generate Framework One Data.sql"
go

:r "04 - Test-Data.sql"
go

set noexec off
go

exec sp_msforeachtable 'alter table ? enable trigger all'
go
exec sp_msforeachtable 'alter table ? WITH CHECK check constraint all'
go

