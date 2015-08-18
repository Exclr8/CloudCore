@ECHO OFF
SET sn="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools\sn.exe"
%sn% -p Key.snk Key.PublicKey
%sn% -tp Key.PublicKey
PAUSE
