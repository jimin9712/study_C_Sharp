﻿namespace InitalizingArray
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            string[] array1 = new string[3] { "안녕", "Hello", "Halo" };

            Console.WriteLine(array1);

            foreach(string greeting in array1) 
                Console.WriteLine($"{greeting}"); 

            string[] array2 = new string[3] { "안녕", "Hello", "Halo" };

            Console.WriteLine(array2);

            foreach(string greeting in array2) 
                Console.WriteLine($"{greeting}"); 

            string[] array3 = new string[3] { "안녕", "Hello", "Halo" };

            Console.WriteLine(array3);

            foreach(string greeting in array3) 
                Console.WriteLine($"{greeting}"); 


                }
    }
}
