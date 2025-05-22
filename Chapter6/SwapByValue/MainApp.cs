using System;
namespace SwapByValue
{
     class MainApp
    {
        public static void Swap(int a, int b)
        {
            int temp = b;
            b = a; a = temp;
        }
        static void Main(string[] args)
        {
            int x = 4;
            int y = 3;

            Console.WriteLine($"x:{x}, y:{y}");

            Swap(x, y);

            Console.WriteLine($"x:{x}, y:{y}");
        }
    }
}
