#$s = Get-AdUser -Identity 'test'

#remove sid history
try {
	Get-ADGroup "Domain Users" -properties sidhistory | foreach {Set-ADGroup $_ -remove @{sidhistory=$_.sidhistory.value}}
}
catch{
	write-host "Nothing sid history"
}

#prevent dcsync
$utente = get-AdGroupMember "Domain Users"
$baseSid = (Get-ADDomain).Domainsid.value
foreach ($u in $utente) {

	#filtro per RID >= 1000  (500 = admin...krbtgt)
	
	try {
		$rid = [convert]::ToInt32($u.SID.value.replace($baseSid+"-",''))
		if ($rid -gt 999) {
			write-host $u.SamAccountname $u.SID.value

			$cmd = "dsacls DC=MyDomain,DC=local /D '" + $u.SID.value + ":CA;Replicating Directory Changes'"
			Invoke-Expression $cmd

			$cmd = "dsacls DC=MyDomain,DC=local /D '" + $u.SID.value + ":CA;Replicating Directory Changes All'"
			Invoke-Expression $cmd

			$cmd = "dsacls DC=MyDomain,DC=local /D '" + $u.SID.value + ":CA;Replicating Directory Changes In Filtered Set'"
			Invoke-Expression $cmd

			$cmd = "dsacls DC=MyDomain,DC=local /D '" + $u.SID.value + ":CA;Replication synchronization'"
			Invoke-Expression $cmd
 
			write-host "Patched"


		}
	}
	catch{
		write-host "Error on SID" $u.SID.value
	}	
}




