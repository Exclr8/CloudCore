@echo off 
call preparenugetartifacts.bat
cd..
NuspecDependencyGenerator.exe
cd Builds
