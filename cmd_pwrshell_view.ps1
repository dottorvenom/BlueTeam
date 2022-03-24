
write-output "Start: " 
Get-Date

#sessioni attive
write-output "---------------------------- Sessioni attive"
Get-CimInstance -ClassName Win32_LogonSession
		 
#utenti connessi
write-output "---------------------------- Utenti connessi"
Get-CimInstance -ClassName Win32_ComputerSystem -Property UserName
		 
#elenco processi powershell
write-output "---------------------------- Processi Powershell"
Get-Process -Name power*
		 
		
#elenco utenti dal profile list del registro
#Get-LocalUser -Name $item.name | select SID
$localuser =  Get-LocalUser | Select-Object SID
foreach ($itemSid in $localuser)  {
				
		#write $item | ConvertTo-Json   #serializzato per estrarre le proprietà
		$Percorso = 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\'+$itemSid.SID.value
		if (Test-Path $percorso){
			$ProfileImage = Get-ItemPropertyValue $percorso "ProfileImagePath"
					
			#lettura del file cache se presente
			$file_path = $ProfileImage+"\AppData\Roaming\Microsoft\Windows\PowerShell\PSReadLine\ConsoleHost_history.txt"
			if (Test-Path -Path $file_path){
				write-output "----------------------------"
				write-output $ProfileImage
				#write-host "----------------------------"
				write-output "----------------------------"
				Get-Content $file_path | ConvertTo-Json
				write-output "----------------------------"				
			}
			
			#users ---> sid ---> cache powershell ---> eventi log "Windows Powershell" HostApplication					
			$logs = Get-WinEvent -FilterHashtable @{ ProviderName='Microsoft-Windows-PowerShell'; id=4102; UserId=$itemSid.SID.value}
			$out=""
			foreach ($itemLog in $logs) {
				#write-output $item.properties.value #| ConvertTo-Json				
				write-output $itemLog.properties.value | Add-Content ".\logevnt.txt"
			}
			
			
			#parsing del file cache
			#if (Test-Path -Path ".\logevnt.txt"){
			#	$streamreader = New-Object System.IO.StreamReader(".\logevnt.txt")
			#	while (($readline = $streamreader.ReadLine()) -ne $null)
			#	{				
			#		if ($readline.IndexOf('Applicazione host') > 0) {
			#			write-output $readline
			#		}
			#		
			#	}
			#}
						
		}		
} 
write-output "End: " 	
Get-Date	