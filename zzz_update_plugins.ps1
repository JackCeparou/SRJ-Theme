function CopyFiles {
    param( [string]$Source, [string]$Destination )
    Write-Host " Copy file(s) '$Source' to '$Destination'"
    Copy-Item -Path $Source -Destination $Destination -Force -ErrorAction SilentlyContinue # -WhatIf -Verbose
}

#Plugins
$buildFiles = Get-ChildItem -Path '.\Plugins\**\.files' -Recurse
foreach($buildFile in $buildFiles) {
    Write-Host $buildFile
    $targetFolder = Split-Path -Path $buildFile -Parent
    $buildContent = Get-Content -Path $buildFile
    foreach($line in $buildContent){
        if ($line.StartsWith("#")) {
            # Write-Host $line
        }
        else {
            CopyFiles $line $targetFolder
        }
    }
}

#Resu Sounds
CopyFiles .\Resu\sounds\*.* .\sounds\