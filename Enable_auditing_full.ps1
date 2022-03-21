
#impostazione auditing filesystem objects ----------------------------------

$path = "c:\windows\system32"  #c:\windows, c:\windows\system32  e altro

$AuditUser = "Everyone"
$InheritType = "ContainerInherit, ObjectInherit"
$AuditType = "Success"
$AccessRule = New-Object System.Security.AccessControl.FileSystemAuditRule($AuditUser,"FullControl",$InheritType,"None",$AuditType)
$ACL = Get-Acl $path
$ACL.SetAuditRule($AccessRule)

Get-Acl $path -Audit | Format-List
$ACL | Set-Acl $path
Get-Acl $path -Audit | Format-List
#------------------------------------------------------------



#impostazione delle gpo ----------------------------------
#auditpol /list /subcategory:*

write-host "------------------------------"
auditpol /set /subcategory:SAM  /success:enable /failure:enable
auditpol /set /subcategory:"Handle Manipulation" /success:enable /failure:enable
auditpol /set /subcategory:"File System" /success:enable /failure:enable
auditpol /set /subcategory:"Registry" /success:enable /failure:enable
auditpol /set /subcategory:"Kernel Object" /success:enable /failure:enable
auditpol /Get /category:"Object Access"

auditpol /set /subcategory:"Group Membership" /success:enable /failure:enable
auditpol /Get /category:"Logon/Logoff"

auditpol /set /subcategory:"Process Creation" /success:enable /failure:enable
auditpol /set /subcategory:"Process Termination" /success:enable /failure:enable
auditpol /Get /category:"Detailed Tracking"

auditpol /set /subcategory:"Kerberos Service Ticket Operations" /success:enable /failure:enable
auditpol /set /subcategory:"Kerberos Authentication Service" /success:enable /failure:enable
auditpol /Get /category:"Account Logon"
write-host "------------------------------"
#-----------------------------------------------------------
