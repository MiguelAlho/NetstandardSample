using MultitargetLib;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from a Net Core App!");

            MultitargetedClass.WriteACommonMessage();
            MultitargetedClass.WriteACompilationSpecificMessage();

            Console.WriteLine("press a key to end program");
            Console.ReadLine();
        }
    }
}
