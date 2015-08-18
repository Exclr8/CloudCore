Param(
        $serviceName = "f1cirrustest",
        $storageAccountName = "f1cirrusteststorage",
        $environment = "Production",
        $timeStampFormat = "g",
        $subscriptionName = "f1bizplus",
        $publishSettingsFile = "..\Azure Deployment\Azure\PublishProfiles\BizSparkForJHR.publishsettings",
		$subscriptionId = "6d21ffe2-c9ad-445d-9ffa-ace31069963a",
		$certificateThumb = "08093f3e4c79739d0ddea074016b81739c6a2502"

     )

$ErrorActionPreference = "Stop"

try
{
	Import-Module Azure
	Import-AzurePublishSettingsFile –PublishSettingsFile $publishSettingsFile  –SubscriptionDataFile "SubscriptionData.xml"

	$cert = Get-Item cert:\\CurrentUser\My\$certificateThumb
	Set-AzureSubscription -CurrentStorageAccount $storageAccountName -SubscriptionName $subscriptionName -SubscriptionId $subscriptionId -Certificate $cert -SubscriptionDataFile "SubscriptionData.xml"
	Select-AzureSubscription "$subscriptionName" -SubscriptionDataFile "SubscriptionData.xml"
	
    $deployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment -ErrorVariable a -ErrorAction SilentlyContinue

	if ($deployment -ne $null)
	{
		$deploymentName = $deployment.Name
		
		if ($deployment.Name -ne $null)
		{
			Write-Output "$(Get-Date –f $timeStampFormat) - Stopping Azure Cloud Service $serviceName ($deploymentName) on the $environment environment."
			Stop-AzureService -ServiceName $serviceName -Slot $environment
			Write-Output "$(Get-Date –f $timeStampFormat) - Azure Cloud Service $serviceName ($deploymentName) on the $environment environment was stopped successfully."
		}
	}

	Remove-AzureSubscription "$subscriptionName" -Force -SubscriptionDataFile "SubscriptionData.xml"
	exit 0
}
catch [System.Exception]
{
    Write-Host $_.Exception.ToString()
    exit 1
}

