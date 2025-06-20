﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus (int a, int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }
    internal class MainApp
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3,4));

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(7,5));
        }
    }
}
