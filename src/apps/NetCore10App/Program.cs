using System;
using MultitargetLib;
using NetstandardOnlyLib;

namespace NetCore10App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net Core 1.0 App (SDK project)!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();
            Console.WriteLine(NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
        }
    }
}
