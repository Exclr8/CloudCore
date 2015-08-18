Param(
        $serviceName = "f1cirrustest",
        $storageAccountName = "f1cirrusteststorage",
        $packageLocation = "Deployment\Azure.cspkg",
        $cloudConfigLocation = "Deployment\ServiceConfiguration.Cloud.cscfg",
        $environment = "Production",
        $deploymentLabel = "Continuous Deployment to $servicename",
        $timeStampFormat = "g",
        $replaceExistingDeployment = 1,
        $enableDeploymentUpgrade = 1,
        $subscriptionName = "f1bizplus",
        $publishSettingsFile = "Deployment\BizSparkForJHR.publishsettings",
		$subscriptionId = "6d21ffe2-c9ad-445d-9ffa-ace31069963a",
		$certificateThumb = "08093f3e4c79739d0ddea074016b81739c6a2502"
     )

$ErrorActionPreference = "Stop"
$uploadedDeployment = $null

function Publish()
{
    $deployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment -ErrorVariable a -ErrorAction SilentlyContinue
    
	if ($a[0] -ne $null)
    {
        Write-Output "$(Get-Date –f $timeStampFormat) - No deployment is detected. Creating a new deployment. "
    }
	
    if ($deployment.Name -ne $null)
    {
        switch ($replaceExistingDeployment)
        {
            1 
            {                          
                switch ($enableDeploymentUpgrade)
                {
                    1  #Update deployment inplace (usually faster, cheaper, and won't change the public IP address)
                    {
                        Write-Output "$(Get-Date –f $timeStampFormat) - Deployment exists in $servicename.  Upgrading deployment."
                        UpgradeDeployment
                    }
                    0  #Delete then create new deployment (warning: this will change the public IP address)
                    {
                        Write-Output "$(Get-Date –f $timeStampFormat) - Deployment exists in $servicename.  Deleting deployment."
                        DeleteDeployment
                        CreateNewDeployment

                    }
                } 
            }
            0
            {
                Write-Output "$(Get-Date –f $timeStampFormat) - ERROR: Deployment exists in $servicename.  Script execution cancelled."
                exit 1
            }
        } 
    } else {
            CreateNewDeployment
    }
}

function CreateNewDeployment()
{
    write-progress -id 3 -activity "Creating New Deployment" -Status "In progress"
    Write-Output "$(Get-Date –f $timeStampFormat) - Creating New Deployment: In progress"
	
    $opstat = New-AzureDeployment -Slot $environment -Package $packageLocation -Configuration $cloudConfigLocation -label $deploymentLabel -ServiceName $serviceName

    $uploadedDeployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment
    $uploadedDeploymentID = $uploadedDeployment.deploymentid

    write-progress -id 3 -activity "Creating New Deployment" -completed -Status "Complete"
    Write-Output "$(Get-Date –f $timeStampFormat) - Creating New Deployment: Complete, Deployment ID: $uploadedDeploymentID"

    StartInstances
}

function UpgradeDeployment()
{
    write-progress -id 3 -activity "Upgrading Deployment" -Status "In progress"
    Write-Output "$(Get-Date –f $timeStampFormat) - Upgrading Deployment: In progress"

    # perform Update-Deployment
    $uploadedDeployment = Set-AzureDeployment -Upgrade -Slot $environment -Package $packageLocation -Configuration $cloudConfigLocation -label $deploymentLabel -ServiceName $serviceName -Force

    $uploadedDeployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment
    $uploadedDeploymentID = $uploadedDeployment.deploymentid

    write-progress -id 3 -activity "Upgrading Deployment" -completed -Status "Complete"
    Write-Output "$(Get-Date –f $timeStampFormat) - Upgrading Deployment: Complete, Deployment ID: $uploadedDeploymentID"
}

function DeleteDeployment()
{

    write-progress -id 2 -activity "Deleting Deployment" -Status "In progress"
    Write-Output "$(Get-Date –f $timeStampFormat) - Deleting Deployment: In progress"

    #WARNING - always deletes with force
    $removeDeployment = Remove-AzureDeployment -Slot $environment -ServiceName $serviceName -Force

    write-progress -id 2 -activity "Deleting Deployment: Complete" -completed -Status $removeDeployment
    Write-Output "$(Get-Date –f $timeStampFormat) - Deleting Deployment: Complete"

}

function StartInstances()
{
    write-progress -id 4 -activity "Starting Instances" -status "In progress"
    Write-Output "$(Get-Date –f $timeStampFormat) - Starting Instances: In progress"

    $uploadedDeployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment
    $runstatus = $uploadedDeployment.Status

    if ($runstatus -ne 'Running') 
    {
        $run = Set-AzureDeployment -Slot $environment -ServiceName $serviceName -Status Running
    }
	    
	$triesElapsed = 0
	$maximumRetries = 8
	$waitInterval = [System.TimeSpan]::FromSeconds(60)
	Do
	{
		Write-Output "Checking if all role instances are ready..."		
		$roleInstances = $uploadedDeployment.RoleInstanceList
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

		if ($triesElapsed -ge $maximumRetries)
		{
			$totalSeconds = $waitInterval.Seconds * $triesElapsed
			throw "Startup is taking longer than $totalSeconds seconds..."
		}
		else
		{
			$triesElapsed += 1
			[System.Threading.Thread]::Sleep($waitInterval)
		    $uploadedDeployment = Get-AzureDeployment -ServiceName $serviceName -Slot $environment
		}
	}
	While($triesElapsed -le $maximumRetries)
}

try
{
	Import-Module Azure
	Import-AzurePublishSettingsFile –PublishSettingsFile $publishSettingsFile  –SubscriptionDataFile "SubscriptionData.xml"

	$cert = Get-Item cert:\\CurrentUser\My\$certificateThumb
	Set-AzureSubscription -CurrentStorageAccount $storageAccountName -SubscriptionName $subscriptionName -SubscriptionId $subscriptionId -Certificate $cert -SubscriptionDataFile "SubscriptionData.xml"
	Select-AzureSubscription "$subscriptionName" -SubscriptionDataFile "SubscriptionData.xml"
	
	Write-Output "$(Get-Date –f $timeStampFormat) - Azure Cloud Service deploy script started."
	Write-Output "$(Get-Date –f $timeStampFormat) - Preparing deployment of $deploymentLabel for $subscriptionName with Subscription ID $subscriptionId."

	Publish

	$deployment = Get-AzureDeployment -slot $environment -serviceName $servicename
	$deploymentUrl = $deployment.Url
	
	Remove-AzureSubscription "$subscriptionName" -Force -SubscriptionDataFile "SubscriptionData.xml"

	Write-Output "$(Get-Date –f $timeStampFormat) - Created Cloud Service with URL $deploymentUrl."
	Write-Output "$(Get-Date –f $timeStampFormat) - Azure Cloud Service deploy script finished."
	exit 0
}
catch [System.Exception]
{
    Write-Host $_.Exception.ToString()
    exit 1
}

