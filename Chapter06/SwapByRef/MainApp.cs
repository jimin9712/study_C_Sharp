﻿using System;
namespace SwapByRef
{
    class MainApp
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a; a = temp;
        }
        static void Main(string[] args)
        {
            int x = 4;
            int y = 3;

            Console.WriteLine($"x:{x}, y:{y}");

            Swap(ref x, ref y);

            Console.WriteLine($"x:{x}, y:{y}");
        }
    }
}
