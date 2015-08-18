@echo off
echo Removing previous test results in directories...
for /f "tokens=*" %%i in ('dir /b /s *.trx') do del /Q /F "%%i"
echo Previous test results in directories removed.
echo Running tests...
"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" %* /logger:trx /Framework:Framework45
echo Combining all test result files (*.trx) into one...
for /f "tokens=*" %%i in ('dir /b /s *.trx') do (type "%%i">>LastTestResults.trx)
echo File "LastTestResults.trx" created.
IF %ERRORLEVEL% EQU 1 (EXIT /B 0)
EXIT /B %ERRORLEVEL%
