set certpassword=asd12345_
certutil -delstore "My" "F1.CloudCore.Development"
certutil -delstore "Root" "F1.CloudCore.Development"
certutil -f -p "%certpassword%" -importPFX cloudcore.pfx