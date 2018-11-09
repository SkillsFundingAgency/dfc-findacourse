param (
    [Parameter(Mandatory=$true)][string]$ARMOutput
)

# Output from ARM template is a JSON document
$jsonvars = $ARMOutput | convertfrom-json

# the outputs with be of type noteproperty, get a list of all of them
foreach ($outputname in ($jsonvars | Get-Member -MemberType NoteProperty).name) {
    # get the type and value for each output
    $outtypevalue = $jsonvars | Select-Object -ExpandProperty $outputname
    $outtype = $outtypevalue.type
    $outvalue = $outtypevalue.value

    # Set VSTS variable
    Write-Host "Creating VSTS variable $outputname - $outvalue [$outtype]"
    if ($outtype.toLower() -eq 'securestring') {
        Write-Host "##vso[task.setvariable variable=$outputname;issecret=true]$outvalue"
    }
    else {
        Write-Host "##vso[task.setvariable variable=$outputname]$outvalue"
    }
}
