$gruppi = @('Administrators','Enterprise admins','Print Operators','DnsAdmins',
		'Backup Operators','Account Operators','Cert Publishers','Server Operators')

foreach ($g in $gruppi) {
	write-output $g
	get-AdGroupMember $g -recursive
}     