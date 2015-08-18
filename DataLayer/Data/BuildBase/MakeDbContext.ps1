Param (    
    $server = "localhost",
    $database = "CloudCoreDB",
    $dataContextName = "CloudCoreDBBase",
    $namespace = "CloudCore.Data"
)

$ErrorActionPreference = "stop"

try
{

    $contextFileName = $dataContextName + ".cs"

    $sqlMetalPath = "C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\sqlmetal.exe"

    $serverParam = "/server:$server"
    $namespaceParam = "/namespace:$namespace"
    $dbParam = "/database:$database"
    $codeParam = "/code:$contextFileName"
    $contextParam = "/context:$dataContextName"

    & $sqlMetalPath $serverParam $namespaceParam $dbParam $codeParam /views /functions /sprocs /language:c# $contextParam

    exit 0
}
catch [System.Exception]
{
    throw $_.Exception.ToString()
    exit 1
}