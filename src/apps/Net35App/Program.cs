using System;
using MultitargetLib;

namespace Net35App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net35 App!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();
            Console.WriteLine("netstandard lib not supported in Net35 apps");
            //Console.WriteLine(NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
        }
    }
}
