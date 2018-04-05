function WriteAppRunSplit()
{
	Write-Host ''
	Write-Host '---------------------------------------'
	Write-Host ''
}


Write-Host ''
Write-Host '----------- Single Target Apps ------------'
Write-Host ''

.\src\apps\Net35App\bin\Debug\Net35App.exe
WriteAppRunSplit
.\src\apps\Net45App\bin\Debug\Net45App.exe
WriteAppRunSplit
.\src\apps\Net461App\bin\Debug\Net461App.exe
WriteAppRunSplit
.\src\apps\Net462App\bin\Debug\Net462App.exe
WriteAppRunSplit
dotnet run --project .\src\apps\NetCore10App\NetCore10App.csproj
WriteAppRunSplit
dotnet run --project .\src\apps\NetCoreApp\NetCore20App.csproj
WriteAppRunSplit
.\src\apps\SDK_Net45App\bin\Debug\net45\SDK_Net45App.exe

Write-Host ''
Write-Host '----------- MultitargetedApp ------------'
Write-Host ''

.\src\apps\MultitargetApp\bin\Debug\net35\MultitargetApp.exe
WriteAppRunSplit
.\src\apps\MultitargetApp\bin\Debug\net45\MultitargetApp.exe
WriteAppRunSplit
.\src\apps\MultitargetApp\bin\Debug\net461\MultitargetApp.exe
WriteAppRunSplit
dotnet run --project .\src\apps\MultitargetApp\MultitargetApp.csproj --framework netcoreapp1.0
WriteAppRunSplit
dotnet run --project .\src\apps\MultitargetApp\MultitargetApp.csproj --framework netcoreapp2.0



