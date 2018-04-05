﻿using MultitargetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net45App
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
