﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace StringSlice
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string greeting = "Good morning.";

            WriteLine(greeting.Substring(0, 5)); // "morning"
            WriteLine(greeting.Substring(5)); // "Good"
            WriteLine();

            string[] arr = greeting.Split(
                new string[] { " " }, StringSplitOptions.None);
            WriteLine("Word Count : {0}", arr.Length);

            foreach (string element in arr)
                WriteLine("{0}", element);
        }
    }
}