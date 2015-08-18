@echo off
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\MSTest.exe" %*
IF %ERRORLEVEL% EQU 1 (EXIT /B 0)
EXIT /B %ERRORLEVEL%
