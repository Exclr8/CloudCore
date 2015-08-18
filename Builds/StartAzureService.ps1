Param(
		$serviceName = "f1cirrustest",
        $storageAccountName = "f1cirrusteststorage",
        $environment = "Production",
        $timeStampFormat = "g",
        $subscriptionName = "f1bizplus",
        $publishSettingsFile = "Deployment\BizSparkForJHR.publishsettings",
		$subscriptionId = "6d21ffe2-c9ad-445d-9ffa-ace31069963a",
		$certificateThumb = "08093f3e4c79739d0ddea074016b81739c6a2502"
	 )

$ErrorActionPreference = "Stop"
$deployment = $null

function MonitorInstanceStartup()
{
	$triesElapsed = 0
	$maximumWaitCycles = 12
	$totalSeconds = 0
	$waitInterval = [System.TimeSpan]::FromSeconds(60)
	Do
	{
		Write-Output "Checking if all role instances are ready..."
		$deployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment
		
		$roleInstances = $deployment.RoleInstanceList
		$roleInstancesThatAreNotReady = $roleInstances | Where-Object { $_.InstanceStatus -ne "Ready" -and $_.InstanceStatus -ne "ReadyRole" }

		if ($roleInstances -ne $null -and
			$roleInstancesThatAreNotReady -eq $null)
		{
			Write-Output "All role instances are now ready"
			break
		}
		else
		{
			Foreach ($instance in $roleInstancesThatAreNotReady)
			{
				$name = $instance.InstanceName
				$status = $instance.InstanceStatus
				Write-Output "Instance $name is $status..."
			}			    
		}
		
		if ($triesElapsed -ge $maximumWaitCycles)
		{
			$totalSeconds = $waitInterval.Seconds * $triesElapsed
			throw "Startup is taking longer than $totalSeconds seconds..."
		}
		else
		{
			$triesElapsed += 1
			[System.Threading.Thread]::Sleep($waitInterval)
		}
	}
	While($triesElapsed -le $maximumWaitCycles)
}

try
{
	Import-Module Azure
	Import-AzurePublishSettingsFile –PublishSettingsFile $publishSettingsFile  –SubscriptionDataFile "SubscriptionData.xml"

	$cert = Get-Item cert:\\CurrentUser\My\$certificateThumb
	Set-AzureSubscription -CurrentStorageAccount $storageAccountName -SubscriptionName $subscriptionName -SubscriptionId $subscriptionId -Certificate $cert -SubscriptionDataFile "SubscriptionData.xml"
	Select-AzureSubscription "$subscriptionName" -SubscriptionDataFile "SubscriptionData.xml"
	
	$deployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment -ErrorVariable a #-ErrorAction SilentlyContinue
	$deploymentName = $deployment.Name
	
	if ($deployment.Name -ne $null)
	{
		Write-Output "$(Get-Date –f $timeStampFormat) - Starting Azure Cloud Service $serviceName ($deploymentName) on the $environment environment."
		Start-AzureService -ServiceName $serviceName -Slot $environment
		Write-Output "$(Get-Date –f $timeStampFormat) - Azure Cloud Service $serviceName ($deploymentName) on the $environment environment was started successfully."
		MonitorInstanceStartup
	}
		
	Remove-AzureSubscription "$subscriptionName" -Force -SubscriptionDataFile "SubscriptionData.xml"
	exit 0
}
catch [System.Exception]
{
	Write-Host $_.Exception.ToString()
	exit 1
}
