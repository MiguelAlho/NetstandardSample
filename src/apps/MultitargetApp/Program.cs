using System;
using MultitargetLib;

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
#endif

            Console.WriteLine("Hello World from a Multitargeted App !");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();

#if NET35
            Console.WriteLine("netstandard lib not supported in Net35 apps");
#else
            Console.WriteLine(NetstandardOnlyLib.NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
#endif

        }
    }
}
