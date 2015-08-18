set certpassword=asd12345_
makecert.exe -r -pe -a sha1 -n "CN=F1.CloudCore.Development, O=Framework One, OU=Development, L=Cape Town, C=ZA" -sr localMachine -ss root -sky exchange -b 01/01/2013 -e 01/01/2039 cloudcore.cer -sv cloudcore.pvk
pvk2pfx.exe -pvk cloudcore.pvk -pi %certpassword% -spc cloudcore.cer  -po %certpassword% -f -pfx cloudcore.pfx
REM sn -p cloudcore.pfx cloudcore.snk
CALL installcertificate.cmd