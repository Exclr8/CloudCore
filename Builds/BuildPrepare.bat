@echo off
echo Starting Cleanup at %time%
RMDIR /S /Q NugetTemp
RMDIR /S /Q NugetPackaged
echo Updating Dependencies
../NuspecDependencyGenerator.exe
echo Creating Nuget Build Folders
MKDIR NugetPackaged
MKDIR NugetTemp
cd NugetTemp
MKDIR Assets
MKDIR lib
cd lib
MKDIR net45
cd..
cd..
cd..
echo Removing Previous Build Binaries
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
echo Downloading latest packages
FOR /F "tokens=*" %%G IN ('DIR /B /A /S packages.config') DO .nuget\nuget.exe install -o packages "%%G"
cd Builds