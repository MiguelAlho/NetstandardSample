using MultitargetLib;
using System;
using NetstandardOnlyLib;

namespace Net462App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net 462 App!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();
            Console.WriteLine(NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
        }
    }
}
