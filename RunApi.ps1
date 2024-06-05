try {
    $env:ASPNETCORE_ENVIRONMENT = 'Development'
    $env:ASPNETCORE_URLS = 'https://localhost:7003;http://localhost:5294'
    Write-Host "Starting dojo.api session."
    Push-Location "$PSScriptRoot\dojo.api\bin\Debug"
    Start-Process dotnet -ArgumentList dojo.api.dll -NoNewWindow -Wait -PassThru
}
finally {
    Write-Host "Closed dojo.api session."
    Pop-Location
    # [Environment]::Exit(0)
}
