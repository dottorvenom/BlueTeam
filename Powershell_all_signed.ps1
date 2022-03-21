#Get-ChildItem -Path HKLM:\SOFTWARE\Microsoft\PowerShell\1\ShellIds

#default
#MachinePolicy       Undefined
#   UserPolicy       Undefined
#      Process          Bypass
#  CurrentUser       Undefined
# LocalMachine    RemoteSigned
 
 
#Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
 
$stringa = Get-ExecutionPolicy -List

write-host "-------------------------------------"
write-host $stringa
write-host "-------------------------------------"

Set-ExecutionPolicy -ExecutionPolicy AllSigned -Scope Process
Set-ExecutionPolicy -ExecutionPolicy AllSigned -Scope LocalMachine
Set-ExecutionPolicy -ExecutionPolicy AllSigned -Scope CurrentUser

Get-ExecutionPolicy -List