#Requires -Version 5

param ( [string[]] $Paths )

Add-Type -AssemblyName System.Windows.Forms

# Config :
$downloadFolder = "$HOME\Downloads"
$backupFolder = "..\_backup\_version"
$renamedExeName = "notepad"
# Constants :
$turboHudArchiveNamePattern = "TurboHUD*.zip"
#############################################
# Modify below this line at your own risk.  #
#############################################
$zipFile = ""
if ($Paths.Count -gt 1) {
    throw "Too much paths..."
}
elseif ($Paths.Count -eq 1 -and $Paths[0] -ne '') {
    #TODO: sanity checks
    $zipFile = $Paths[0]
}
else {
    # move files from downloads
    Write-Host "Move downloaded hud archives"
    $sourcePattern = Join-Path $downloadFolder $turboHudArchiveNamePattern
    Move-Item -Path $sourcePattern -Destination $backupFolder

    # get path of last version archive
    $archive = Get-ChildItem -Path $backupFolder -Filter $turboHudArchiveNamePattern | Sort-Object LastWriteTime | Select-Object -Last 1
    $zipFile = "$backupFolder\$archive"
}

Write-Host "Archive selected $zipFile"
if ($null -eq $zipFile -or "" -eq $zipFile) {
    throw "Archive '$zipFile' file not found!"
}

# cleanup hud folder
Write-Host "Clean up hud folder"
function DeleteFolder {
    param( [string]$Path )
    Write-Host " Remove folder '$Path'"
    Remove-Item -Path $Path -Force -Recurse -ErrorAction SilentlyContinue
}
DeleteFolder ".\Plugins\Default"
DeleteFolder ".\Interfaces"
DeleteFolder ".\Snapshots"
DeleteFolder ".\Logs"
DeleteFolder ".\Obj"
DeleteFolder ".\roslyn"
function DeleteFiles {
    param( [string]$Path )
    Write-Host " Remove file(s) '$Path'"
    Remove-Item -Path $Path -Force -ErrorAction SilentlyContinue
}
DeleteFiles ".\doc\changelog.txt"
DeleteFiles ".\config\pickit_*.txt"
DeleteFiles ".\config\pickit_*_70.ini"
DeleteFiles ".\config\ui_default\ui_default_*.xml"
DeleteFiles ".\plugins\user\*.txt"
DeleteFiles ".\sounds\notification_*.wav"
DeleteFiles ".\app.config"
DeleteFiles ".\*.exe.config"
DeleteFiles ".\Data\*.bin"
DeleteFiles ".\Data\*example.txt"
DeleteFiles ".\*.exe"
DeleteFiles ".\*.dll"
DeleteFiles ".\plugins_compiled_*"
DeleteFiles ".\*.version"

# unzip file
Write-Host "Unzip archive"
Expand-Archive -Path $zipFile -DestinationPath ".\" -Force

# write version number file
Write-Host "Write version file"
$parts = (Split-Path $zipFile -Leaf).Split(" ")
$hudVersion = $parts[1..2]
$d3Version = $parts[7]
Set-Content -Path "$hudVersion D3 $d3Version.version" -Value " "

# copy config files
Write-Host "Copy configuration files"
Copy-Item .\_config\ .\config\ -Force -ErrorAction SilentlyContinue

# finish
Write-Host "Unblock exe"
Unblock-File -LiteralPath .\TurboHUD.exe
Write-Host "Rename exe"
Move-Item .\TurboHUD.exe ".\$renamedExeName.exe"
Move-Item .\TurboHUD.exe.config ".\$renamedExeName.exe.config" -ErrorAction SilentlyContinue

[System.Windows.Forms.MessageBox]::Show("Update finished!", "TurboHUD update", [System.Windows.Forms.MessageBoxButtons]::OK)

Exit-PSSession
