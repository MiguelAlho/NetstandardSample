using System;
using MultitargetLib;
using MultitargetLibWithDependencies;
using NetstandardOnlyLib;

namespace SDK_Net45App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net 45 App (SDK project)!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();
            Console.WriteLine(NetstandardClass.ReturnAMessageFromANetstandardOnlyLibrary());
            Console.WriteLine($"WebRequest result is {PrintRequest.RequestSomething()}");
        }
    }
}
