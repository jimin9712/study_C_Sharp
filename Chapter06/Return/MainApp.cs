﻿using System;

namespace Return
{ 
   class MainApp
    {
        static int Fibonacci(int n)
        {
            if (n < 2)
                return n;
            else
                return Fibonacci(n-1) + Fibonacci(n-2);
        }

        static void PrintProfile(string name, string phone)
        {
            if (name == "")
            {
                Console.WriteLine("이름을 입력해주세요");
                return;
            }
            Console.WriteLine($"Name:{name} , Phone:{phone}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"10번째 피보나치 수 : {Fibonacci(10)}");

            //PrintProfile("", "5394-9712");
            PrintProfile("이지민", "5392-9712");
        }
    }
}
