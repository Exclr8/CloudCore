@echo off 
del /Q /F "Deployment\*.*" 
cd Deployment 
copy "..\..\Azure Deployment\Azure\bin\Release\*.cspkg" 
copy "..\..\Azure Deployment\Azure\bin\Release\*.cscfg" 
copy "..\..\Azure Deployment\Azure\PublishProfiles\*.*" 
cd ..

