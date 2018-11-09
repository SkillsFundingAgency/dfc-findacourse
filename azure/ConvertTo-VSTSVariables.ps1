param (
    [Parameter(Mandatory=$true)][string]$ARMOutput
)

# Output from ARM template is a JSON document
$jsonvars = $ARMOutput | convertfrom-json
Write-Host $jsonvars

# VSTS variables to be extracted from JSON
$storageAccountName = $jsonvars.storageAccountName.value
$storageConnectionString = $json.storageConnectionString.value
$appName = $jsonvars.appServiceName.value
$appInsights = $jsonvars.appInsightInstrumentationKey.value
$appInsightAppId = $jsonvars.appInsightAppId.value

# Write these out as VSTS variables
Write-Host "##vso[task.setvariable variable=storageAccountName]$storageAccountName"
Write-Host "##vso[task.setvariable variable=storageConnectionString]$storageConnectionString"
Write-Host "##vso[task.setvariable variable=appName]$appName"
Write-Host "##vso[task.setvariable variable=appInsights]$appInsights"
Write-Host "##vso[task.setvariable variable=appInsightAppId]$appInsightAppId"
