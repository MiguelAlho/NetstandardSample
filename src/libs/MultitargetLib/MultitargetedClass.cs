using System;

namespace MultitargetLib
{
    public static class MultitargetedClass
    {
        public static void WriteACommonMessage()
        {
            Console.WriteLine("I'm writing from WriteACommonMessage()");
        }

        public static void WriteACompilationSpecificMessage()
        {
#if NETSTANDARD2_0
            Console.WriteLine("I'm writing from WriteACompilationSpecificMessage() for NetStandard");
#elif NET45
            Console.WriteLine("I'm writing from WriteACompilationSpecificMessage() for Net45");
#elif NET461
            Console.WriteLine("I'm writing from WriteACompilationSpecificMessage() for Net461");
#endif
        }
    }
}
