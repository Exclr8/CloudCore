/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

use [$(DatabaseName)]
GO

exec sp_msforeachtable 'alter table ? nocheck constraint all'
go
exec sp_msforeachtable 'alter table ? disable trigger all'
go


:r ".\cloudcore\01 - Generate System Data.sql"
go

:r ".\cloudcore\02 - Generate Administration Data.sql"
go

:r ".\cloudcore\03 - Generate Exclr8 Data.sql"
go



exec sp_msforeachtable 'alter table ? enable trigger all'
go
exec sp_msforeachtable 'alter table ? WITH CHECK check constraint all'
go
