$versionFile = Get-Item -Path '.\*.version'
$versionParts = (Split-Path $versionFile -Leaf).Split(" ")

$version = "$(Get-Date -Format 'yyyy.MM.dd.HHmm').$($versionParts[1])"
$targetFile = ".\_releases\SRJ.Theme.$version.zip"

Write-Host $targetFile

Compress-Archive -Path '.\*.version' -DestinationPath $targetFile
Compress-Archive -Path '.\Plugins' -Update -DestinationPath $targetFile
Compress-Archive -Path '.\sounds' -Update -DestinationPath $targetFile
