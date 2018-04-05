using System;
using MultitargetLib;

namespace SDK_Net45App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net 45 App!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();

            Console.WriteLine("press a key to end program");
            Console.ReadLine();
        }
    }
}
