@ECHO OFF
SET sn="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\sn.exe"
%sn% -p cloudcore.snk cloudcore.PublicKey
%sn% -tp cloudcore.PublicKey
PAUSE
