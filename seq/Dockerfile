FROM microsoft/windowsservercore

LABEL Description="Seq Event Server" Vendor="Datalust" Version="3.3.23"

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]

RUN Invoke-WebRequest https://getseq.net/Download/Begin?version=3.3.23 -OutFile c:\seq-installer.msi -UseBasicParsing ; \
    Start-Process msiexec.exe -ArgumentList '/i c:\seq-installer.msi /quiet /norestart' -Wait ; \
    Remove-Item c:\seq-installer.msi -Force 

RUN seq install

CMD Start-Service seq ; \
    Write-Host Seq Event Server started... ; \
    Get-NetAdapter | Get-NetIPAddress | ? AddressFamily -EQ 'IPv4' | select -ExpandProperty IPAddress ; \
    while ($true) { Start-Sleep -Seconds 3600 }

EXPOSE 5341