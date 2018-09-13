param (
    [Parameter(Mandatory=$true)][string]$ResourceGroup,
    [Parameter(Mandatory=$true)][string]$AppInsightName
)

Get-AzureRmApplicationInsightsApiKey -ResourceGroupName $ResourceGroup -Name $AppInsightName |
    Where-Object { $_.Description -eq "VSTSAnnotateKey" } | foreach {
        Write-Host "Deleting $($_.Description) [$($_.Id)]"
        Remove-AzureRmApplicationInsightsApiKey -ResourceGroupName $ResourceGroup -Name $AppInsightName -ApiKeyId $_.Id
}

$apikey = New-AzureRmApplicationInsightsApiKey -ResourceGroupName $ResourceGroup -Name $AppInsightName -Permissions WriteAnnotations -Description "VSTSAnnotateKey"
Write-Host "##vso[task.setvariable variable=appInsightApiKey]$($apikey.ApiKey)"
