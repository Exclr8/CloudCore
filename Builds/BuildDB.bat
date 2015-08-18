@echo off
echo Starting Deploy at %time%
echo -----------------------------------------------------------------------
REM Setting up enviroment variables
path = %path%;%systemroot%\Microsoft.NET\Framework\v4.0.30319;"c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools"
echo SQL METAL for CloudCore-----------------------------------------------------------------------
sqlmetal /server:localhost /namespace:CloudCore.Data.Buildbase /database:CloudCoreDB /code:"%~dp0\..\DataLayer\Data\BuildBase\CloudCoreDBbase.cs" /views /functions /sprocs /language:c# /context:CloudCoreDBBase
echo All Done! :)