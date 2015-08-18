CREATE FUNCTION [cloudcore].[CreatePasswordHash](@UserId int, @Password varchar(100))
RETURNS varchar(200)
AS
BEGIN
    declare @salt varchar(5) = cloudcore.fn_strPadRight(cast(@UserId as varchar), 5, '_') 
    declare @hash varchar(40) = cloudcore.fn_varbintohexstr(HashBytes('MD5', @Password + @salt))
    declare @PHash varchar(200) = SUBSTRING(@hash, 3, 32) + @salt

	return lower(@PHash)
END