$versionFile = Get-Item -Path '.\*.version'
$versionParts = (Split-Path $versionFile -Leaf).Split(" ")

$buildNumber = $Env:BUILD_BUILDNUMBER
$v = $versionParts[1].Replace("(", "").Replace(")", "")
if ($null -eq $buildNumber) { # only exists in the build pipeline
    $buildNumber = Get-Date -Format "yyMMdd.HHmm"
    $buildNumber = "$buildNumber.$v"
}

$targetFile = ".\_releases\SRJ.Theme.$buildNumber.zip"

Write-Host $targetFile

Compress-Archive -Path '.\*.version' -DestinationPath $targetFile
Compress-Archive -Path '.\*.url' -Update -DestinationPath $targetFile
Compress-Archive -Path '.\Plugins' -Update -DestinationPath $targetFile
Compress-Archive -Path '.\sounds' -Update -DestinationPath $targetFile
