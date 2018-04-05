# NetstandardSample
A simple, sample project-solution to understand how the netstandard refs and packaging works, especially for multitargeted package projects

## what it has

Basicly it's a library that is setup to multitarget (net45, net461, and netstandard2.0), and then a set of applications that ref the project. 
The lib has methods that print out messages that can identify which compilation of the lib is being loaded:

`MultitargetedClass.WriteACommonMessage()` writes a common message available to all compilation targets.
`MultitargetedClass.WriteACompilationSpecificMessage()` writes a message that is conditionally compiled into the assembly, based on the target.

`WriteACompilationSpecificMessage`is used to identify which version of the assembly was referenced and loaded.

## Tested Runtimes

There are apps that are compiled to specific targets - net35, net45, net461, netcore10 and netcore20. There is also an app that multitargets different runtimes.

### Runing the project

In Powershell from the root of the repo, run:

```
.\run.ps1
```

### Expected Output

```

----------- Single Target Apps ------------

Hello World from a Net35 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorlib.dll
		WriteACompilationSpecificMessage() for Net35
netstandard lib not supported in Net35 apps
cannot printRequest since the lis is not 3.5 compatible

---------------------------------------

Hello World from a Net45 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Hello World from a Net 461 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Hello World from a Net 462 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Hello World from a Net Core 1.0 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Assembly.Location is NOT available in NEtStandard1_3
		WriteACompilationSpecificMessage() for NetStandard 1.3
	this is a Netstandard string.
		Webrequest using C:\Users\AlhoM\.nuget\packages\system.net.http\4.3.3\runtimes\win\lib\netstandard1.3\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Hello World from a Net Core 2.0 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Console assembly location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Console.dll
		WriteACompilationSpecificMessage() for NetStandard 2.0
	this is a Netstandard string.
		Webrequest using C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Hello World from a Net 45 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

----------- MultitargetedApp ------------

Compiled for Net35
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorlib.dll
		WriteACompilationSpecificMessage() for Net35
netstandard lib not supported in Net35 apps
HttpClient dependent lib not supported in Net35 apps

---------------------------------------

Compiled for Net45
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Compiled for Net461
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\GH\NetstandardSample\src\apps\MultitargetApp\bin\Debug\net461\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Microsoft (R) Build Engine version 15.6.82.30579 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 47.35 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 49.35 ms for C:\GH\NetstandardSample\src\lib\MultitargetLibWithDependencies\MultitargetLibWithDependencies.csproj.
  Restore completed in 48.45 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 39.99 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
Compiled for NetCore 1.0
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Assembly.Location is NOT available in NEtStandard1_3
		WriteACompilationSpecificMessage() for NetStandard 1.3
	this is a Netstandard string.
		Webrequest using C:\Users\AlhoM\.nuget\packages\system.net.http\4.3.3\runtimes\win\lib\netstandard1.3\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Microsoft (R) Build Engine version 15.6.82.30579 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 47.92 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 50.47 ms for C:\GH\NetstandardSample\src\lib\MultitargetLibWithDependencies\MultitargetLibWithDependencies.csproj.
  Restore completed in 50.28 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 40.38 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
Compiled for NetCore 2.0
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Console assembly location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Console.dll
		WriteACompilationSpecificMessage() for NetStandard 2.0
	this is a Netstandard string.
		Webrequest using C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.2.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK


```

