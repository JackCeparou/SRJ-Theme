@ECHO OFF
SET args='%1'
:More
SHIFT
IF '%1' == '' GOTO Done
SET args=%args%,'%1'
GOTO More
:Done
IF %args% == '' (
    Powershell.exe -noprofile -command "& { .\zzz_update_hud.ps1 }"
) ELSE (
    Powershell.exe -noprofile -command "& { .\zzz_update_hud.ps1 %args% }"
)