# NetstandardSample
A simple, sample project-solution to understand how the netstandard refs and packaging works, especially for multitargeted package projects

## what it has
### Libraries

There are three libraries with very simple writes or outputs:

* `NetstandardOnlyLib` - targets only a single `netstandard1.0` target framework. It's only method returns a string. Console is not `netstandard1.0` compatible, so just returning a string and delegating writing output to the host app. It is expected to be consumable for all apps targeting net45 and above.
* `MultitargetLib`- simple lib targeting `net35`, `net45`, `netstandard1.3`, `netstandard2.0`. Lowest is 1.3 due to use of `Console`. Has conditional statements to print out messages that contains a reference to the target framework compiled lib that was loaded. It helps to see in which scenarios a netstandard is loaded instead of a netX. It has no external dependencies. Should be loadable in all but the net35 app(s) and also generates a nuget package on build.
* * `MultitargetedClass.WriteACommonMessage()` writes a common message available to all compilation targets.
* * `MultitargetedClass.WriteACompilationSpecificMessage()` writes a message that is conditionally compiled into the assembly, based on the target. `WriteACompilationSpecificMessage`is used to identify which version of the assembly was referenced and loaded.
* `MultitargetLibWithDependencies` - similar to the previous lib, but pulls in `System.Net.Http`. Makes a simple web request, and is used to help determine which package or assembly is loaded for `System.Net.Http` based on the app's target framework(s). It only targets `net45` and `netstandard 1.6`. The initial expectation is that `net45` targets will use the FW reference while the `netstandard` target should reference the packaged dll.

## Tested Runtimes

There are apps that are compiled to specific targets - net35, net45, net461, net462, net471, netcore10 and netcore20. There is also an app that multitargets different runtimes.

### Runing the project

Build in VS (no build script yet) and then in Powershell, from the root of the repo, run:

```
.\run.ps1
```

### Expected Output (With comments)

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
```

Ìn the net35 (old csproj) `MultitargetLib`'s `System.Console` ref was loaded from the installed framework folder (v2.0.50727); 
`WriteACompilationSpecificMessage` writes "net35" so we can see that the `net35` compilation was loaded for the lib.
The methods in `MultitargetLibWithDependencies` and `NetsatndardOnlyLib`could not be used as they are not net35 compatible.

```
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
```

Ìn the net45 (old csproj) `MultitargetLib`'s `System.Console` ref was loaded from the installed framework folder (v4.0.30319); 
`WriteACompilationSpecificMessage` writes "net45" so we can see that the `net45` compilation was loaded for the lib (as expected).
`NetstandardOnlyLib` writes it's string soNet45 projects can load netstandard1.0 libs correctly.
`MultitargetLibWithDependencies` can make the webrequest and uses the `net45` compilation.

```
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

Hello World from a Net 471 App!
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

```

Ìn the net461, net462 and net471 (old csproj) `MultitargetLib`'s `System.Console` ref was loaded from the installed framework folder (v4.0.30319); 
`WriteACompilationSpecificMessage` writes "net45" so we can see that the `net45` compilation was loaded for the lib (as expected), which is a bit strange - while for `net45`that would seem to be "normal" for net461 and abouve I'd expect the netstandard since it is compatible. Instead, it opted for the compatible version from the installed FW.
`NetstandardOnlyLib` writes it's string so `Net461` and abouve projects can load `netstandard1.0` libs correctly.
`MultitargetLibWithDependencies` can make the webrequest and uses the `net45` compilation - since it loads `System.Net.Http` from the installed FW folder.

```
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

```

Ìn the netcore1.0 (sdk csproj) `MultitargetLib`'s `System.Console` ref was loaded, but the origin is unclear (most likely from the app bin foler) since the Location prop is not available in Assembly at the target;
`WriteACompilationSpecificMessage` writes "netsatndard1_3" so we can see that the lowest compatible netstandard compilation was loaded for the lib.
`NetstandardOnlyLib` writes it's string so `netcore` apps can load `netstandard1.0` libs correctly.
`MultitargetLibWithDependencies` can make the webrequest and uses the `netstandard1.3` compilation from the `System.Net.Http` package.

```
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

```

Ìn the netcore2.0 (sdk csproj) `MultitargetLib`'s `System.Console` ref was loaded, but the origin is known in this case - i is from the latest sdk folder
`WriteACompilationSpecificMessage` writes "netstandard 2.0" so we can see that the closest? compatible netstandard compilation was loaded for the lib. (the rule doesn't seem to be "lowest" since if it were, we should have gotten "netstandard 1.3")
`NetstandardOnlyLib` writes it's string so `netcore` apps can load `netstandard1.0` libs correctly.
`MultitargetLibWithDependencies` can make the webrequest and uses the latest compilation of `System.Net.Http` from the SDK folder (and NOT from the package!). I would have expected it to be from the package....

```
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

``` 

though it is an SDK based csproj, the result is the same as previously

```

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


```
The first two targets of the multitarget app definiton (net35 and net45) have the same output as before.

```
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

Compiled for Net462
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\GH\NetstandardSample\src\apps\MultitargetApp\bin\Debug\net462\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

---------------------------------------

Compiled for Net471
Hello World from a Multitargeted App !
	I'm writing from WriteACommonMessage()
	I'm writing from WriteACompilationSpecificMessage()
		Console assembly name: System.Console, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
		Console assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
		WriteACompilationSpecificMessage() for Net45
	this is a Netstandard string.
		Webrequest using C:\GH\NetstandardSample\src\apps\MultitargetApp\bin\Debug\net471\System.Net.Http.dll 
		in System.Net.Http.HttpClient, System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
WebRequest result is OK

```
Things begin to difer here. We had to add the package ref conditionaly:

```

<ItemGroup Condition="$(TargetFramework) == 'net461' or $(TargetFramework) == 'net462' or $(TargetFramework) == 'net471'">
	<PackageReference Include="System.Net.Http" Version="4.3.3" />

```
otherwise we'd get the `System.IO.FileLoadException: Could not load file or assembly 'System.Diagnostics.DiagnosticSource, Version=4.0.0.0` exception at runtime.
Console is loaded from the framework, while HttpClient seems to be copied from the package. Probably using the lowest netstandard version based on the next two targets...

```

---------------------------------------

Microsoft (R) Build Engine version 15.6.82.30579 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 62.69 ms for C:\GH\NetstandardSample\src\lib\MultitargetLibWithDependencies\MultitargetLibWithDependencies.csproj.
  Restore completed in 62.7 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 58.76 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 54.57 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
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

  Restore completed in 50.68 ms for C:\GH\NetstandardSample\src\libs\NetstandardOnlyLib\NetstandardOnlyLib.csproj.
  Restore completed in 50.97 ms for C:\GH\NetstandardSample\src\lib\MultitargetLibWithDependencies\MultitargetLibWithDependencies.csproj.
  Restore completed in 48.74 ms for C:\GH\NetstandardSample\src\libs\MultitargetLib\MultitargetLib.csproj.
  Restore completed in 36.01 ms for C:\GH\NetstandardSample\src\apps\MultitargetApp\MultitargetApp.csproj.
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
the versions for netcore get recompiled and (probably) load the System.Console lib from the SDK folder.
For `System.Net.Http` we have the same behaviour as in the previous run of the single target apps. On note - The AssemblyVersions are different. Bining redirects would need to be considered if multiple versions were used by other libraries... (this is where alot of the referencing get's complicated).

