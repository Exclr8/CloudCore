cd ..
FOR /F "tokens=*" %%G IN ('DIR /B /A /S packages.config') DO .nuget\nuget.exe install -o packages "%%G"