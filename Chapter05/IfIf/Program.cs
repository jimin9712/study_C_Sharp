using System;

namespace IfIf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("숫자를 입력하세요 : ");
            
            String input = Console.ReadLine();
            int number = Convert.ToInt32(null);

            if (number > 0)
            {
                if (number == 0)
                    Console.WriteLine("0보다 큰 짝수");
                else
                    Console.WriteLine("0보다 큰 홀수");
            }
            else
            {
                Console.WriteLine("0보다 작거나 같은 수");
            }

        }
    }
}
