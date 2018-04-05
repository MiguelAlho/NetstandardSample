using System;
using MultitargetLib;

#if !NET35
using MultitargetLibWithDependencies;
#endif

namespace MultitargetApp
{
    static class Program
    {
        static void Main(string[] args)
        {

#if NETCOREAPP1_0
            Console.WriteLine("Compiled for NetCore 1.0");
#elif NETCOREAPP2_0
            Console.WriteLine("Compiled for NetCore 2.0");
#elif NET35                        
            Console.WriteLine("Compiled for Net35");
#elif NET45
            Console.WriteLine("Compiled for Net45");
#elif NET461
            Console.WriteLine("Compiled for Net461");
#elif NET462
            Console.WriteLine("Compiled for Net462");
#elif NET471
            Console.WriteLine("Compiled for Net471");
#endif

            Console.WriteLine("Hello World from a Multitargeted App !");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();

#if NET35
            Console.WriteLine("netstandard lib not supported in Net35 apps");
            Console.WriteLine("HttpClient dependent lib not supported in Net35 apps");
#else
            Console.WriteLine(NetstandardOnlyLib.NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
            Console.WriteLine($"WebRequest result is {PrintRequest.RequestSomething()}");
#endif
            

        }
    }
}
