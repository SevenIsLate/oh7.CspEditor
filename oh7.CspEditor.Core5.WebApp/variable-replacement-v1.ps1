Write-Host "Environment Variable Substitution"

$variables = gci $env:$env:APPLICATION_PREFIX* | Select-Object -Property Key, Value

$configPath = "$env:APPLICATION_PATH\$env:CONFIG_FILE"

Write-Output "Loading config file from $configPath"
$appSettings = Get-Content -Raw $configPath | ConvertFrom-Json

foreach($variable in $variables) {
    $matchString = $variable.Key.replace($env:APPLICATION_PREFIX, "")

    $matchProperties = $matchString.Split(".")

    if($matchProperties.Count -gt 1) {
        $match = $appSettings.($matchProperties[0]).psobject.properties | where { $_.Name -eq $matchProperties[1] } 
        if ($match) {
            $appSettings.($matchProperties[0]).($matchProperties[1]) = $variable.Value
        }
        else {
            Write-Output "Could not find match for $matchString"
        }
    }
    else {
        $match = $appSettings.psobject.properties | where { $_.Name -eq $matchString } 
        if ($match) {
            $appSettings.($matchString) = $variable.Value
        }
        else {
            Write-Output "Could not find match for $matchString"
        }
    }
}

$appSettings | ConvertTo-Json -depth 100 | Out-File $configPath