@echo off 
del /Q /F "NuGetTemp\*.*"  
del /Q /F "NuGetTemp\lib\net45\*.*"  
cd NuGetTemp
copy "..\NuSpec\*.nuspec"
cd lib
cd net45
copy /Y "..\..\..\..\Azure Deployment\Site\bin\CloudCore.Core.dll"
copy /Y "..\..\..\..\Azure Deployment\Site\bin\CloudCore.Core.pdb"
copy /Y "..\..\..\..\DataLayer\Data\bin\CloudCore.Core.Data.dll" 
copy /Y "..\..\..\..\DataLayer\Data\bin\CloudCore.Core.Data.pdb"
copy /Y "..\..\..\..\System Modules\CUI\bin\Release\CloudCore.Web.dll"
copy /Y "..\..\..\..\System Modules\CUI\bin\Release\CloudCore.Web.pdb"
copy /Y "..\..\..\..\System Modules\Admin\bin\Release\CloudCore.Admin.dll"
copy /Y "..\..\..\..\System Modules\Admin\bin\Release\CloudCore.Admin.pdb"
copy /Y "..\..\..\..\Core Libraries\CloudCore.Web.Core\bin\Release\CloudCore.Web.Core.dll"
copy /Y "..\..\..\..\Core Libraries\CloudCore.Web.Core\bin\Release\CloudCore.Web.Core.pdb"
copy /Y "..\..\..\..\Core Libraries\CloudCore.VirtualWorker\bin\Release\CloudCore.VirtualWorker.dll"
copy /Y "..\..\..\..\Core Libraries\CloudCore.VirtualWorker\bin\Release\CloudCore.VirtualWorker.pdb"
copy /Y "..\..\..\..\DataLayer\DB\CloudCoreDB\bin\Release\CloudCoreDB.dll" 
copy /Y "..\..\..\..\DataLayer\DB\CloudCoreDB\bin\Release\CloudCoreDB.dacpac" 
copy /Y "..\..\..\..\DataLayer\DB\CloudCoreDB\bin\Output\CloudCoreDB.publish.sql"
copy /Y "..\..\..\..\Tools\Architect\ProcessOverview\DslPackage\bin\Release\*.vsix" 
copy /Y "..\..\..\..\Tools\Architect\DslPackage\bin\Release\*.vsix" 
copy /Y "..\..\..\..\Tools\Architect\ScheduledTasks\DslPackage\bin\Release\*.vsix" 
copy /Y "..\..\..\..\Tools\VSCloudCore\VS.Package\bin\Release\CloudCore.VSExtension.vsix"
cd..
cd..
xcopy /S/Y "..\..\Azure Deployment\Site\bin\Assets" ".\Assets\"
