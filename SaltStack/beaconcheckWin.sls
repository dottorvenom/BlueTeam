check_defender:
  modules.run:
	- win_service.avaible:
	  - name: WinDefend
  - cmd.run:
	  - shell: powershell
	  - name: 'Set-Mppreference -DisableRealTimeMonitoring $false'
	  
{% set chiavi = [{'key':'HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\LSASS.exe','value':'AuditLevel','type':'REG_DWORD','data':'00000008'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RunAsPPL','type':'REG_DWORD','data':'00000001'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\SecurityProviders\WDigest','value':'UseLogonCredential','type':'REG_DWORD','data':'0'},{'key':'HKLM\SOFTWARE\Policies\Microsoft\Windows\CredentialsDelegation','value':'AllowProtectedCreds','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\mrxsmb10','value':'Start','type':'REG_DWORD','data':'4'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters','value':'SMB1','type':'REG_DWORD','data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanManServer\Parameters','value':'RestrictNullSessAccess','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RestrictAnonymousSAM','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RestrictAnonymous','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'EveryoneIncludesAnonymous','type':'REG_DWORD','data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa', 'value':'RestrictRemoteSAM', 'type':'REG_SZ', 'data':'O:BAG:BAD:(A;;RC;;;BA)'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'UseMachineId','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'LimitBlankPasswordUse','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\LSA\MSV1_0','value':'allownullsessionfallback','type':'REG_DWORD','data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanmanWorkstation\Parameters','value':'EnableSecuritySignature','type':'REG_DWORD','data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanManServer\Parameters','value':'RequireSecuritySignature','type':'REG_DWORD','data':'1'},{'key':'HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System','value':'LocalAccountTokenFilterPolicy','type':'REG_DWORD','data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\Control\Lsa','value':'DisableDomainCreds','type':'REG_DWORD','data':'1'}] %} 	  
check_registry: 
  {% for chiave in chiavi %}
  reg.present:
    - name: {{ chiave['key'] }}
	  - vname: {{ chiave['value'] }}
	  - vtype: {{ chiave['type'] }}
	  - vdata: {{ chiave['data'] }}
  {%endfor%}

# da testare su salt **************

'disable-windowsoptionalfeature -online -featurename MicrosoftWindowsPowershellV2 -norestart':
  cmd.run:
    - shell: powershell
    - onlyif: powershell -command 'Get-WindowsOptionalFeature -Online -FeatureName SMB1Protocol'
    - key:  state
    - get-return: Disabled 

# **************


'Disable-WindowsOptionalFeature -Online -FeatureName SMB1Protocol -norestart':
  cmd.run:
    - shell: powershell 
	
'disable-windowsoptionalfeature -online -featurename MicrosoftWindowsPowershellV2Root -norestart':
  cmd.run:
    - shell: powershell
	

{% set dizs = [{'key':'HKLM\Software\Policies\Microsoft\Windows\Installer','value':'AlwaysInstallElevated','type':'REG_DWORD', 'data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\mrxsmb10','value':'Start','type':'REG_DWORD', 'data':'4'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters','value':'SMB1','type':'REG_DWORD', 'data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanManServer\Parameters','value':'RestrictNullSessAccess','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RestrictAnonymousSAM','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RestrictAnonymous','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'EveryoneIncludesAnonymous','type':'REG_DWORD', 'data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'RestrictRemoteSAM','type':'REG_SZ', 'data':'"O:BAG:BAD:(A;;RC;;;BA)"'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'UseMachineId','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\Lsa','value':'LimitBlankPasswordUse','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Control\LSA\MSV1_0','value':'allownullsessionfallback','type':'REG_DWORD', 'data':'0'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanmanWorkstation\Parameters','value':'EnableSecuritySignature','type':'REG_DWORD', 'data':'1'},{'key':'HKLM\SYSTEM\CurrentControlSet\Services\LanManServer\Parameters','value':'RequireSecuritySignature','type':'REG_DWORD', 'data':'1'}] %} 	  
check_smb_share: 
  {% for chiave in dizs %}
  reg.present:
    - name: {{ chiave['key'] }}
	  - vname: {{ chiave['value'] }}
	  - vtype: {{ chiave['type'] }}
	  - vdata: {{ chiave['data'] }}
  {% endfor %}

{% set languagemode = "ConstrainedLanguage" %}
enable_const_lang_mode:
  cmd.run:
    - name: '$ExecutionContext.SessionState.LanguageMode = {{ languagemode }}'
    - shell: powershell
