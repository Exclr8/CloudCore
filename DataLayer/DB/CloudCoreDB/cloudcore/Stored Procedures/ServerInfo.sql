create procedure [cloudcore].ServerInfo
@DBName varchar(256)
as
begin
	select top 1 SERVERPROPERTY('ComputerNamePhysicalNetBIOS') servername, @@VERSION version,
		   SERVERPROPERTY('ProductVersion') ProductVersion,
		   SERVERPROPERTY('ProductLevel') ProductLevel,
		   SERVERPROPERTY('Edition') Edition
end