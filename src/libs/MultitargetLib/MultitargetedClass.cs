using System;
using System.Reflection;

namespace MultitargetLib
{
    public static class MultitargetedClass
    {
        public static void WriteACommonMessage()
        {
            Console.WriteLine("\tI'm writing from WriteACommonMessage()");
        }

        public static void WriteACompilationSpecificMessage()
        {
            Console.WriteLine("\tI'm writing from WriteACompilationSpecificMessage()");
            //Console is not available below Netstandard1.3, so for 45, the FW specific implementation must be loaded.
#if NETSTANDARD1_3
            Console.WriteLine("\t\tConsole assembly name: " + typeof(Console).AssemblyQualifiedName);
            Console.WriteLine("\t\tAssembly.Location is NOT available in NEtStandard1_3");
#elif NETSTANDARD2_0
            Console.WriteLine("\t\tConsole assembly name: " + typeof(Console).AssemblyQualifiedName);
            Console.WriteLine("\t\tConsole assembly location: " + Assembly.GetAssembly(typeof(Console)).Location);
#elif NET35 || NET45 || NET461
            Console.WriteLine("\t\tConsole assembly name: " + typeof(Console).AssemblyQualifiedName);
            Console.WriteLine("\t\tConsole assembly location: " + Assembly.GetAssembly(typeof(Console)).Location);
#endif

#if NETSTANDARD1_3
            Console.WriteLine("\t\tWriteACompilationSpecificMessage() for NetStandard 1.3");
#elif NETSTANDARD2_0
            Console.WriteLine("\t\tWriteACompilationSpecificMessage() for NetStandard 2.0");
#elif NET35
            Console.WriteLine("\t\tWriteACompilationSpecificMessage() for Net35");
#elif NET45
            Console.WriteLine("\t\tWriteACompilationSpecificMessage() for Net45");
#elif NET461
            Console.WriteLine("\t\tWriteACompilationSpecificMessage() for Net461");
#endif
        }
    }
}
