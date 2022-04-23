


Set-ADAccountPassword -Identity $args[0] -Reset -NewPassword (ConvertTo-SecureString -AsPlainText $args[1] -Force)
#Set-ADAccountPassword -Identity "Administrator" -Reset -NewPassword (ConvertTo-SecureString -AsPlainText "Password@@!" -Force)