param (
    [Parameter(Mandatory=$true)][string]$ARMOutput
)

# Output from ARM template is a JSON document
$jsonvars = $ARMOutput | convertfrom-json

# VSTS variables to be extracted from JSON
$storageAccountName = $jsonvars.storageAccountName.value
$storageConnectionString = $json.storageConnectionString.value
$appName = $jsonvars.appServiceName.value

# Write these out as VSTS variables
Write-Host "##vso[task.setvariable variable=storageAccountName]$storageAccountName"
Write-Host "##vso[task.setvariable variable=storageConnectionString]$storageConnectionString"
Write-Host "##vso[task.setvariable variable=appName]$appName"
