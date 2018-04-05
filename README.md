# NetstandardSample
A simple, sample project-solution to understand how the netstandard refs and packaging works, especially for multitargeted package projects

## what it has

Basicly it's a library that is setup to multitarget (net45, net461, and netstandard2.0), and then a set of applications that ref the project. 
The lib has methods that print out messages that can identify which compilation of the lib is being loaded:

`MultitargetedClass.WriteACommonMessage()` writes a common message available to all compilation targets.
`MultitargetedClass.WriteACompilationSpecificMessage()` writes a message that is conditionally compiled into the assembly, based on the target.

`WriteACompilationSpecificMessage`is used to identify which version of the assembly was referenced and loaded.

## Tested Runtimes

There are apps that are compiled to specific targets - 


