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

---------------------------------------

Hello World from a Net45 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

---------------------------------------

Hello World from a Net 461 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

---------------------------------------

Hello World from a Net 462 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

---------------------------------------

Hello World from a Net Core 1.0 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Assembly.Location is NOT available in NEtStandard1_3
		WriteACompilationSpecificMessage() for NetStandard 1.3
	this is a Netstandard string.

---------------------------------------

Hello World from a Net Core 2.0 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Console assembly location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Console.dll
		WriteACompilationSpecificMessage() for NetStandard 2.0
	this is a Netstandard string.

---------------------------------------

Hello World from a Net 45 App (SDK project)!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

----------- MultitargetedApp ------------

Compiled for Net35
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorlib.dll
		WriteACompilationSpecificMessage() for Net35
netstandard lib not supported in Net35 apps

---------------------------------------

Compiled for Net45
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

---------------------------------------

Compiled for Net461
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.

---------------------------------------

Microsoft (R) Build Engine version 15.6.82.30579 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 65.29 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 65.95 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 54.18 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
Compiled for NetCore 1.0
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Assembly.Location is NOT available in NEtStandard1_3
		WriteACompilationSpecificMessage() for NetStandard 1.3
	this is a Netstandard string.

---------------------------------------

Microsoft (R) Build Engine version 15.6.82.30579 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 38.19 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 40.6 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 41.12 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
Compiled for NetCore 2.0
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, System.Console, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
		Console assembly location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6\System.Console.dll
		WriteACompilationSpecificMessage() for NetStandard 2.0
	this is a Netstandard string.


```

