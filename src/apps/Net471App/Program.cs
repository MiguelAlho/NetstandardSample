using System;
using MultitargetLib;
using MultitargetLibWithDependencies;
using NetstandardOnlyLib;

namespace Net471App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net 471 App!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();
            Console.WriteLine(NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
            Console.WriteLine($"WebRequest result is {PrintRequest.RequestSomething()}");
        }
    }
}
