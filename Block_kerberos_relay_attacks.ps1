Get-ADObject -Identity ((Get-ADDomain).distinguishedname) -Properties 'ms-DS-MachineAccountQuota'

$name = (Get-ADDomain | Get-ADObject -Properties 'Name')
write-host ---------------------------------
write-host $name
write-host ---------------------------------
Set-ADDomain -Identity $name -Replace @{"ms-DS-MachineAccountQuota"="0"}

Get-ADObject -Identity ((Get-ADDomain).distinguishedname) -Properties 'ms-DS-MachineAccountQuota'